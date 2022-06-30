using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework10
{
    class Translator
    {
        private Dictionary<string, string> vocabluary;
        private string text;
        private string pathToDictionary;
        private string pathToText;
        private const int countVariable = 3;
        private int counter = 0;

        public Translator(Dictionary<string, string> vocabluary, string text,
            string pathToDictionary, string pathToText)
        {
            this.vocabluary = vocabluary.ToDictionary(entry => entry.Key, entry => entry.Value);
            this.text = text;
            this.pathToDictionary = pathToDictionary;
            this.pathToText = pathToText;
        }

        public Translator(string pathToDictionary, string pathToText)
        {
            vocabluary = new();
            text = "";
            this.pathToDictionary = pathToDictionary;
            this.pathToText = pathToText;
        }

        public Translator() : this("../../../Dictionary.txt", "../../../Text.txt")
        {

        }

        public void AddText(string text)
        {
            this.text += text;
        }

        public void AddDictionary(Dictionary<string, string> vocabluary)
        {
            this.vocabluary = vocabluary.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public string TranslateText()
        {
            string result = "";
            string[] words = text.Split(' ');
            foreach (var word in words)
            {
                result += ChangeWord(word) + ' ';
            }
            result = result[0..^1];
            return result;
        }

        private string ChangeWord(string word)
        {
            string result = "";
            string tempWord = word;
            if (!word.Trim().Equals(""))
            {
                if(Char.IsPunctuation(word[word.Length - 1]))
                {
                    if(word.Length == 1)
                    {
                        tempWord = "" + word[word.Length - 1];
                    }
                    else
                    {
                        tempWord = ChangeWord(word[0..^1]) + word[word.Length - 1];
                    }
                }
                else
                {
                    bool isUppercase = word.Substring(0, 1) == word.Substring(0, 1).ToUpper();
                    if (isUppercase)
                    {
                        tempWord = tempWord.ToLower();
                    }
                    while (!vocabluary.ContainsKey(tempWord) && counter < countVariable)
                    {
                        AddToDictionary(tempWord);
                        counter++;
                    }
                    if (isUppercase)
                    {
                        tempWord = vocabluary[tempWord].Substring(0, 1).ToUpper() + vocabluary[tempWord].Substring(1).ToLower();
                    }
                    else
                    {
                        tempWord = vocabluary[word];
                    }                        
                }
            }
            result += tempWord;
            return result;
        }

        private void AddToDictionary(string word)
        {
            Console.WriteLine($"Введіть заміну для слова {word}");
            string value = Console.ReadLine();
            vocabluary.Add(word, value);
            Reader.WriteToDictionary(word, value, "../../../Dictionary.txt");
        }
    }
}
