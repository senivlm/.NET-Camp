using System;
using System.IO;

namespace Vector
{
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

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public void RandomInitialization()
        {
            Random random = new Random();
            int x;
            for (int i = 0; i < arr.Length; i++)
            {
                while(arr[i] == 0)
                {
                    x = random.Next(1, arr.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == arr[j])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        arr[i] = x;
                        break;
                    }
                }
            }
        }

        public Pair[] CalculateFreq()
        {
            
            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0,0);

            }
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if(arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public bool IsPalindrome()
        {
            bool result = false;
            int count = 0;
            int j = arr.Length - 1;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if(arr[i] == arr[j]) count++;
                j--;
            }
            if (count == arr.Length / 2) result = true;
            return result;
        }
        
        public Pair LongestSequenceOfIdenticalNumbers()
        {
            Pair[] pairs = new Pair[arr.Length];
            for (int j = 0; j < arr.Length; j++)
            {
                pairs[j] = new Pair(0, 0);
            }
            int count;
            int i = 0;
            while (i < arr.Length)
            {
                count = 1;
                while (arr[i] == arr[i + 1])
                {
                    count++;
                    i++;
                    if (i >= arr.Length - 1) break;
                }
                pairs[i].Number = arr[i];
                pairs[i].Freq = count;
                i++;
            }

            Pair resultPair = new Pair(0, 0);
            for (int j = 0; j < pairs.Length; j++)
            {
                if (pairs[j].Freq > resultPair.Freq)
                {
                    resultPair.Number = pairs[j].Number;
                    resultPair.Freq = pairs[j].Freq;
                }
            }

            return resultPair;
        }

        public void Merge(int left, int right, int q)
        {
            int i = left;
            int j = q;
            int[] temp = new int[right - left];
            int k = 0;
            while (i < q && j < right)
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < right; m++)
                {
                    temp[k] = arr[m];
                    k++;
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
            }
            for (int l = 0; l < temp.Length; l++)
            {
                arr[l + left] = temp[l];
            }
        }

        public void SplitMergeSort(int start, int end)
        {
            if(end - start <= 1)
            {
                return;
            }
            int middle = (end + start) / 2;
            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);
            Merge(start, end, middle);
        }

        //для вхідного масиву
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

        //для вхідного масиву
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



        public void Bubble()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if(arr[j+1] > arr[j])
                    {
                        int item = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = item;
                    }
                }
            }
        }

        public void QuickSort(int minIndex, int maxIndex)
        {
            if(minIndex < maxIndex)
            {
                int pivot = minIndex - 1;
                for (int i = minIndex; i < maxIndex; i++)
                {
                    if (arr[i] < arr[maxIndex])
                    {
                        pivot++;
                        int temp = arr[pivot];
                        arr[pivot] = arr[i];
                        arr[i] = temp;
                    }
                }

                pivot++;
                int temp1 = arr[pivot];
                arr[pivot] = arr[maxIndex];
                arr[maxIndex] = temp1;

                QuickSort(minIndex, pivot - 1);
                QuickSort(pivot + 1, maxIndex);
            }
        }

        public void Counting()
        {
            int max = arr[0];
            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if(arr[i] < min)
                {
                    min = arr[i];
                }
            }

            int[] temp = new int[max - min + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                temp[arr[i] - min]++;
            }
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i]; j++)
                {
                    arr[k] = i + min;
                    k++;
                }
            }
        }

        public void Reversal()
        {
            int[] resultArr = new int[arr.Length];
            int j = arr.Length - 1;
            for (int i = 0; i < arr.Length; i++)
            {
                resultArr[i] = arr[j];
                j--;
            }
            arr = resultArr;
        }

        public void MergeSortFile(string fileName)
        {
            string line = VectorIO.ReadArrayStringFromFile(fileName);

            int count = line.Split(' ').Length;
            int avg = count / 2;
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
