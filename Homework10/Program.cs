using System;
using System.Collections.Generic;
using System.IO;

namespace Homework10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = new();
            Dictionary<string, string> dic = new();
            try
            {

                text = Reader.ReadText("../../../Text.txt");
                dic = Reader.ReadDictionary("../../../Dictionary.txt");
                Translator translator = new Translator();
                translator.AddDictionary(dic);
                foreach (var item in text)
                {
                    translator.AddText(item);
                }
                string chargedText = translator.TranslateText();
                Console.WriteLine(chargedText);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
