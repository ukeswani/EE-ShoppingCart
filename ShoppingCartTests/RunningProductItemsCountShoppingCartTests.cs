using NUnit.Framework;
using ShoppingCart;
using System.Linq;

namespace ShoppingCartTests
{
    [TestFixture]
    class RunningProductsCountShoppingCartTests
    {
        [Test]
        public void GivenNoObject_WhenRunningProductItemsCountShoppingCartCreated_ReturnsAnInstanceOfIProductAddingShoppingCart()
        {
            // Arrange, Act
            var cart = new RunningProductsCountShoppingCart();

            // Assert
            Assert.That(cart, Is.InstanceOf(typeof(IProductAddingShoppingCart)));
        }

        [Test]
        public void GivenEmptyCart_WhenUserAddsXAndThenYItemsOfSameProduct_ThenCartShowsCorrectItemCountForThatProduct()
        {
            // Arrange
            var product = new Product("Dove Soap", 39.99);
            IProductAddingShoppingCart cart = new RunningProductsCountShoppingCart();
            
            // Act
            cart.AddProduct(product, 5);
            cart.AddProduct(product, 3);

            // Assert
            Assert.That(cart.Products.Count(p => p.Name == "Dove Soap"), Is.EqualTo(8));
        }

        [Test]
        public void GivenEmptyCart_WhenUserAddsXAndThenYItemsOfSameProduct_ThenCartShowsCorrectTotalPrice()
        {
            // Arrange
            var product = new Product("Dove Soap", 39.99);
            IProductAddingShoppingCart cart = new RunningProductsCountShoppingCart();

            // Act
            cart.AddProduct(product, 5);
            cart.AddProduct(product, 3);

            // Assert
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(319.92));
        }
    }
}
