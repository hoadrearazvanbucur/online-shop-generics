using System;
using System.Collections.Generic;
using System.Text;

namespace generics_collection
{
    class Node
    {
        private T data;
        private Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }

        public Node() { }

        public T Data
        {
            get => this.data;
            set => this.data = value;
        }
        public Node<T> Next
        {
            get => this.next;
            set => this.next = value;
        }
    }
}
