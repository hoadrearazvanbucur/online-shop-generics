using online_shop_generics;
using online_shop_generics.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using view_online_shop.View;

namespace view_online_shop
{
    public class ViewHome
    {
        private ControlProduct controlProduct;
        private ControlCustomer controlCustomer;
        private ControlOrder controlOrder;
        private ControlOrderDetail controlOrderDetail;
        private Customer customer;
        private Order order;

        private Dezvoltator dezvoltator;
        private Cumparator cumparator;

        public ViewHome()
        {
            this.controlProduct = new ControlProduct();
            this.controlCustomer = new ControlCustomer();
            this.controlOrder = new ControlOrder();
            this.controlOrderDetail = new ControlOrderDetail();

            this.customer = new Customer(new string[] { "email", "parola", "Razvan", controlCustomer.nextId().ToString() });
            Order order = new Order(new string[] { $"{this.controlOrder.nextId()}", $"{customer.Id}", "0", "Rasinari" });
            controlOrder.adaugare(order);

            this.dezvoltator = new Dezvoltator(controlProduct, controlCustomer, controlOrder, controlOrderDetail, customer);
            this.cumparator = new Cumparator(controlProduct, controlCustomer, controlOrder, controlOrderDetail, customer);

            this.home();
        }

        public void home()
        {
            Console.WriteLine($"Bine ai venit {this.customer.FullName} !\n");
            int nr = this.legend();
            Console.Clear();
            while (nr!=29)
            {
                switch (nr)
                {
                    case 11:
                        if (this.customer.FullName.ToLower() == "razvan")
                            dezvoltator.control(1);            
                        break;
                    case 12:
                        if (this.customer.FullName.ToLower() == "razvan")
                            dezvoltator.control(2);
                        break;
                    case 13:
                        if (this.customer.FullName.ToLower() == "razvan")
                            dezvoltator.control(3);
                        break;
                    case 14:
                        if (this.customer.FullName.ToLower() == "razvan")
                            dezvoltator.control(4);
                        break;


                    case 21:
                        cumparator.control(1);
                        break;
                    case 22:
                        cumparator.control(2);
                        break;
                    case 23:
                        cumparator.control(3);
                        break;
                    case 24:
                        cumparator.control(4);
                        break;
                }
                nr = this.legend();
                Console.Clear();

            }
            Console.WriteLine("La revedere!");
        }

        public int legend()
        {
            Console.WriteLine("Apasa 1 pentru a intra in meniul de dezvoltator");
            Console.WriteLine("Apasa 2 pentru a intra in meniul de cumparator.");
            Console.WriteLine("Apasa 3 pentru a iesi.\n");
            Console.Write("-->  ");
            int nr = int.Parse(Console.ReadLine()),nr1=-1;
            while (nr > 3)
            {
                Console.WriteLine("Introduceti un numar valid.");
                Console.Write("-->  ");
                nr = int.Parse(Console.ReadLine());
            }
            if (nr == 1)
            {
                Console.WriteLine("Apasa 1 pentru a afisa un produs.");
                Console.WriteLine("Apasa 2 pentru a adauga un produs.");
                Console.WriteLine("Apasa 3 pentru a sterge un produs.");
                Console.WriteLine("Apasa 4 pentru a modifica un produs.");
                Console.WriteLine("Apasa 5 pentru a iesi din meniul de dezvoltator.\n");
                Console.Write("-->  ");
                nr1 = int.Parse(Console.ReadLine());
                while (nr1 > 5 && nr1 != -1)
                {
                    Console.WriteLine("Introduceti un numar valid.");
                    Console.Write("-->  ");
                    nr1 = int.Parse(Console.ReadLine());
                }
            }
            else if (nr == 2)
            {
                Console.WriteLine("Apasa 1 pentru a vedea cosul.");
                Console.WriteLine("Apasa 2 pentru a adauga un produs in cos.");
                Console.WriteLine("Apasa 3 pentru a sterge un produs din cos.");
                Console.WriteLine("Apasa 4 pentru a trimite comanda.");
                Console.WriteLine("Apasa 5 pentru a iesi din meniul de cumparator.\n");
                Console.Write("-->  ");
                nr1 = int.Parse(Console.ReadLine());
                while (nr1 > 5 && nr1 != -1)
                {
                    Console.WriteLine("Introduceti un numar valid.");
                    Console.Write("-->  ");
                    nr1 = int.Parse(Console.ReadLine());
                }
            }
            return nr * 10 + nr1;
        }
    }
}
