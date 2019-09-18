using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class HandleProductsWithAssociatedOfferShoppingCartDecorator : IProductAddingShoppingCart
    {
        private readonly IProductAddingShoppingCart _productAddingShoppingCart;
        private readonly Dictionary<string, IOffer> _productOffers;
        
        public HandleProductsWithAssociatedOfferShoppingCartDecorator(IProductAddingShoppingCart productAddingShoppingCart)
        {
            
            _productAddingShoppingCart = productAddingShoppingCart ??
                                         throw new ArgumentNullException(nameof(productAddingShoppingCart));

            _productOffers = new Dictionary<string, IOffer>();
        }

        public void AddProduct(IProduct product, int quantity)
        {
            _productAddingShoppingCart.AddProduct(product, quantity);

            if (!(product is IProductWithAssociatedOffer offer))
                return;

            if (!_productOffers.Keys.Contains(offer.Name))
            {
                _productOffers.Add(offer.Name, offer);
            }
        }

        public IEnumerable<IProduct> Products => _productAddingShoppingCart.Products;

        public double GetTotalPrice()
        {
            var totalPrice = _productAddingShoppingCart.GetTotalPrice();

            var totalDiscount = GetTotalDiscount();

            return totalPrice - totalDiscount;
        }

        public double GetTotalDiscount()
        {
            var totalDiscount = 0.0d;

            foreach (var productOffer in _productOffers)
            {
                var offerProducts = _productAddingShoppingCart.Products.Where(p => p.Name == productOffer.Key).ToList();
                var quantity = offerProducts.Count();

                var offer = productOffer.Value.GetOffer();

                var productFromApplicationOfOffer = offer(offerProducts.First(), (uint)quantity);

                if (productFromApplicationOfOffer is DiscountAsProduct discount)
                {
                    totalDiscount += discount.UnitPrice;
                }
            }

            return -1 * totalDiscount;
        }
    }
}