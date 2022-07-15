using Homework13.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13.FileOperations
{
    internal class Reader : IExpresionReader
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set 
            { 
                if(value != null) filePath = value;
            }
        }


        public Reader(string filePath = "../../../Files/Persons.txt")
        {
            this.filePath = filePath;
        }

        public List<string> ReadExpresion(string filePath = "../../../Files/Persons.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            List<string> result = new();
            using (StreamReader sr = new(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
                sr.Close();
            }

            return result;
        }
    }
}
