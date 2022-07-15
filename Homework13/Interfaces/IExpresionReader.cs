using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13.Interfaces
{
    internal interface IExpresionReader
    {
        List<string> ReadExpresion(string filePath);
    }
}
