using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class Cart
    {
        public class ProductVM
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
            public double Subtotal { get; set; }
        }

        public List<ProductVM> Products = new List<ProductVM>();
        
        public double GetTotal()
        {
            Products.ForEach(vm=>vm.Subtotal=vm.Quantity*vm.Product.Price);
            Rules.ApplyRules(this);
            var total = Products.Sum(productVM => productVM.Subtotal);
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
}