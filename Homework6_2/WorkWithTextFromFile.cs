using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework6_2
{
    class WorkWithTextFromFile
    {
        private string text;
        private string[] sentences;

        public WorkWithTextFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                text = reader.ReadToEnd();
            }
        }

        #region Methods

        public void WriteEachSentenceToFile()
        {
            sentences = Regex.Split(text, @"(?<=[\.!\?])\s+");
            using (StreamWriter writer = new StreamWriter("Result.txt"))
            {
                foreach (var item in sentences)
                {
                    writer.WriteLine(item);
                }
            }
        }

        public string[] GetLongestWordsFromEachSentence()
        {
            string[] longestWords = new string[sentences.Length];
            char[] separators = { ' ', ',', '.', '!', '?', '\"', '\'', ':', '|'};
            for (int i = 0; i < longestWords.Length; i++)
            {
                string[] words = sentences[i].Split(separators);
                longestWords[i] = words[0];
                for (int j = 1; j < words.Length; j++)
                {
                    if(words[j].Length > longestWords[i].Length)
                    {
                        longestWords[i] = words[j];
                    }
                }
            }
            return longestWords;
        }

        public string[] GetSmallestWordsFromEachSentence()
        {
            string[] smallestWords = new string[sentences.Length];
            char[] separators = { ' ', ',', '.', '!', '?', '\"', '\'', ':', '|' };
            for (int i = 0; i < smallestWords.Length; i++)
            {
                string[] words = sentences[i].Split(separators);
                smallestWords[i] = words[0];
                for (int j = 1; j < words.Length; j++)
                {
                    if (words[j].Length < smallestWords[i].Length && words[j].Length!= 0)
                    {
                        smallestWords[i] = words[j];
                    }
                }
            }
            return smallestWords;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return text;
        }

        #endregion
    }
}
