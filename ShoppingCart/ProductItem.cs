using System;

namespace ShoppingCart
{
    public class ProductItem : IProductItem
    {
        private readonly IProduct _product;

        public ProductItem(IProduct product, uint quantity)
        {
            _product = product ?? throw new ArgumentNullException(nameof(product));

            if (quantity == 0)
            {
                throw new ArgumentException($"{nameof(quantity)} must be more than 0");
            }

            Quantity = quantity;

            
            UnitPrice = _product.UnitPrice;
            Name = _product.Name;
            Price = Quantity * _product.UnitPrice;
        }

        public double UnitPrice { get; }

        public uint Quantity { get; }

        public double Price { get; }

        public string Name { get; }
    }
}