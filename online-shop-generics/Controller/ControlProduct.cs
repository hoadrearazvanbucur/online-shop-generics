using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using generics_collection;

namespace online_shop_generics.Controller
{
    public class ControlProduct
    {
        private ILista<Product> products;

        public ControlProduct()
        {
            products = new Lista<Product>();
        }

        public void deleteList()
        {
            for (int i = 0; i < products.dimensiune(); i++)
                products.stergere(0);
        }

        public void load()
        {
            this.deleteList();
            StreamReader fisier = new StreamReader(@"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\productFile.txt");
            string linie = "";
            while ((linie = fisier.ReadLine()) != null)
            {
                string[] linieSplit = linie.Split(',');
                if (linieSplit[0] == "phone")
                    products.adaugare(new Phone(linieSplit));

                //else celelalte categorii
            }
            fisier.Close();
        }
        public void save()
        {
            StreamWriter fisier = new StreamWriter(@"D:\1_PROGRAMARE\C#\Abstractizare\online-shop-generics\online-shop-generics\Controller\Resorces\productFile.txt");
            for (int i = 0; i < products.dimensiune(); i++)
            {
                if (products.obtine(i).Data is Phone) fisier.WriteLine((products.obtine(i).Data as Phone).ToString());

            }
            fisier.Close();
        }


        public string afisare()
        {
            string afis = "";
            for (int i = 0; i < products.dimensiune(); i++)
            {
                afis += products.obtine(i).Data.afisare();
                if (products.obtine(i).Data is Phone)
                {
                    Phone phone = products.obtine(i).Data as Phone;
                    afis += phone.afisare();
                }
                //celelalte categorii

            }
            return afis;
        }
        public void adaugare(Product product)
        {
            this.products.adaugare(product);
        }
        public void stergere(int id)
        {
            this.products.stergere(productId(id));
        }


        //Product
        public void updateName(int id, string numeNou)
        {
            products.obtine(productId(id)).Data.Name = numeNou;
        }
        public void updateDescription(int id, string descriereNou)
        {
            products.obtine(productId(id)).Data.Description = descriereNou;
        }
        public void updateDate(int id, string dataNou)
        {
            products.obtine(productId(id)).Data.Date = dataNou;
        }
        public void updateImage(int id, string imagineNou)
        {
            products.obtine(productId(id)).Data.Image = imagineNou;
        }
        public void updateStock(int id, int stocNou)
        {
            products.obtine(productId(id)).Data.Stock = stocNou;
        }
        public void updatePrice(int id, int pretNou)
        {
            products.obtine(productId(id)).Data.Price = pretNou;
        }

        //Phone
        public void updatePhoneName(int id, string phoneNameNou)
        {
            (products.obtine(productId(id)).Data as Phone).PhoneName = phoneNameNou;
        }
        public void updatePhoneColor(int id, string phoneColorNou)
        {
            (products.obtine(productId(id)).Data as Phone).PhoneColor = phoneColorNou;
        }
        public void updateScreenSizePhone(int id, int screenSizeNou)
        {
            (products.obtine(productId(id)).Data as Phone).ScreenSize = screenSizeNou;
        }
        public void updateStorage(int id, int storageNou)
        {
            (products.obtine(productId(id)).Data as Phone).Storage = storageNou;
        }
        public void updateBatteryCapacity(int id, int batteryCapacityNou)
        {
            (products.obtine(productId(id)).Data as Phone).BatteryCapacity = batteryCapacityNou;
        }


        public int productId(int id)
        {
            int k = 0;
            for (int i = 0; i < products.dimensiune(); i++)
                if (products.obtine(i).Data.Id == id) return k;
                else k++;
            return -1;
        }


        public Product productObjectID(int id)
        {
            for (int i = 0; i < products.dimensiune(); i++)
                if (products.obtine(i).Data.Id.Equals(id) == true)
                    return products.obtine(i).Data;
            return null;
        }
        public ILista<Product> Products
        {
            get => this.products;
            set => this.products = value;
        }
        public ILista<Product> afisareCard
        {
            get => this.products;
        }


        public int nextId()
        {
            if (this.products.dimensiune() > 0)
                return this.products.obtine(this.products.dimensiune() - 1).Data.Id + 1;
            else
                return 1;
        }


        public List<Product> filtrareNume(List<Product> lista, string nume)
        {
            List<Product> nou = new List<Product>();
            foreach (Product product in lista)
                if (product.Name.Equals(nume) == true)
                    nou.Add(product);
            return nou;
        }
        public List<Product> filtrarePrice(List<Product> lista, int price)
        {
            List<Product> nou = new List<Product>();
            foreach (Product product in lista)
                if (product.Price == price)
                    nou.Add(product);
            return nou;
        }
        public List<Product> filtrareStock(List<Product> lista, int stock)
        {
            List<Product> nou = new List<Product>();
            foreach (Product product in lista)
                if (product.Stock == stock)
                    nou.Add(product);
            return nou;
        }

        public List<Product> sortareNume(List<Product> lista)
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                    if (lista[i].Name[0] + (lista[i] as Phone).PhoneName[0] >= lista[j].Name[0] + (lista[j] as Phone).PhoneName[0])
                    {
                        Product aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            }
            return lista;
        }
        public List<Product> sortarePrice(List<Product> lista)
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                    if (lista[i].Price >= lista[j].Price)
                    {
                        Product aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            }
            return lista;
        }
        public List<Product> sortareStock(List<Product> lista)
        {
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                    if (lista[i].Stock >= lista[j].Stock)
                    {
                        Product aux = lista[i];
                        lista[i] = lista[j];
                        lista[j] = aux;
                    }
            }
            return lista;
        }
    }
}
