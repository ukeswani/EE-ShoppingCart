using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    class ProductTests
    {
        [Test]
        public void GivenNoObject_WhenCreatingProduct_ThenReturnsAnInstanceOfIProduct()
        {
            // Arrange, Act
            var product = new Product("some product", 0.00);

            // Assert
            Assert.That(product, Is.InstanceOf(typeof(IProduct)));
        }
    }
}
