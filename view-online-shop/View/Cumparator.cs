using generics_collection;
using online_shop_generics;
using online_shop_generics.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace view_online_shop.View
{
    public class Cumparator
    {
        private ControlProduct controlProduct;
        private ControlCustomer controlCustomer;
        private ControlOrder controlOrder;
        private ControlOrderDetail controlOrderDetail;
        private Customer customer;
        public Cumparator(ControlProduct controlProduct, ControlCustomer controlCustomer, ControlOrder controlOrder, ControlOrderDetail controlOrderDetail, Customer customer)
        {
            this.controlProduct = controlProduct;
            this.controlCustomer = controlCustomer;
            this.controlOrder = controlOrder;
            this.controlOrderDetail = controlOrderDetail;
            this.customer = customer;
        }
        
        public void control(int nr)
        {
            switch (nr)
            {
                case 1:
                    afisare();
                    break;
                case 2:
                    adaugare();
                    break;
                case 3:
                    stergere();
                    break;
                case 4:
                    trimitere();
                    break;
            }
        }

        public void afisare()
        {
            Console.WriteLine("Cosul meu:\n");
            ILista<OrderDetail> orders = controlOrderDetail.orderListId(controlOrder.orderMax(this.customer.Id).Id);
            for(int i=0;i<orders.dimensiune();i++)
            {
                Console.WriteLine(controlProduct.productObjectID(orders.obtine(i).Data.Product_id).afisare());
            }

        }

        public void adaugare()
        {
            Phone phone1 = new Phone(new string[] { "phone", "TEST ADAUGARE", "foarte bun", "2041", "imagine1", "1", "11", "11.1", "S10", "trasparent", "22", "1", "2" });
            Phone phone2 = new Phone(new string[] { "phone", "TEST ADAUGARE", "foarte bun", "2041", "imagine1", "2", "11", "11.1", "S10", "trasparent", "22", "1", "2" });
            this.controlProduct.adaugare(phone1);
            this.controlProduct.adaugare(phone2);
            OrderDetail orderDetail1 = new OrderDetail(new string[] { "1", $"{controlOrder.orderMax(this.customer.Id).Id}", $"{phone1.Id}", "2", $"{phone1.Price * 2}" });
            OrderDetail orderDetail2 = new OrderDetail(new string[] { "1", $"{controlOrder.orderMax(this.customer.Id).Id}", $"{phone2.Id}", "2", $"{phone2.Price * 2}" });
            controlOrderDetail.adaugare(orderDetail1);
            controlOrderDetail.adaugare(orderDetail2);

        }
        public void stergere()
        {
            controlOrderDetail.stergere(1);           
        }
        public void trimitere()
        {
            Console.WriteLine("Comanda a fost trimisa cu succes!");
            Order order = new Order(new string[] { $"{this.controlOrder.nextId()}", $"{customer.Id}", "0", "Rasinari" });
            this.controlOrder.adaugare(order);
        }
    }
}
