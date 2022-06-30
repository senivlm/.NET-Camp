using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10
{
    class WordNotFoundException : Exception
    {
        public WordNotFoundException() : base()
        {
        }

        public WordNotFoundException(string message) : base(message)
        {
        }
    }
}
