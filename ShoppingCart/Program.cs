using System;
using System.Linq;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pre Start");
            if (args != null && args.Any())
            {
                Console.WriteLine(args[0]);
            }
            Console.WriteLine("Start");
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
            Console.WriteLine("Result: " + cart.GetTotal());
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
            Console.WriteLine("Expected : 22.45, Result: " + cart.GetTotal());

            cart = new Cart();
            cart.AddItem("Cart 2");
            cart.AddItem("FR1");
            cart.AddItem("FR1");
            Console.WriteLine("Expected : 3.11, Result: " + cart.GetTotal());

            cart = new Cart();
            cart.AddItem("Cart 3");
            cart.AddItem("SR1");
            cart.AddItem("SR1");
            cart.AddItem("FR1");
            cart.AddItem("SR1");
            Console.WriteLine("Expected : 16.61, Result: " + cart.GetTotal());
        }
    }
}
