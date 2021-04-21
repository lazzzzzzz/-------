using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsSimple(5).Equals("Простое"));
            Console.WriteLine(IsSimple(2).Equals("Простое"));
            Console.WriteLine(IsSimple(6).Equals("Не простое"));
            Console.WriteLine(IsSimple(7).Equals("Простое"));
            Console.WriteLine(IsSimple(1437562).Equals("Не простое"));
        }


        public static string IsSimple(int n)
        {
            int d = 0, i = 2;
            while(i<n)
            {
                if(n % i==0)
                    d++;
                i++;
            }
            if(d==0)
                return "Простое";
            return "Не простое";
        }
    }
}
