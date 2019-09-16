using NUnit.Framework;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestFixture]
    class ProductTests
    {
        [Test]
        public void GivenNoObject_WhenCreatingProduct_ThenReturnsAnInstanceOfIProduct()
        {
            // Arrange, Act
            var product = CreateProduct();

            // Assert
            Assert.That(product, Is.InstanceOf(typeof(IProduct)));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductWithParticularName_ThenReturnsNameAsExpected()
        {
            // Arrange
            const string expectedName = "Expected Product Name";
            
            //  Act
            var product = CreateProduct(expectedName);

            // Assert
            Assert.That(product.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductWithParticularUnitPrice_ThenReturnsUnitPriceAsExpected()
        {
            // Arrange
            const double expectedUnitPrice = 39.99;

            //  Act
            var product = CreateProduct(unitPrice: expectedUnitPrice);

            // Assert
            Assert.That(product.UnitPrice, Is.EqualTo(expectedUnitPrice));
        }
        
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void GivenNoObject_WhenCreatingProductWithInvalidName_ThenThrowsException(string invalidName)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => CreateProduct(invalidName));
        }

        [TestCase(-1.0)]
        public void GivenNoObject_WhenCreatingProductWithInvalidUnitPrice_ThenThrowsException(double invalidUnitPrice)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => CreateProduct(unitPrice: invalidUnitPrice));
        }

        private IProduct CreateProduct(string name = "some product", double unitPrice = 0.00)
        {
            return new Product(name, unitPrice);
        }
    }
}
