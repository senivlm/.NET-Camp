using System;
using System.Collections.Generic;

namespace Homework12_3
{
    class PostfixForm
    {
        private string expression;

        public PostfixForm(string expression)
        {
            this.expression = expression;
        }

        public PostfixForm() : this("") { }

        public string Expression { get => expression; set => expression = value; }

        public string InfixToPostfix()
        {
            string result = "";
            Stack<string> stack = new();
            string[] items = expression.Split(' ');
            for (int i = 0; i < items.Length; i++)
            {
                var temp = items[i];
                if (int.TryParse(temp, out int operand))
                {
                    result += temp + " ";
                }
                else if (char.TryParse(temp, out char leftBracket) && leftBracket == '(')
                {
                    stack.Push(temp);
                }
                else if (char.TryParse(temp, out char rightBracket) && rightBracket == ')')
                {
                    while(stack.Count > 0 && stack.Peek() != "(")
                    {
                        result += stack.Pop() + " ";
                    }
                    if(!(stack.Count > 0 && stack.Peek() != "("))
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    while (stack.Count > 0 && Priority(stack.Peek()) >= Priority(temp))
                    {
                        result += stack.Pop() + " ";
                    }
                    stack.Push(temp);
                }
            }

            while (stack.Count > 0)
            {
                result += stack.Pop() + " ";
            }
            return result.Substring(0, result.Length - 1);
        }

        private int Priority(string oper)
        {
            switch (oper)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                case "cos":
                case "sin":
                    return 4;
                default:
                    return -1;
            }
        }

        public double CalculatePostfix()
        {
            string[] items = InfixToPostfix().Split(' ');
            Stack<string> stack = new();

            for (int i = 0; i < items.Length; i++)
            {
                string temp = items[i];
                if (int.TryParse(temp, out int operand))
                {
                    stack.Push(temp);
                }
                else if(temp == "cos" || temp == "sin")
                {
                    double a = double.Parse(stack.Pop());
                    switch (temp)
                    {
                        case "cos":
                            stack.Push($"{Math.Cos(a)}");
                            break;
                        case "sin":
                            stack.Push($"{Math.Sin(a)}");
                            break;
                    }
                }
                else
                {
                    double a = double.Parse(stack.Pop());
                    double b = double.Parse(stack.Pop());
                    switch (temp)
                    {
                        case "+":
                            stack.Push($"{a + b}");
                            break;
                        case "-":
                            stack.Push($"{b - a}");
                            break;
                        case "*":
                            stack.Push($"{a * b}");
                            break;
                        case "/":
                            stack.Push($"{b / a}");
                            break;
                        case "^":
                            stack.Push($"{Math.Pow(b, a)}");
                            break;
                    }
                }
            }

            return double.Parse(stack.Pop());
        }
    }
}
