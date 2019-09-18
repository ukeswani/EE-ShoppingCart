using NUnit.Framework;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestFixture]
    class Story6Tests
    {
        [Test]
        public void GivenEmptyCart_WhenItemsAddedAndDiscountPlusServiceTaxApplied_ThenReturnsCorrectTotalPrice()
        {
            // Arrange
            var firstProduct = new Product("Dove Soap", 39.99);
            var secondProduct = new Product("Axe Deo", 89.99);
            Func<double, double> additionalProcessing = (tp) => tp + (tp * 12.5 / 100);
            var cart = new TotalPriceAdditionalProcessingShoppingCartDecorator(
                new TotalPriceAdditionalProcessingShoppingCartDecorator(
                    new RunningProductsCountShoppingCart(),
                    (a) =>
                    {
                        if (a > 500)
                        {
                            return a - (a * 20 / 100);
                        }

                        return a;
                    }),
                additionalProcessing
            );


            // Act
            cart.AddProduct(firstProduct, 5);
            cart.AddProduct(secondProduct, 4);

            // Assert
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(503.92));
        }
    }
}
