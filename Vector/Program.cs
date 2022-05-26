using System;

namespace Vector
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

            //matrix.InputSizeOfMatrix();
            //matrix.RandomInitialization();
            //matrix.VerticalSnakeInitialization();
            matrix.DiagonalSnakeAutorization(3, Way.Right);
            Console.WriteLine(matrix);
            Console.WriteLine();

            var matrix1 = new Matrix();
            matrix1.DiagonalSnakeAutorization(4, Way.Down);
            Console.WriteLine(matrix1);
        }
        static void Main(string[] args)
        {
            //WorkWithMatrixClass();

            Vector vector = new Vector(7);
            vector.RandomInitialization(1, 10);
            vector.Counting();
            Console.WriteLine(vector);

           
        }
    }
}
