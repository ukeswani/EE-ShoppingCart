using System;
using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    class Story3Tests
    {

        [Test]
        public void GivenEmptyCart_WhenItemsAddedAndServiceTaxApplied_ThenReturnsCorrectTotalPrice()
        {
            // Arrange
            var firstProduct = new Product("Dove Soap", 39.99);
            var secondProduct = new Product("Axe Deo", 99.99);
            Func<double, double> additionalProcessing = (tp) => tp + (tp * 12.5 / 100);
            var cart = new TotalPriceAdditionalProcessingShoppingCartDecorator(new RunningProductsCountShoppingCart(), additionalProcessing);

            // Act
            cart.AddProduct(firstProduct, 2);
            cart.AddProduct(secondProduct, 2);

            // Assert
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(314.96));
        }
    }
}
