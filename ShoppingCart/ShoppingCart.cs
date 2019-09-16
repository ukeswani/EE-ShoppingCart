using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly List<IProductItem> _productItems;
        private double _totalPrice;

        public ShoppingCart()
        {
            _productItems = new List<IProductItem>();
        }

        public void AddProductItem(IProductItem productItem)
        {
            _productItems.Add(productItem);
        }

        public IEnumerable<IProductItem> ProductItems => _productItems;

        public double TotalPrice => Math.Round(_productItems.Select(pi => pi.Price).Sum(), 2);
    }
}