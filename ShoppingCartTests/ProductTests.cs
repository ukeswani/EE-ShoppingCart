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
            var product = CreateProduct();

            // Assert
            Assert.That(product, Is.InstanceOf(typeof(IProduct)));
        }

        [Test]
        public void GivenNoObject_WhenCreatingProductWithParticularName_ThenReturnsNameAsExpected()
        {
            // Arrange
            var expectedName = "Expected Product Name";
            
            //  Act
            var product = CreateProduct(expectedName);

            // Assert
            Assert.That(product.Name, Is.EqualTo(expectedName));
        }

        private IProduct CreateProduct(string name = "some product", double unitPrice = 0.00)
        {
            return new Product(name, unitPrice);
        }
    }
}
