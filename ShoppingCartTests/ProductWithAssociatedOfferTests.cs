using NUnit.Framework;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestFixture]
    class ProductWithAssociatedOfferTests
    {
        [Test]
        public void GivenNoObject_WhenProductWithAssociatedOfferCreated_ThenReturnsAnInstanceOfIProduct()
        {
            // Assert, Act
            var productWithOffer = CreateProductWithAssociatedOffer();

            // Assert
            Assert.That(productWithOffer, Is.InstanceOf(typeof(IProduct)));
        }

        [Test]
        public void GivenNoObject_WhenProductWithAssociatedOfferCreated_ThenReturnsAnInstanceOfIOffer()
        {
            // Assert, Act
            var productWithOffer = CreateProductWithAssociatedOffer();

            // Assert
            Assert.That(productWithOffer, Is.InstanceOf(typeof(IOffer)));
        }

        [Test]
        public void GivenNoObject_WhenProductWithAssociatedOfferCreated_ThenReturnsAnInstanceOfIProductWithAssociatedOffer()
        {
            // Assert, Act
            var productWithOffer = CreateProductWithAssociatedOffer();

            // Assert
            Assert.That(productWithOffer, Is.InstanceOf(typeof(IProductWithAssociatedOffer)));
        }

        [Test]
        public void GivenProductWithAssociatedOffer_WhenGetOfferCalled_ThenReturnsExpectedFunc()
        {
            // Arrange
            IOffer productWithOffer = CreateProductWithAssociatedOffer();

            // Act
            var offerProduct = productWithOffer.GetOffer();

            // Assert
            Assert.That(offerProduct, Is.InstanceOf(typeof(Func<IProduct, uint, IProduct>)));
        }

        [Test]
        public void GivenProductWithAssociatedOffer_WhenNameQueried_ThenReturnsExpectedProductName()
        {
            // Arrange
            var expectedProductName = "expected name";
            var product =  new Product(expectedProductName, 9.0);
            var productWithOffer = CreateProductWithAssociatedOffer(product);

            // Act
            var productName = productWithOffer.Name;

            // Assert
            Assert.That(productName, Is.EqualTo(expectedProductName));
        }

        [Test]
        public void GivenProductWithAssociatedOffer_WhenUnitPriceQueried_ThenReturnsExpectedProductUnitPrice()
        {
            // Arrange
            var expectedProductUnitPrice = 89.00;
            var product = new Product("something", expectedProductUnitPrice);
            var productWithOffer = CreateProductWithAssociatedOffer(product);

            // Act
            var productName = productWithOffer.UnitPrice;

            // Assert
            Assert.That(productName, Is.EqualTo(expectedProductUnitPrice));
        }

        private IProductWithAssociatedOffer CreateProductWithAssociatedOffer(IProduct injectedProduct = null)
        {
            var product = injectedProduct ?? new Product("Product", 1.0);
            return new ProductWithAssociatedOffer(product, (a, b) => a);
        }
    }
}
