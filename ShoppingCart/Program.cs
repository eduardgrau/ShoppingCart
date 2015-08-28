using System;
using System.Linq;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You can choose between introducing a string in the format \"SR1,FR1,CF1\"");
            Console.WriteLine("or press enter and show the results of the test data provided");

            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                TestExamples();
            }
            else
            {
                TestInputString(input);
            }

            Console.WriteLine("End ... Press any key to exit the program");
            Console.ReadLine();
        }

        private static void TestInputString(string input)
        {
            var cart = new Cart();
            var inputList = input.Split(',');
            foreach (var inputItem in inputList.Where(inputItem => cart.AddItem(inputItem) != 0))
            {
                Console.WriteLine("There was an error trying to find the product :" + inputItem);
            }
            Console.Write(cart.ToString());
        }

        private static void TestExamples()
        {
            var cart = new Cart();
            cart.AddItem("Cart 1");
            cart.AddItem("FR1");
            cart.AddItem("SR1");
            cart.AddItem("FR1");
            cart.AddItem("FR1");
            cart.AddItem("CF1");
            Console.WriteLine("Expected : \u00A322.45" + cart.GetTotal());
            Console.Write(cart.ToString());


            cart = new Cart();
            cart.AddItem("Cart 2");
            cart.AddItem("FR1");
            cart.AddItem("FR1");
            Console.WriteLine("Expected : \u00A33.11" + cart.GetTotal());
            Console.Write(cart.ToString());

            cart = new Cart();
            cart.AddItem("Cart 3");
            cart.AddItem("SR1");
            cart.AddItem("SR1");
            cart.AddItem("FR1");
            cart.AddItem("SR1");
            Console.WriteLine("Expected : \u00A316.61" + cart.GetTotal());
            Console.Write(cart.ToString());
        }
    }
}
