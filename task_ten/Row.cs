using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_ten
{
    public class Row : IEnumerable
    {
        static Random rand = new Random();
        Node head;

        public Row()
        {
            head = null;
            Count = 0;
        }

        public Row(double element)
        {
            Count = 1;
            head = new Node(element);
        }

        public Row(int capasity) // сучайное заполнение
        {
            Count = capasity;
            int i = 0;
            head = new Node(rand.Next(-100, 100) + rand.Next(-10, 10) / 10);
            Node current = head;
            while (i < capasity - 1)
            {
                current.next = new Node(rand.Next(-100, 100));
                current = current.next;
                i++;
            }
        }

        public double this[int index]
        {
            get
            {
                double[] item = this.ToArray();
                return item[index];
            }
            set
            {
                double[] item = this.ToArray();
                item[index] = value;
                this.Clear();
                foreach (int t in item)
                {
                    this.Add(t);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.next;
            }
        }

        public void Add(double element)
        {
            Node node = new Node(element);
            if (head == null) head = node;
            else
            {
                Node current = head;
                while (current.next != null) current = current.next;
                current.next = node;
            }
            Count++;
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public double[] ToArray()
        {
            Node current = head;
            double[] array = new double[this.Count];
            int i = 0;
            while (current != null)
            {
                array[i] = current.Value;
                i++;
                current = current.next;
            }
            return array;
        }

        public int Count { get; private set; }
    }

    internal class Node
    {
        internal double item;
        internal Node next;

        public Node()
        {
            item = 0;
            next = null;
        }

        public Node(double element)
        {
            item = element;
            next = null;
        }

        public double Value
        {
            get { return item; }
        }

        public override string ToString()
        {
            return item.ToString();
        }
    }
}
