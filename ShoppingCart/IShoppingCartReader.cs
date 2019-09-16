using System.Collections.Generic;

namespace ShoppingCart
{
    public interface IShoppingCartReader
    {
        IEnumerable<IProductItem> ProductItems { get; }

        double TotalPrice { get; }
    }
}