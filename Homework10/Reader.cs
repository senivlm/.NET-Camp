using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10
{
    class Reader
    {
        public static List<string> ReadText(string fileName)
        {
            List<string> result = new();            
            using(StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    result.Add(reader.ReadLine());
                }               
            }
            return result;
        }

        public static Dictionary<string, string> ReadDictionary(string fileName)
        {
            Dictionary<string, string> result = new();
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Dictionary isn`t found");
            }
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    try
                    {
                        var str = temp.Split('-');
                        if (str.Length != 2)
                        {
                            throw new ArgumentException("Incorrect pair of key - value");
                        }
                        result.Add(str[0], str[1]);                         
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }
                }
            }
            return result;
        }

        public static void WriteToDictionary( string key, string value, string fileName)
        {
            using(StreamWriter writer = File.AppendText(fileName))
            {
                writer.Write("\n");
                writer.Write($"{key}-{value}");
            }
        }
    }
}
