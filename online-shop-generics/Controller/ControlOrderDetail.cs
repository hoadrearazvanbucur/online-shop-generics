using generics_collection;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace online_shop_generics.Controller
{
    public class ControlOrderDetail
    {
        private ILista<OrderDetail> orderDetails;

        public ControlOrderDetail()
        {
            orderDetails = new Lista<OrderDetail>();
        }

        public void deleteList()
        {
            for (int i = 0; i < orderDetails.dimensiune(); i++)
                orderDetails.stergere(0);
        }

        public void load()
        {
            this.deleteList();
            string path = @"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\orderDetailFile.txt";
            StreamReader fisier = new StreamReader(path);
            string linie = "";
            while ((linie = fisier.ReadLine()) != null)
            {
                string[] linieSplit = linie.Split(',');
                orderDetails.adaugare(new OrderDetail(linieSplit));
            }
            fisier.Close();
        }


        public void save()
        {
            string path = @"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\orderDetailFile.txt";
            StreamWriter fisier = new StreamWriter(path);
            for (int i = 0; i < orderDetails.dimensiune(); i++)
                fisier.WriteLine(orderDetails.obtine(i).Data.ToString());
            fisier.Close();
        }


        public string afisare()
        {
            return orderDetails.afisare();
        }

        public void adaugare(OrderDetail orderDetail)
        {
            this.orderDetails.adaugare(orderDetail);
        }
        public void stergere(int id)
        {
            this.orderDetails.stergere(orderDetailId(id));
        }


        public void updateQuantity(int id, int quantityNou)
        {
            orderDetails.obtine(orderDetailId(id)).Data.Quantity = quantityNou;
        }
        public void updatePrice(int id, double priceNou)
        {
            orderDetails.obtine(orderDetailId(id)).Data.Price = priceNou;
        }

        public ILista<OrderDetail> OrderDetail
        {
            get => this.orderDetails;
            set => this.orderDetails = value;
        }
        public int orderDetailId(int id)
        {
            int k = 0;
            for (int i = 0; i < orderDetails.dimensiune(); i++)
                if (orderDetails.obtine(i).Data.Id == id) return k;
                else k++;
            return -1;
        }
        public OrderDetail orderDetailObjectId(int id)
        {
            for (int i = 0; i < orderDetails.dimensiune(); i++)
                if (orderDetails.obtine(i).Data.Id.Equals(id) == true)
                    return orderDetails.obtine(i).Data;
            return null;
        }


        public ILista<OrderDetail> orderListId(int orderId)
        {
            ILista<OrderDetail> list = new Lista<OrderDetail>();
            for (int i = 0; i < orderDetails.dimensiune(); i++)
            {
                if (orderDetails.obtine(i).Data.Order_id.Equals(orderId) == true)
                    list.adaugare(orderDetails.obtine(i).Data);
            }
            return list;
        }


        public int nextId()
        {
            if (this.orderDetails.dimensiune() > 0)
                return this.orderDetails.obtine(this.orderDetails.dimensiune() - 1).Data.Id + 1;
            else
                return 1;
        }
    }
}
