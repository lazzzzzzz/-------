using System;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[512];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i*2+1;
            }
            Console.WriteLine(BinarySearch(arr,1001));
        }
        /*сложность:
         * length/2^n= 1
         * length=2^n
         * log2(L)=log2(2^n)
         * log2(L)=n*log2(2)=n
         * О(log2(L))
         */
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }


    }
}
