using System;
using System.Collections.Generic;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 3, 1, 6, 4, 7, 10, 14, 13, 9 };
            var tree = new TreeNode { Value = 8 };
            for (int i = 0; i < arr.Length; i++)
                tree.AddItem(arr[i]);
            tree.PrintTree();
            Console.WriteLine();
            var bfs = tree.BFS();
            for (int i = 0; i < bfs.Length; i++)
                Console.Write(bfs[i].Value);
            var dfs = tree.DFS();
            Console.WriteLine();
            for (int i = 0; i < dfs.Length; i++)
                Console.Write(dfs[i].Value);
        }
    }
    public class TreeNode 
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

        public void AddItem(int value)
        {
            var a = this;
            if (value > a.Value)
                if (RightChild == null)
                    RightChild = new TreeNode { Value = value };
                else a.RightChild.AddItem(value);
            else
                if (LeftChild == null)
                LeftChild = new TreeNode { Value = value };
            else a.LeftChild.AddItem(value);
        }

        public void PrintTree()
        {
            if (this != null)
            {
                Console.Write('(');
                Console.Write(Value);
                if (RightChild != null || LeftChild != null)
                {
                    if (LeftChild != null)
                        LeftChild.PrintTree();
                    Console.Write(',');
                    if (RightChild != null)
                        RightChild.PrintTree();
                }
                Console.Write(')');
            }
        }

        public TreeNode[] BFS()
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<TreeNode> nodes = new List<TreeNode>();
            queue.Enqueue(this);
            while(queue.Count!=0)
            {
                var node = queue.Dequeue();
                nodes.Add(node);
                if (node.LeftChild != null)
                    queue.Enqueue(node.LeftChild) ;
                if (node.RightChild != null)
                    queue.Enqueue(node.RightChild);
            }
                
            return nodes.ToArray();
        }

        public TreeNode[] DFS()
        {
            var stack = new Stack<TreeNode>();
            var nodes = new List<TreeNode>();
            stack.Push(this);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                nodes.Add(node);
                if (node.RightChild != null)
                    stack.Push(node.RightChild);
                if (node.LeftChild != null)
                    stack.Push(node.LeftChild);
            }

            return nodes.ToArray();
        }
    }
}
