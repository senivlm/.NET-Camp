using System;

namespace Homework2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            matrix.DiagonalSnakeAutorization(5);
            Console.WriteLine(matrix);

            //Matrix m = new Matrix();
            //m.InputSizeOfMatrix();
            //m.VerticalSnakeInitialization();
            //m.RandomInitialization();
            //m.Input();
            //Console.WriteLine(m);

        }
    }
}
