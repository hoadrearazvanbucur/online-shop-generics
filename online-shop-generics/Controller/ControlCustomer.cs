using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using generics_collection;

namespace online_shop_generics.Controller
{
    public class ControlCustomer
    {
        private ILista<Customer> customers;

        public ControlCustomer()
        {
            customers = new Lista<Customer>();
        }

        public void deleteList()
        {
            for (int i = 0; i < customers.dimensiune(); i++)
                customers.stergere(0);
        }

        public void load()
        {
            this.deleteList();
            string path = @"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\customerFile.txt";
            StreamReader fisier = new StreamReader(path);
            string linie = "";
            while ((linie = fisier.ReadLine()) != null)
            {
                string[] linieSplit = linie.Split(',');
                customers.adaugare(new Customer(linieSplit));
            }
            fisier.Close();
        }
        

        public void save()
        {
            string path = @"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\customerFile.txt";
            StreamWriter fisier = new StreamWriter(path);
            for (int i = 0; i < customers.dimensiune(); i++)
                fisier.WriteLine(customers.obtine(i).Data.ToString());
            fisier.Close();
        }


        public string afisare()
        {
            return customers.afisare();
        }

        public void adaugare(Customer customer)
        {
            this.customers.adaugare(customer);
        }
        public void stergere(int id)
        {
            this.customers.stergere(customerId(id));
        }


        public void updateEmail(int id, string emailNou)
        {
            customers.obtine(customerId(id)).Data.Email = emailNou;
        }
        public void updatePassword(int id, string passwordNou)
        {
            customers.obtine(customerId(id)).Data.Password = passwordNou;
        }
        public void updateFullName(int id, string fullNameNou)
        {
            customers.obtine(customerId(id)).Data.FullName = fullNameNou;
        }


        public int customerId(int id)
        {
            int k = 0;
            for (int i = 0; i < customers.dimensiune(); i++)
                if (customers.obtine(i).Data.Id == id) return k;
                else k++;
            return -1;
        }
        public Customer customerObjectId(int id)
        {
            for (int i = 0; i < customers.dimensiune(); i++)
                if (customers.obtine(i).Data.Id.Equals(id) == true)
                    return customers.obtine(i).Data;
            return null;
        }
        public bool accVerification(string fullName, string password)
        {
            for (int i = 0; i < customers.dimensiune(); i++)
                if (customers.obtine(i).Data.Password.Equals(password) == true && customers.obtine(i).Data.FullName.Equals(fullName) == true)
                    return true;
            return false;
        }
        public Customer customerAcc(string fullName, string password)
        {
            for (int i = 0; i < customers.dimensiune(); i++)
                if (customers.obtine(i).Data.Password.Equals(password) == true && customers.obtine(i).Data.FullName.Equals(fullName) == true)
                    return customers.obtine(i).Data;
            return null;
        }

        public ILista<Customer> Customers
        {
            get => this.customers;
            set => this.customers = value;
        }

        public int nextId()
        {
            if (this.customers.dimensiune() > 0)
                return this.customers.obtine(this.customers.dimensiune() - 1).Data.Id + 1;
            else
                return 1;
        }
    }
}
