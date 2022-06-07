using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5
{
    class VectorIO
    {
//Ідея правильна. молодець. Але треба пічищати деталі.
        public static string ReadArrayStringFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
          // Бажано працювати з колекцією стрічок, а не однією.
            
            string line = sr.ReadLine();
            sr.Close();
            return line;
        }

        public static void WriteSortedArrayToFile(string result, string fileName)
        {
            StreamWriter sw = new StreamWriter(fileName, false);
            sw.WriteLine(result);
            sw.Close();
        }
    }
}
