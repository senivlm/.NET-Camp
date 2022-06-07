using System;
using System.IO;

namespace Homework5
{
    /// <summary>
    /// This class was created for homework5
    /// All extra methods were deleted
    /// </summary>
    class Vector
    {
        int[] arr;

        public int this[int index]
        {
            get
            { 
                if(index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set 
            {
                arr[index] = value;
            }
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
        }

        public Vector(int n)
        {
            arr = new int[n];
        }

        public Vector() { }

        public static void Merge(int[] arr_, int left, int right, int q)
        {
            int i = left;
            int j = q;
            int[] temp = new int[right - left];
            int k = 0;
            while (i < q && j < right)
            {
                if (arr_[i] < arr_[j])
                {
                    temp[k] = arr_[i];
                    i++;
                }
                else
                {
                    temp[k] = arr_[j];
                    j++;
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < right; m++)
                {
                    temp[k] = arr_[m];
                    k++;
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k] = arr_[i];
                    i++;
                    k++;
                }
            }
            for (int l = 0; l < temp.Length; l++)
            {
                arr_[l + left] = temp[l];
            }
        }

        public static void SplitMergeSort(int[] arr_, int start, int end)
        {
            if (end - start <= 1)
            {
                return;
            }
            int middle = (end + start) / 2;
            SplitMergeSort(arr_, start, middle);
            SplitMergeSort(arr_, middle, end);
            Merge(arr_, start, end, middle);
        }

        public void MergeSortFile(string fileName)
        {
            string line = VectorIO.ReadArrayStringFromFile(fileName);

            int count = line.Split(' ').Length;
            int avg = count / 2;
            //Не можна 2 одночасно масиви створювати. Умова, що не вистачає оперативки. Можна користуватись тільки одним половинним.
            int[] array1 = new int[avg];
            int[] array2;
            if (count%2 == 0)
            {
                array2 = new int[avg];
            }
            else
            {
                array2 = new int[avg + 1];
            }

            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = Convert.ToInt32(line.Split(' ')[i]);
            }
            SplitMergeSort(array1, 0, array1.Length);
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = Convert.ToInt32(line.Split(' ')[avg + i]);
                
            }
            SplitMergeSort(array2, 0, array2.Length);

            int i1 = 0, j1 = 0;
            int k = 0;
            string result = "";
            while(k!= count)
            {
                if(i1 == array1.Length || array1[i1] > array2[j1])
                {
                    result += array2[j1] + " ";
                    j1++;
                    k++;
                }
                else if(j1 == array2.Length || array1[i1] <= array2[j1])
                {
                    result += array1[i1] + " ";
                    i1++;
                    k++;
                }  
            }
            VectorIO.WriteSortedArrayToFile(result, "sortedArray.txt");
        }

        public void HeapSort()
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(n, i);
            }
            for (int i = n - 1; i > 0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                Heapify(i, 0);
            }
        }

        public void Heapify(int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                int item = arr[i];
                arr[i] = arr[largest];
                arr[largest] = item;
                Heapify(n, largest);
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }
    }
}
