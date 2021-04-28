using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var arr = new string[10000000];
            var hashSet = new HashSet<string>();
            RandomizeElements(arr,hashSet);
            sw.Start();
            FindArr(arr, "1");
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
            sw.Restart();
            FindHash(hashSet, "1");
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }

        static void RandomizeElements(string[] arr, HashSet<string> hashSet)
        {
            var random = new Random();
            var stringbuild = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < random.Next(1, 200); j++)
                    stringbuild.Append((char)random.Next(0x0041, 0x005B));
                arr[i] = stringbuild.ToString();
                hashSet.Add(arr[i]);
                stringbuild.Clear();
            }
        }

        static bool FindArr(string[] arr, string element)
        {
            return Array.Exists(arr, e=>e==element);
        }
        static bool FindHash(HashSet<string> hashSet, string element)
        { 
            return hashSet.Contains(element);
        }
    }
}
