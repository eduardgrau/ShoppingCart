using System.Collections.Generic;

namespace ShoppingCart
{
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
            },
            new Product()
            {
                Name = "Coffee",
                Price = 11.23,
                ProductCode = "CF1"
            }
        };
    }
}