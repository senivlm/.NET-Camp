using System;

namespace Homework3
{
    class Program
    {
        public static void WorkWithVectorClass()
        {
            //int[] arr = new int[] { 1, 1, 2, 2, 2 };
            int[] arr = new int[] { 1, 1, 1, 2, 3, 3, 5, 6, 6, 6, 6, 6 };
            //Array.Reverse(arr);
            //vector.Reversal();
            Vector vector = new Vector(arr);
            Console.WriteLine(vector);
            //Console.WriteLine(vector.IsPalindrome());

            Pair pair = vector.LongestSequenceOfIdenticalNumbers();
            Console.WriteLine(pair);
        }

        public static void WorkWithMatrixClass()
        {
            var matrix = new Matrix();
            matrix.DiagonalSnakeAutorization(3, Way.Right);
            Console.WriteLine(matrix);
            Console.WriteLine();

            var matrix1 = new Matrix();
            matrix1.DiagonalSnakeAutorization(4, Way.Down);
            Console.WriteLine(matrix1);
        }

        static void Main(string[] args)
        {
            WorkWithMatrixClass();
        }
    }
}
