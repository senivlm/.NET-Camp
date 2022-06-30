using System;

namespace Homework10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[3, 3]
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {7, 8, 9 }
            };
            Matrix myMatrix  = new Matrix(mat);
            Console.WriteLine(myMatrix);
            Console.WriteLine("Horizontal snake:");
            foreach (var item in myMatrix)
            {
                 Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Diagonal snake:");
            try
            {
                foreach (var item in myMatrix.GetEnumeratorDiagonalSnake(Way.Right))
                {
                    Console.Write(item + " ");
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
