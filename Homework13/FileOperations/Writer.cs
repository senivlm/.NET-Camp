using Homework13.Data;
using Homework13.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13.FileOperations
{
    internal class Writer
    {
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set
            {
                if (value != null) filePath = value;
            }
        }

        public Writer(string filePath = "../../../Files/Persons.txt")
        {
            this.filePath = filePath;
        }

        public void WritePerson(Person person, string filePath = "../../../Files/Persons.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                sw.WriteLine(person.ToString());
                sw.Close();
            }
        }
    }
}
