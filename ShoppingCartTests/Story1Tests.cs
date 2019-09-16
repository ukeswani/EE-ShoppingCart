using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    public class Story1Tests
    {
        [Test]
        public void GivenEmptyCartAndProduct_WhenUserAddsProductItemsToCart_ThenCartShowsCorrectTotalPrice()
        {
            // Arrange
            var product = new Product("Dove Soap", 39.99);
            var cart = new ShoppingCart.ShoppingCart();

            // Act
            var productItem = new ProductItem(product, 5);
            cart.AddProductItem(productItem);

            // Assert
            Assert.That(cart.TotalPrice, Is.EqualTo(199.95));
        }
    }
}
