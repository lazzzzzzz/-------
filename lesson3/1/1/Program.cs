using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Columns;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ManualConfig()
        .WithOptions(ConfigOptions.DisableOptimizationsValidator)
        .AddValidator(JitOptimizationsValidator.DontFailOnError)
        .AddLogger(ConsoleLogger.Default)
        .AddColumnProvider(DefaultColumnProviders.Instance);
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly,config);
        }
    }
    public class PointClass
    {
        public float X;
        public float Y;
    }

    public struct PointStruct
    {
        public float X;
        public float Y;
    }
    public struct PointStruct1
    {
        public double X;
        public double Y;
    }

    public class BenchmarkClass
    {
        public int SumValueType(int value)
        {
            return 9 + value;
        }

        public int SumRefType(object value)
        {
            return 9 + (int)value;
        }
        public double PointDistanceDouble(PointStruct1 pointOne, PointStruct1 pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }


        [Benchmark]
        public void TestClass()
        {
            var a = new Random();
            var point1 = new PointClass { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            var point2 = new PointClass { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            PointDistanceClass(point1, point2);
        }

        [Benchmark]
        public void TestStructFloat()
        {
            var a = new Random();
            var point1 = new PointStruct { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            var point2 = new PointStruct { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            PointDistanceStruct(point1, point2);
        }
        [Benchmark]
        public void TestStructDouble()
        {
            var a = new Random();
            var point1 = new PointStruct1 { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            var point2 = new PointStruct1 { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            PointDistanceDouble(point1, point2);
        }
        [Benchmark]
        public void TestStructShort()
        {
            var a = new Random();
            var point1 = new PointStruct { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            var point2 = new PointStruct { X = a.Next(0, 1000000) / 3, Y = a.Next(0, 1000000) / 3 };
            PointDistanceShort(point1, point2);
        }

    }

}
