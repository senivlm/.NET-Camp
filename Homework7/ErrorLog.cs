using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    class ErrorLog
    {//Не побачила роботи з датами!
        private readonly string fileName = "errorLog.txt";
        private StreamWriter writer;

        public ErrorLog()
        {
            //writer = new StreamWriter(fileName, true);
        }

        public void WriteErrorToLog(string error)
        {
            using(writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(error);
            }
            
        }

        public void ClearLog()
        {
            File.WriteAllText(fileName, String.Empty);
        }
    }
}
