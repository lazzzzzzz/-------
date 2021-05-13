using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 1, 4, 7, 1, 3, 7, 8, 6, 2, 4 };
            var arr1 = BucketSort(arr);
            for (int i = 0; i < arr1.Length; i++)
                Console.WriteLine(arr1[i]);
        }

        static int[] BucketSort(int[] arr)
        {
            int n = 5;
            int max = arr.Max();
            int min = arr.Min();
            List<int>[] list = new List<int>[n];
            List<int> result=new List<int>();
            for (int i = 0; i < list.Length; i++)
                list[i] = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list[(int)(arr[i] - min) / n].Add(arr[i]);
            }
            for (int i = 0; i < list.Length; i++)
            {
                list[i].Sort();
                for (int j = 0; j < list[i].Count; j++)
                    result.Add(list[i][j]);
            }
            return result.ToArray();
        }
    }
}
