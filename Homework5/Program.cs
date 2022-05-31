using System;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector = new Vector();
            vector.MergeSortFile("file.txt");
            Console.WriteLine(VectorIO.ReadArrayStringFromFile("file.txt"));
            Console.WriteLine(VectorIO.ReadArrayStringFromFile("sortedArray.txt"));
        }
    }
}
