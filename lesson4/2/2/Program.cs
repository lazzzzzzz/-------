using System;
using System.Collections.Generic;
namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 0 };
            var a = new TreeNode { Value = 4 };
            for (int i = 0; i < arr.Length; i++)
            {
                a.AddItem(arr[i]);
            }
            a.RemoveItem(4);
            a.PrintTree();
            Console.WriteLine("\n"+a.GetNodeByValue(7).Value);
        }
    }
    public class TreeNode : ITree
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

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }

        public TreeNode GetNodeByValue(int value)
        {
            var a = this;
            if (a.Value == value)
                return a;
            if (value > a.Value)
                if (RightChild == null)
                    return null;
                else return a.RightChild.GetNodeByValue(value);
            else
                if (LeftChild == null)
                return null;
            else return a.LeftChild.GetNodeByValue(value);
        }

        public TreeNode GetRoot()
        {
            return this;
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

        public void RemoveItem(int value)
        {
            var a = this;
            if (a.Value < value)
            {
                if (a.RightChild != null)
                    if (a.RightChild.Value == value)
                        a.RightChild = null;
                    else a.RightChild.RemoveItem(value);
            }
            else
                if (a.LeftChild != null)
                if (a.LeftChild.Value == value)
                    a.LeftChild = null;
                else a.LeftChild.RemoveItem(value);
        }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);

                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }

            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }

}
