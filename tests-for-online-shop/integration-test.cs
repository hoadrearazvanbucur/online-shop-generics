using generics_collection;
using online_shop_generics;
using online_shop_generics.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace tests_for_online_shop
{
    public class integration_test
    {
        private readonly ITestOutputHelper outputHelper;

        private ControlProduct controlProduct;
        private ControlCustomer controlCustomer;
        private ControlOrder controlOrder;
        private ControlOrderDetail controlOrderDetail;

        public integration_test(ITestOutputHelper output)
        {
            this.outputHelper = output;
            this.controlProduct = new ControlProduct();
            this.controlCustomer = new ControlCustomer();
            this.controlOrder = new ControlOrder();
            this.controlOrderDetail = new ControlOrderDetail();
        }



        [Fact]
        public void home()
        {

            Customer customer1 = new Customer(new string[] { "email", "password", "fullname", "1" });

            Phone phone1 = new Phone(new string[] { "phone", "Samsung", "foarte bun", "2041", "imagine1", "1", "11", "11.1", "S10", "trasparent", "22", "1", "2" });
            Phone phone2 = new Phone(new string[] { "phone", "Apple", "slab", "2000", "imagine2", "2", "22", "22.2", "12 Pro", "negru", "12", "23", "11" });
            Phone phone3 = new Phone(new string[] { "phone", "Motorola", "rezisten", "2013", "imagine3", "3", "33", "33.3", "S32", "mov", "11", "23", "44" });
            Phone phone4 = new Phone(new string[] { "phone", "iHunt", "frumos", "2021", "imagine4", "4", "44", "44.4", "A23", "cyan", "324", "142", "43" });
            Phone phone5 = new Phone(new string[] { "phone", "Cat", "frumos", "2020", "imagine5", "5", "55", "55.5", "H2", "violet", "22", "1", "213" });

            this.controlProduct.adaugare(phone1);
            this.controlProduct.adaugare(phone2);
            this.controlProduct.adaugare(phone3);
            this.controlProduct.adaugare(phone4);
            this.controlProduct.adaugare(phone5);




            Order order1 = new Order(new string[] { "1", $"{customer1.Id}", "0", "Rasinari" });

            OrderDetail orderDetail1 = new OrderDetail(new string[] { "1", $"{order1.Id}", $"{phone1.Id}", "2", $"{phone1.Price * 2}" });
            OrderDetail orderDetail2 = new OrderDetail(new string[] { "2", $"{order1.Id}", $"{phone3.Id}", "1", $"{phone3.Price}" });

            controlOrderDetail.adaugare(orderDetail1);
            controlOrderDetail.adaugare(orderDetail2);

            controlOrder.adaugare(order1);




            ILista<OrderDetail> orders = controlOrderDetail.orderListId(order1.Id);


            for (int i = 0; i < orders.dimensiune(); i++)
            {
                if (orders.obtine(i).Data.Id == 1)
                {
                    Assert.Equal("Samsung", controlProduct.productObjectID(orders.obtine(i).Data.Product_id).Name);
                }
                if (orders.obtine(i).Data.Id == 2)
                {
                    Assert.Equal("Motorola", controlProduct.productObjectID(orders.obtine(i).Data.Product_id).Name);
                }
            }

        }
    }
}
