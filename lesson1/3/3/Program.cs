using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                N = 1,
                Expected = 1,
                ExpectedException = null
            };
            var testCase2 = new TestCase()
            {
                N = 2,
                Expected = 1,
                ExpectedException = null
            };
            var testCase3 = new TestCase()
            {
                N = 3,
                Expected = 2,
                ExpectedException = null
            };
            var testCase4 = new TestCase()
            {
                N = 15,
                Expected = 610,
                ExpectedException = null
            };
            var testCase5 = new TestCase()
            {
                N = -1,
                Expected = 1,
                ExpectedException = new ArgumentException()
            };
            TestFibonacciNumbers(testCase1);
            TestFibonacciNumbers(testCase2);
            TestFibonacciNumbers(testCase3);
            TestFibonacciNumbers(testCase4);
            TestFibonacciNumbers(testCase5);
            TestFibonacci(testCase1);
            TestFibonacci(testCase2);
            TestFibonacci(testCase3);
            TestFibonacci(testCase4);
            TestFibonacci(testCase5);
        }
        //было в предыдущем курсе
        static long FibonacciNumbers(int n)
        {
            if (n < 0)
                throw new ArgumentException("n must be positive");
            if (n == 0 || n == 1)
                return n;
            else
                return FibonacciNumbers(n - 1) + FibonacciNumbers(n - 2);
        }

        static long Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            for (; n > 1; n--)
            {
                int t = b;
                b += a;
                a = t;
            }
            return b;
        }
        public class TestCase
        {
            public int N { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static void TestFibonacciNumbers(TestCase testCase)
        {
            try
            {
                var actual = FibonacciNumbers(testCase.N);
                if (actual == testCase.Expected)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST ",ex);
                }
                else
                {
                    Console.WriteLine("INVALID TEST ",ex);
                }

            }
        }
        static void TestFibonacci(TestCase testCase)
        {
            try
            {
                var actual = Fibonacci(testCase.N);
                if (actual == testCase.Expected)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    Console.WriteLine("VALID TEST ", ex);
                }
                else
                {
                    Console.WriteLine("INVALID TEST ", ex);
                }

            }
        }
    }
}