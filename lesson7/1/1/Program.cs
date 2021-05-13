using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 15;
            int length = 15;
            Console.WriteLine(Calculate(length,width,new Node()));
        }

        static int Calculate(int length, int width, Node node)
        {
            int x = node.X;
            int y = node.Y;
            if (x < length - 1)
            {
                node.Y = y;
                node.X = x + 1;
                Calculate(length, width, node);
            }
            if (y < width - 1)
            {
                node.X = x;
                node.Y = y + 1;
                Calculate(length, width, node);
            }
            if (x == length-1 && y == width-1)
                node.path++;
            return node.path;
        }
    }

    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int path { get; set; }
    }
}
