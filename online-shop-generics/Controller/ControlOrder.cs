using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using generics_collection;

namespace online_shop_generics.Controller
{
    public class ControlOrder
    {
        private ILista<Order> orders;

        public ControlOrder()
        {
            orders = new Lista<Order>();
        }

        public void deleteList()
        {
            for (int i = 0; i < orders.dimensiune(); i++)
                orders.stergere(0);
        }

        public void load()
        {
            this.deleteList();
            string path = @"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\orderFile.txt";
            StreamReader fisier = new StreamReader(path);
            string linie = "";
            while ((linie = fisier.ReadLine()) != null)
            {
                string[] linieSplit = linie.Split(',');
                orders.adaugare(new Order(linieSplit));
            }
            fisier.Close();
        }


        public void save()
        {
            string path = @"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\orderFile.txt";
            StreamWriter fisier = new StreamWriter(path);
            for (int i = 0; i < orders.dimensiune(); i++)
                fisier.WriteLine(orders.obtine(i).Data.ToString());
            fisier.Close();
        }


        public string afisare()
        {
            return orders.afisare();
        }

        public void adaugare(Order order)
        {
            this.orders.adaugare(order);
        }
        public void stergere(int id)
        {
            this.orders.stergere(orderId(id));
        }


        public void updateOrderAdress(int id, string orderAdressNou)
        {
            orders.obtine(orderId(id)).Data.Order_Address = orderAdressNou;
        }
        public void updateAmmount(int id, int ammountNou)
        {
            orders.obtine(orderId(id)).Data.Ammount = ammountNou;
        }


        public int orderId(int id)
        {
            int k = 0;
            for (int i = 0; i < orders.dimensiune(); i++)
                if (orders.obtine(i).Data.Id == id) return k;
                else k++;
            return -1;
        }
        public Order orderObjectId(int id)
        {
            for (int i = 0; i < orders.dimensiune(); i++)
                if (orders.obtine(i).Data.Id.Equals(id) == true)
                    return orders.obtine(i).Data;
            return null;
        }
        public ILista<Order> Order
        {
            get => this.orders;
            set => this.orders = value;
        }
        public Order orderAcc(int customer_id)
        {
            for (int i = 0; i < orders.dimensiune(); i++)
                if (orders.obtine(i).Data.Custormer_id.Equals(customer_id) == true)
                    return orders.obtine(i).Data;
            return null;
        }

        public Order orderMax(int customer_id)
        {
            int maxim = -1;
            for (int i = 0; i < orders.dimensiune(); i++)
                if (orders.obtine(i).Data.Custormer_id.Equals(customer_id) == true)
                    if (maxim < this.Order.obtine(i).Data.Id)
                        maxim = this.Order.obtine(i).Data.Id;
            return this.orderObjectId(maxim);
        }



        public int nextId()
        {
            if (this.orders.dimensiune() > 0)
                return this.orders.obtine(this.orders.dimensiune() - 1).Data.Id + 1;
            else
                return 1;
        }
    }
}
