using System;
using System.Collections.Generic;

namespace ShoppingCart
{
    public class TotalPriceAdditionalProcessingShoppingCartDecorator : IProductAddingShoppingCart
    {
        private readonly IProductAddingShoppingCart _shoppingCart;
        private readonly Func<double, double> _additionalProcessing;

        public TotalPriceAdditionalProcessingShoppingCartDecorator(
            IProductAddingShoppingCart shoppingCartToDecorate,
            Func<double, double> additionalProcessing)
        {
            _shoppingCart = shoppingCartToDecorate ?? throw new ArgumentNullException(nameof(shoppingCartToDecorate));
            _additionalProcessing = additionalProcessing ?? throw new ArgumentNullException(nameof(additionalProcessing));
        }

        public void AddProduct(IProduct product, int quantity)
        {
            _shoppingCart.AddProduct(product, quantity);
        }

        public IEnumerable<IProduct> Products => _shoppingCart.Products;

        public double GetTotalPrice()
        {
            return Math.Round(_additionalProcessing(_shoppingCart.GetTotalPrice()), 2);
        }
    }
}