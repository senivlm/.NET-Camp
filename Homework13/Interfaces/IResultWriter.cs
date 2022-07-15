using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13.Interfaces
{
    internal interface IResultWriter
    {
        void WritePerson(List<string> calculateExpressions,
            string filePath = @"..\..\Files\Result.txt");
    }
}
