using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    class Story4Tests
    {
        [Test]
        public void GivenEmptyCartProductWithBuyXAndGetYOffer_When5ProductsAdded_ThenReturnsExpectedTotalPriceAndDiscount()
        {
            // Arrange
            var doveProduct = new Product("Dove Soap", 39.99);
            var offerBuy2Get1Free = new Func<IProduct, uint, IProduct>((p, q) =>
            {
                uint numberOfTimesToApply = q / 3;

                if (numberOfTimesToApply > 0)
                {
                    return new DiscountAsProduct(
                        p.Name + " - Buy 2 Get 1 Free offer",
                        numberOfTimesToApply * p.UnitPrice);
                }

                return new NullProduct();
            });

            var discountCalculator = new Func<IEnumerable<IProduct>, double>((products) =>
            {
                var discount = 0.0d;
                var offerApplied = new List<IProduct>();

                var enumerable = products.ToList();

                foreach (var product in enumerable)
                {
                    if (!(product is IProductWithAssociatedOffer productWithAssociatedOffer) || offerApplied.Contains(product)) continue;
                    var quantity = enumerable.Count(p => p.Name == product.Name);

                    discount -= productWithAssociatedOffer.GetOffer()(product, (uint)quantity).UnitPrice;
                    
                    offerApplied.Add(product);
                }

                return discount;
            });

            var priceCalculator = new Func<IEnumerable<IProduct>, double>((products) =>
            {
                var price = 0.0d;

                var enumerable = products.ToList();

                price = enumerable.Select(p => p.UnitPrice).Sum();

                price -= discountCalculator(enumerable);

                return price;
            });

            var serviceTaxCalculator = new Func<double, double>((price) => price + price * 0.125);


            var productWithOffer = new ProductWithAssociatedOffer(doveProduct, offerBuy2Get1Free);
            var cart = new DiscountShoppingCart(
                            priceCalculator.AndThen(serviceTaxCalculator),
                            discountCalculator);

            // Act
            cart.AddProduct(productWithOffer, 3);

            // Assert
            Assert.That(cart.Products.Count(p => p.Name == "Dove Soap"), Is.EqualTo(3));
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(89.98));
            Assert.That(cart.GetTotalDiscount(), Is.EqualTo(39.99));
        }

        private class ShoppingCart
        {
            private List<IProduct> _products;

            private readonly Func<IEnumerable<IProduct>, double> _totalPriceCalculator;

            public ShoppingCart(Func<IEnumerable<IProduct>, double> totalPriceCalculator)
            {
                _totalPriceCalculator = totalPriceCalculator;

                _products = new List<IProduct>();
            }

            public void AddProduct(IProduct product, int quantity)
            {
                _products.AddRange(Enumerable.Repeat(product, quantity));
            }

            public IEnumerable<IProduct> Products => _products;

            public double GetTotalPrice()
            {
                return _totalPriceCalculator(_products);
            }
        }

        private class DiscountShoppingCart : ShoppingCart
        {
            private readonly Func<IEnumerable<IProduct>, double> _totalDiscountCalculator;

            public DiscountShoppingCart(
                    Func<IEnumerable<IProduct>, double> totalPriceCalculator, 
                    Func<IEnumerable<IProduct>, double> totalDiscountCalculator) 
                    : base(totalPriceCalculator)
            {
                _totalDiscountCalculator = totalDiscountCalculator;
            }

            public double GetTotalDiscount()
            {
                return _totalDiscountCalculator(Products);
            }
        }
    }

    public static class Extensions
    {
        public static Func<X, Z> AndThen<X, Y, Z>(this Func<X, Y> firstFunc, Func<Y, Z> secondFunc)
        {
            return x => secondFunc(firstFunc(x));
        }
    }
}
