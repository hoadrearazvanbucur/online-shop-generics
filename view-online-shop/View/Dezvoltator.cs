using generics_collection;
using online_shop_generics;
using online_shop_generics.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace view_online_shop.View
{
    public class Dezvoltator
    {
        private ControlProduct controlProduct;
        private ControlCustomer controlCustomer;
        private ControlOrder controlOrder;
        private ControlOrderDetail controlOrderDetail;
        private Customer customer;

        public Dezvoltator(ControlProduct controlProduct, ControlCustomer controlCustomer, ControlOrder controlOrder, ControlOrderDetail controlOrderDetail, Customer customer)
        {
            this.controlProduct = controlProduct;
            this.controlCustomer = controlCustomer;
            this.controlOrder = controlOrder;
            this.controlOrderDetail = controlOrderDetail;
            this.customer = customer;
        }
            
        public void control(int nr)
        {
            switch(nr)
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
                    modificare();
                    break;
            }
        }

        public void afisare()
        {
            Console.WriteLine(this.controlProduct.afisare());
        }

        public void adaugare()
        {
            Phone phone1 = new Phone(new string[] { "phone", "TEST ADAUGARE", "foarte bun", "2041", "imagine1", "1", "11", "11.1", "S10", "trasparent", "22", "1", "2" });
            this.controlProduct.adaugare(phone1);
            Console.WriteLine("Produs adaugat cu succes!");
        }
        public void stergere()
        {
            this.controlProduct.stergere(1);
            Console.WriteLine("Produs sters cu succes!");
        }
        public void modificare()
        {
            this.controlProduct.updateName(1, "TEST NUME");
            Console.WriteLine("Produs modificat cu succes!");
        }
    }
}
