using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            cart.AddItem("SR1");
            cart.AddItem("FR1");
            Console.WriteLine("Expected : 16.61, Result: " + cart.GetTotal());

            Console.WriteLine("End ... Press any key to exit the program");
            Console.ReadLine();
        }
    }

    public class Product
    {
        
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public static List<Product> ProductsList = new List<Product>()
        {
            new Product()
                {
                    Name = "Fruit tea",
                    Price = 3.11,
                    ProductCode = "FR1"
            },
            new Product()
                {
                    Name = "Strawberries",
                    Price = 5.00,
                    ProductCode = "SR1"
            },new Product()
                {
                    Name = "Coffee",
                    Price = 11.23,
                    ProductCode = "CF1"
                }
        };
    }

    class ProductVM
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
    }

    class Cart
    {
        public List<ProductVM> Products = new List<ProductVM>();
        public void applyRules(Cart cart)
        {
            cart.Rule1();
            cart.Rule2();
            //List<Action> actions = new List<Action> {Rules.Rule1(cart)};
            //actions.ForEach(a => a.Invoke());
        }
        public double GetTotal()
        {
            Products.ForEach(vm=>vm.Subtotal=vm.Quantity*vm.Product.Price);
            applyRules(this);
            double total = Products.Sum(productVM => productVM.Subtotal);
            return total;
        }

        public int AddItem(string productCode)
        {
            var product = Product.ProductsList.SingleOrDefault(pk => pk.ProductCode == productCode);
            if (product == null) return -1;

            if (Products.All(p => p.Product.ProductCode != productCode))
            {
                Products.Add(new ProductVM()
                {
                    Product = product,
                    Quantity = 0,
                });
            }
            Products.Find(prvm => prvm.Product.ProductCode == productCode).Quantity++;
            return 0;
        }
    }

    static class Rules
    {
        //The CEO is a big fan of buy-one-get-one-free offers and of fruit tea. He wants us to add a rule to do this.
        //FR
        public static Action Rule1(this Cart cart)
        {
            var product = cart.Products.SingleOrDefault(vm => vm.Product.ProductCode == "FR1");
            if (product == null) return null;
            product.Subtotal = Math.Ceiling((double) product.Quantity/2) * product.Product.Price;
            return null; //cart.Products
        }

        //The COO, though, likes low prices and wants people buying strawberries to get a price discount for bulk purchases. If you buy 3 or more strawberries, the price should drop to £4.50
        public static Action Rule2(this Cart cart)
        {
            var product = cart.Products.SingleOrDefault(vm => vm.Product.ProductCode == "SR1");
            if (product == null) return null;
            //Sorry for the hardcoded value
            if (product.Quantity >= 3)
            {
                product.Subtotal = product.Quantity * 4.50;
            }
            return null; 
        }
    }
}
