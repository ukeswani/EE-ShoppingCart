using System;

namespace ShoppingCart
{
    public class AddableProductItem : IAddableProductItem
    {
        private IProductItem _productItem;

        public AddableProductItem(IProductItem productItem)
        {
            _productItem = productItem;
        }

        public string Name => _productItem.Name;
        public double UnitPrice => _productItem.UnitPrice;
        public uint Quantity => _productItem.Quantity;
        public double Price => _productItem.Price;

        public void Add(IProductItem productItemToAdd)
        {
            if (productItemToAdd == null)
            {
                throw new ArgumentNullException($"{nameof(productItemToAdd)} cannot be null");
            }

            if (productItemToAdd.Name != Name)
            {
                throw new ArgumentException($"Only product items with same product name can be added." +
                                            $"Product name for product item asked to add is - {productItemToAdd.Name}");
            }

            _productItem = new ProductItem(new Product(Name, UnitPrice), Quantity + productItemToAdd.Quantity);
        }
    }
}