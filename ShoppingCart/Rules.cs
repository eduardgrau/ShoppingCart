using System;
using System.Linq;

namespace ShoppingCart
{
    public static class Rules
    {
        public static void ApplyRules(Cart cart)
        {
            cart.Rule1();
            cart.Rule2();
            //Execute new Rules
        }
        //The CEO is a big fan of buy-one-get-one-free offers and of fruit tea. He wants us to add a rule to do this.
        public static void Rule1(this Cart cart)
        {
            var product = cart.Products.SingleOrDefault(vm => vm.Product.ProductCode == "FR1");
            if (product == null) return;
            product.Subtotal = Math.Ceiling((double) product.Quantity/2) * product.Product.Price;
        }

        //The COO, though, likes low prices and wants people buying strawberries to get a price discount for bulk purchases. If you buy 3 or more strawberries, the price should drop to £4.50
        public static void Rule2(this Cart cart)
        {
            var product = cart.Products.SingleOrDefault(vm => vm.Product.ProductCode == "SR1");
            if (product == null) return;
            //Sorry for the hardcoded value
            if (product.Quantity >= 3)
            {
                product.Subtotal = product.Quantity * 4.50;
            }
        }
        //Add new rules
    }
}