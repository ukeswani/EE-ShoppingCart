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
        }

        public double UnitPrice => _product.UnitPrice;

        public uint Quantity
        {
            get;
        }

        public string Name => _product.Name;
    }
}