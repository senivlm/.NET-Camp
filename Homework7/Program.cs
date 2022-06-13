using System;
using System.Collections.Generic;

namespace Homework7
{
    class Program
    {
        static void Main(string[] args)
        {
            ErrorLog log = new ErrorLog();
            log.ClearLog();
            Storage storage = new Storage();
            storage.ReadProductsFromFile("file.txt");
            storage.PrintAllInfoAboutProducts();
        }
    }
}
