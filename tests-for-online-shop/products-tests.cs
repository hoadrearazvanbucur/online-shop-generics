﻿using generics_collection;
using online_shop_generics;
using online_shop_generics.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace tests_for_online_shop
{
    public class products_tests
    {
        private readonly ITestOutputHelper outputHelper;

        public products_tests(ITestOutputHelper output)
        {
            this.outputHelper = output;
        }


        [Fact]
        public void saveAdaugareStergere()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11", "11" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);
            control.save();
            control.load();
            Assert.True(control.productId(11) >= 0);
            control.stergere(11);
            control.save();
            control.load();
            Assert.True(control.productId(11) < 0);
        }

        [Fact]
        public void updateName()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateName(1, "TEST NUME");
            Assert.Equal("TEST NUME", control.productObjectID(1).Name);

            control.stergere(1);
        }
        [Fact]
        public void updateDescription()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateDescription(1, "TEST DESCRIERE");
            Assert.Equal("TEST DESCRIERE", control.productObjectID(1).Description);

            control.stergere(1);
        }
        [Fact]
        public void updateDate()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateDate(1, "TEST DATA");
            Assert.Equal("TEST DATA", control.productObjectID(1).Date);

            control.stergere(1);
        }
        [Fact]
        public void updateImage()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateImage(1, "TEST IMAGINE");
            Assert.Equal("TEST IMAGINE", control.productObjectID(1).Image);

            control.stergere(1);
        }
        [Fact]
        public void updateStock()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateStock(1, 123);
            Assert.Equal(123, control.productObjectID(1).Stock);

            control.stergere(1);
        }
        [Fact]
        public void updatePrice()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updatePrice(1, 1234);
            Assert.Equal(1234, control.productObjectID(1).Price);

            control.stergere(1);
        }
        [Fact]
        public void updatePhoneName()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updatePhoneName(1, "TEST Telefon Nume");
            Assert.Equal("TEST Telefon Nume", (control.productObjectID(1) as Phone).PhoneName);

            control.stergere(1);
        }
        [Fact]
        public void updatePhoneColor()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updatePhoneColor(1, "TEST Culoare");
            Assert.Equal("TEST Culoare", (control.productObjectID(1) as Phone).PhoneColor);

            control.stergere(1);
        }
        [Fact]
        public void updateScreenSize()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateScreenSizePhone(1, 12345);
            Assert.Equal(12345, (control.productObjectID(1) as Phone).ScreenSize);

            control.stergere(1);
        }
        [Fact]
        public void updateStorage()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateStorage(1, 123456);
            Assert.Equal(123456, (control.productObjectID(1) as Phone).Storage);

            control.stergere(1);
        }
        [Fact]
        public void updateBatteryCapacity()
        {
            ControlProduct control = new ControlProduct();
            string[] p1 = new string[] { "phone", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Phone product1 = new Phone(p1);
            control.adaugare(product1);

            control.updateBatteryCapacity(1, 1234567);
            Assert.Equal(1234567, (control.productObjectID(1) as Phone).BatteryCapacity);

            control.stergere(1);
        }
    }
}
