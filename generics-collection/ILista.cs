using System;
using System.Collections.Generic;
using System.Text;

namespace generics_collection
{
    public interface ILista<T>
    {
        void adaugare(T data);
        void stergere(int index);
        void stergere(T data);
        bool exista(T data);
        bool listaGoala();
        int pozitieData(T data);
        int dimensiune();
        Node<T> obtine(int index);
        void seteaza(T data, int index);
        string afisare();
    }
}
