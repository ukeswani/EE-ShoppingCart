using System.Collections.Generic;

namespace ShoppingCart
{
    public interface IProductAddingShoppingCart
    {
        void AddProduct(IProduct product, int quantity);

        IEnumerable<IProduct> Products { get; }

        double GetTotalPrice();
    }
}