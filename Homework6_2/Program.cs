using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Homework6_2
{
    class Program
    {
        static void Main(string[] args)
        {//Нічого захищати не треба?
            WorkWithTextFromFile workWithText = new WorkWithTextFromFile("text.txt");
            Console.WriteLine(workWithText);
            workWithText.WriteEachSentenceToFile();
            workWithText.GetLongestWordsFromEachSentence();
            Console.WriteLine("The longest words in each sentence");
            string[] longestWords = workWithText.GetLongestWordsFromEachSentence();
            for (int i = 0; i < longestWords.Length; i++)
            {
                Console.WriteLine(longestWords[i]);
            }
            Console.WriteLine("The smallest words in each sentence");
            string[] smallestWords = workWithText.GetSmallestWordsFromEachSentence();
            for (int i = 0; i < smallestWords.Length; i++)
            {
                Console.WriteLine(smallestWords[i]);
            }
        }
    }
}
