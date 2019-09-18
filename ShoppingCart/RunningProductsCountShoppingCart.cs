using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class RunningProductsCountShoppingCart : IProductAddingShoppingCart
    {
        private readonly List<IProduct> _products;

        public RunningProductsCountShoppingCart()
        {
            _products = new List<IProduct>();
        }

        public void AddProduct(IProduct product, int quantity)
        {
            _products.AddRange(Enumerable.Repeat(product, quantity));
        }

        public IEnumerable<IProduct> Products => _products;

        public double GetTotalPrice()
        {
            return _products.Select(p => p.UnitPrice).Sum();
        }
    }
}