using System;
using System.Collections.Generic;
namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            //граф из методички
            node1.AddEdges(node2);
            node1.AddEdges(node5);
            node2.AddEdges(node3);
            node2.AddEdges(node6);
            node3.AddEdges(node4);
            node3.AddEdges(node6);
            node4.AddEdges(node5);
            node5.AddEdges(node6);
            var arr1 = node1.BFS();
            for(int i=0;i<arr1.Length;i++)
            {
                Console.Write(arr1[i].Value+" ");
            }
            Console.WriteLine();
            var arr2 = node1.DFS(new List<Node>());
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i].Value + " ");
            }
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public List<Node> Edges { get; set; }
        public Node(int _Value)
        {
            Value = _Value;
            Edges = new List<Node>();
        }
        public Node AddEdges(Node node)
        {
            Edges.Add(node);
            node.Edges.Add(this);
            return this;
        }
        public Node[] BFS()
        {
            Queue<Node> queue = new Queue<Node>();
            List<Node> completes = new List<Node>();
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                completes.Add(node);
                foreach (var e in node.Edges)
                    if (!completes.Contains(e)&&!queue.Contains(e))
                        queue.Enqueue(e);
            }
            return completes.ToArray();
        }

        public Node[] DFS(List<Node> completes)
        {
            var stack = new Stack<Node>();
            stack.Push(this);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                completes.Add(node);
                foreach (var e in node.Edges)
                {
                    if (!completes.Contains(e))
                        e.DFS(completes);
                }
            }

            return completes.ToArray();
        }
    }

}
