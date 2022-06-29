using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_2
{
    class WebSiteUserReader
    {
        StreamReader reader;
        private List<WebSiteUser> users;

        public WebSiteUserReader(string fileName)
        {
            if (File.Exists(fileName))
            {
                users = new();
                reader = new StreamReader(fileName);
                while (!reader.EndOfStream)
                {
                    Parse(reader.ReadLine());
                }
            }
            else
            {
                throw new FileNotFoundException($"File \"{fileName}\" is not found");
            }
        }

        internal List<WebSiteUser> Users { get => users; }

        private void Parse(string line)
        {
            string[] items = line.Split(' ');
            string exceptions = "";
            DateTime time = default;
            DayOfWeek day = default;
            if (items.Length != 3)
            {
                exceptions += "Incorrect amount of data in the line: " + line + "\n";
            }
            else
            {               
                if(!DateTime.TryParse(items[1], out time))
                {
                    exceptions += "Incorrect time format\n";
                }
                if(!Enum.TryParse(items[2].Substring(0, 1).ToUpper() + items[2].Substring(1).ToLower(), out day))
                {
                    exceptions += "Incorest day format\n";
                }
            }
            if(exceptions.Length != 0)
            {
                throw new ArgumentException(exceptions.TrimEnd('\n'));
            }
            else
            {
                users.Add(new WebSiteUser(items[0], time, day));
            }
        }
    }
}
