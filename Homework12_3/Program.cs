using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework12_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "1 + 4 * 6 - 5";
            PostfixForm postfixForm = new(expression);
            Console.WriteLine("Infix form: " + postfixForm.Expression);
            Console.WriteLine("Postfix form: " + postfixForm.InfixToPostfix());
            Console.WriteLine("Result: " + postfixForm.CalculatePostfix());
            Console.WriteLine("\n***********\n");
            postfixForm.Expression = "( 1 + 4 ) * ( 6 - 5 )";
            Console.WriteLine("Infix form: " + postfixForm.Expression);
            Console.WriteLine("Postfix form: " + postfixForm.InfixToPostfix());
            Console.WriteLine("Result: " + postfixForm.CalculatePostfix());
            Console.WriteLine("\n***********\n");
            postfixForm.Expression = "7 + 5 ^ 2";
            Console.WriteLine("Infix form: " + postfixForm.Expression);
            Console.WriteLine("Postfix form: " + postfixForm.InfixToPostfix());
            Console.WriteLine("Result: " + postfixForm.CalculatePostfix());
            Console.WriteLine("\n***********\n");
            postfixForm.Expression = "12 / 6 * 2 + 5 ^ 2";
            Console.WriteLine("Infix form: " + postfixForm.Expression);
            Console.WriteLine("Postfix form: " + postfixForm.InfixToPostfix());
            Console.WriteLine("Result: " + postfixForm.CalculatePostfix());
            Console.WriteLine("\n***********\n");
            postfixForm.Expression = "4 + 2 ^ ( 7 - 12 / 3 )";
            Console.WriteLine("Infix form: " + postfixForm.Expression);
            Console.WriteLine("Postfix form: " + postfixForm.InfixToPostfix());
            Console.WriteLine("Result: " + postfixForm.CalculatePostfix());
            Console.WriteLine("\n***********\n");
            postfixForm.Expression = "cos ( 3 + 6 ) + 3 ^ 2";
            Console.WriteLine("Infix form: " + postfixForm.Expression);
            Console.WriteLine("Postfix form: " + postfixForm.InfixToPostfix());
            Console.WriteLine("Result: " + postfixForm.CalculatePostfix());
            postfixForm.Expression = "2 ^ cos ( 2 + sin ( 5 * 20 ) )";
            Console.WriteLine("Infix form: " + postfixForm.Expression);
            Console.WriteLine("Postfix form: " + postfixForm.InfixToPostfix());
            Console.WriteLine("Result: " + postfixForm.CalculatePostfix());
        }
    }
}
