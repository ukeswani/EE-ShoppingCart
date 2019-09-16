using Moq;
using NUnit.Framework;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestFixture]
    class ProductItemTests
    {
        [Test]
        public void GivenNoObject_WhenCreatingProductItem_ThenReturnsAnInstanceOfIProductItem()
        {
            // Arrange, Act
            var productItem = new ProductItem(Mock.Of<IProduct>(), 5);

            // Assert
            Assert.That(productItem, Is.InstanceOf(typeof(IProductItem)));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductItemWithProductOfParticularName_ThenReturnsNameAsExpected()
        {
            // Arrange
            const string expectedName = "Expected Product Name";

            //  Act
            IProductItem productItem = CreateProductItem(injectedProductName: expectedName);

            // Assert
            Assert.That(productItem.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductItemWithProductOfParticularUnitPrice_ThenReturnsUnitPriceAsExpected()
        {
            // Arrange
            const double expectedUnitPrice = 39.99;

            //  Act
            IProductItem productItem = CreateProductItem(injectedProductUnitPrice: expectedUnitPrice);

            // Assert
            Assert.That(productItem.UnitPrice, Is.EqualTo(expectedUnitPrice));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductItemWithParticularQuantity_ThenReturnsQuantityAsExpected()
        {
            // Arrange
            const uint expectedQuantity = 10;

            //  Act
            IProductItem productItem = CreateProductItem(injectedQuantity: expectedQuantity);

            // Assert
            Assert.That(productItem.Quantity, Is.EqualTo(expectedQuantity));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductItemWithInvalidProduct_ThenThrowsArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new ProductItem(null, 5));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductItemWithZeroQuantity_ThenThrowsArgumentException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => CreateProductItem(injectedQuantity: 0));
        }

        private IProductItem CreateProductItem(
                                string injectedProductName = "Axe Deo",
                                double injectedProductUnitPrice = 89.99,
                                uint injectedQuantity = 5)
        {
            return new ProductItem(new Product(injectedProductName, injectedProductUnitPrice), injectedQuantity);
        }
    }
}
