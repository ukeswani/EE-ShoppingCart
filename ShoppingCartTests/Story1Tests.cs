using System.Linq;
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

        [Test]
        public void GivenEmptyCartAndProduct_WhenUserAddsProductItemsToCart_ThenCartShowsCorrectProductItem()
        {
            // Arrange
            const string expectedProductItemName = "Dove Soap";
            const double expectedProductItemUnitPrice = 39.99;
            const uint expectedProductItemQuantity = 5;

            var product = new Product(expectedProductItemName, expectedProductItemUnitPrice);
            var cart = new ShoppingCart.ShoppingCart();

            // Act
            var productItem = new ProductItem(product, expectedProductItemQuantity);
            cart.AddProductItem(productItem);
            var productItemFromCart = cart.ProductItems.First();

            // Assert
            Assert.That(productItemFromCart.Name, Is.EqualTo(expectedProductItemName));
            Assert.That(productItemFromCart.UnitPrice, Is.EqualTo(expectedProductItemUnitPrice));
            Assert.That(productItemFromCart.Quantity, Is.EqualTo(expectedProductItemQuantity));
        }
    }
}
