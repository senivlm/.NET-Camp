﻿using System;
using System.IO;

namespace Homework4
{
    class Vector
    { // Ваш номер 8.
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
                if(arr[i] < arr[j])
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
                while(i < q)
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
            }
            for (int l = 0; l < temp.Length; l++)
            {
                arr[l+left] = temp[l];
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
            // Має бути SplitMergeSort(middle+1, end); 
            SplitMergeSort(middle, end);
            Merge(start, end, middle);
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
