using System;

namespace ShoppingCart
{
    public class ProductWithAssociatedOffer : IProductWithAssociatedOffer
    {
        private readonly IProduct _product;
        private readonly Func<IProduct, uint, IProduct> _associatedOffer;

        public ProductWithAssociatedOffer(IProduct product, Func<IProduct, uint, IProduct> associatedOffer)
        {
            _product = product;
            _associatedOffer = associatedOffer;
        }

        public Func<IProduct, uint, IProduct> GetOffer()
        {
            return _associatedOffer;
        }

        public string Name => _product.Name;

        public double UnitPrice => _product.UnitPrice;
    }
}