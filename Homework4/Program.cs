using System;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 100, 6, 2, 7, 1, 4, 8, 10, 4, 4, 99, 9 };
            Vector vector = new Vector(arr);
            Console.WriteLine(vector);
//Не побачила реалізації для великого файлу
            //vector.QuickSort(0, arr.Length - 1);
            vector.SplitMergeSort(0, arr.Length);
            Console.WriteLine(vector);
        }
    }
}
