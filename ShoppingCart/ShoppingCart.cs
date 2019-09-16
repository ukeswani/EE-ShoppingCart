using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCart
    {
        private readonly List<ProductItem> _productItems;

        public ShoppingCart()
        {
            _productItems = new List<ProductItem>();
        }

        public void AddProductItem(ProductItem productItem)
        {
            _productItems.Add(productItem);
        }

        public double TotalPrice()
        {
            var totalPrice = _productItems.Select(pi => pi.UnitPrice * pi.Quantity).Sum();
            return Math.Round(totalPrice, 2);
        }
    }
}