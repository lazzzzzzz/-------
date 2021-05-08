using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class Node : ILinkedList
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public void AddNode(int value)
        {
            var node = this;

            while (node.NextNode != null)
            {
                node = node.NextNode;
            }
            var newNode = new Node { Value = value };
            node.NextNode = newNode;
            newNode.PrevNode = node;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            newNode.NextNode = node.NextNode;
            newNode.PrevNode = node;
            node.NextNode = newNode;
            if (newNode.NextNode!=null)
            {
                var nextNode = newNode.NextNode;
                nextNode.PrevNode = newNode;
            }
        }

        public Node FindNode(int searchValue)
        {
            var node = this;
            while(node.NextNode!=null)
            {
                if (node.Value == searchValue)
                    return node;
                node = node.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            var node = this;
            int i = 1;
            while (node.NextNode != null)
            {
                i++;
                node = node.NextNode;
            }
            return i;
        }

        public void RemoveNode(int index)
        {
            var node = this;
            for (int i=0;i<index;i++)
            {
                if (node.NextNode == null)
                    throw new ArgumentOutOfRangeException();
                node = node.NextNode;
            }
            RemoveNode(node);
        }

        public void RemoveNode(Node node)
        {
            Node _node;
            if(node.PrevNode!=null)
            {
                _node = node.PrevNode;
                _node.NextNode = node.NextNode;
            }
            if(node.NextNode!=null)
            {
                _node = node.NextNode;
                _node.PrevNode = node.PrevNode;
            }
        }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

}
