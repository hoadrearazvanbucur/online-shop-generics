using System;
using System.Collections.Generic;
using System.Text;

namespace generics_collection
{
    public class Lista<T> : ILista<T> where T : IComparable<T>
    {
        private Node<T> head = null;

        public void adaugare(T data)
        {
            if (head == null)
            {
                Node<T> n = new Node<T>();
                n.Data = data;
                n.Next = null;
                this.head = n;
            }
            else
            {
                Node<T> n = new Node<T>();
                Node<T> iterator = head;
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = n;
                n.Next = null;
                n.Data = data;
            }
        }

        public void stergere(int index)
        {
            Node<T> save = head;
            int k = 0;
            if (index < dimensiune() && index > 0)
            {
                while (k < index - 1)
                {
                    save = save.Next;
                    k++;
                }
                save.Next = save.Next.Next;
            }
            else if (index == dimensiune())
                save = null;
            else if (index == 0)
                head = save.Next;
        }
        public void stergere(T data)
        {
            Node<T> save = head;
            int k = 0;
            while (save != null)
            {
                if (save.Data.ToString() == data.ToString())
                    break;
                k++;
                save = save.Next;
            }
            stergere(k);
        }

        public Node<T> obtine(int index)
        {
            Node<T> save = head;
            int k = 0;
            while (save != null)
            {
                if (k == index)
                    return save;
                save = save.Next;
                k++;
            }
            return null;
        }
        public void seteaza(T data, int index)
        {
            Node<T> save = head;
            int k = 0;
            if (index != 0)
            {
                while (k < index - 1)
                {
                    save = save.Next;
                    k++;
                }
                Node<T> m = new Node<T>();
                m.Data = data;
                m.Next = save.Next;
                save.Next = m;
            }
            else
            {
                Node<T> m = new Node<T>();
                m.Data = data;
                m.Next = save;
                head = m;
            }
        }

        public int pozitieData(T data)
        {

            Node<T> save = head;
            int k = 0;
            while (save != null)
            {
                if (save.Data.Equals(data))
                    return k;
                k++;
                save = save.Next;
            }
            return -1;
        }

        public bool exista(T data)
        {
            Node<T> save = head;
            while (save != null)
            {
                if (save.Data.ToString() == data.ToString())
                    return true;
                save = save.Next;
            }
            return false;
        }
        public bool listaGoala()
        {
            if (this.head == null)
                return true;
            return false;
        }
        public int dimensiune()
        {
            int k = 0;
            Node<T> save = head;
            while (save != null)
            {
                k++;
                save = save.Next;
            }
            return k;
        }
        public string afisare()
        {
            Node<T> save = this.head;
            string text = "";
            while (save != null)
            {
                text += save.Data.ToString() + "\n";
                save = save.Next;
            }
            return text;
        }

    }
}
