using NUnit.Framework;
using ShoppingCart;
using System.Linq;

namespace ShoppingCartTests
{
    [TestFixture]
    class Story2Tests
    {
        [Test]
        public void GivenEmptyCartAndProduct_WhenUserAddsProductItemsToCart_ThenCartShowsCorrectTotalPrice()
        {
            // Arrange
            var product = new Product("Dove Soap", 39.99);
            var cart = new ConsolidateProductItemsShoppingCart();

            var firstProductItem = new ProductItem(product, 5);
            cart.AddProductItem(firstProductItem);

            var secondProductItem = new ProductItem(product, 3);
            cart.AddProductItem(secondProductItem);

            // Act
            var productItemFromCart = cart.ProductItems.First();

            // Assert
            Assert.That(productItemFromCart.Quantity, Is.EqualTo(8));
        }
    }
}
