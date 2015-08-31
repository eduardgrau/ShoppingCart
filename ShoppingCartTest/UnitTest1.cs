using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart;

namespace ShoppingCartTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cart = new Cart();
            cart.AddItem("FR1");
            cart.AddItem("SR1");
            cart.AddItem("FR1");
            cart.AddItem("FR1");
            cart.AddItem("CF1");
            Assert.AreEqual(cart.GetTotal(), 22.45, 0.001, "Test 1 (FR1, SR1, FR1, FR1, CF1) Failed");
        }
        [TestMethod]
        public void TestMethod2()
        {
            var cart = new Cart();
            cart.AddItem("FR1");
            cart.AddItem("FR1");
            Assert.AreEqual(cart.GetTotal(), 3.11, 0.001, "Test 2 (FR1, FR1) Failed");
        }
        [TestMethod]
        public void TestMethod3()
        {
            var cart = new Cart();
            cart.AddItem("SR1");
            cart.AddItem("SR1");
            cart.AddItem("FR1");
            cart.AddItem("SR1");
            Assert.AreEqual(cart.GetTotal(), 16.61, 0.001, "Test 3 (SR1, SR1, FR1, SR1) Failed");
        }
    }

}
