using Moq;
using NUnit.Framework;
using ShoppingCart;
using System.Linq;

namespace ShoppingCartTests
{
    [TestFixture]
    class ShoppingCartTests
    {
        [Test]
        public void GivenNoObject_WhenCreatingShoppingCart_ReturnsAnInstanceOfIShoppingCart()
        {
            // Arrange, Act
            var shoppingCart = CreateShoppingCart();

            // Assert
            Assert.That(shoppingCart, Is.InstanceOf(typeof(IShoppingCart)));
        }

        [Test]
        public void GivenNoObject_WhenCreatingShoppingCart_ReturnsAnInstanceOfIShoppingCartWriter()
        {
            // Arrange, Act
            var shoppingCart = CreateShoppingCart();

            // Assert
            Assert.That(shoppingCart, Is.InstanceOf(typeof(IShoppingCartWriter)));
        }

        [Test]
        public void GivenNoObject_WhenCreatingShoppingCart_ReturnsAnInstanceOfIShoppingCartReader()
        {
            // Arrange, Act
            var shoppingCart = CreateShoppingCart();

            // Assert
            Assert.That(shoppingCart, Is.InstanceOf(typeof(IShoppingCartReader)));
        }

        [Test]
        public void GivenEmptyShoppingCart_WhenAddingProductItem_ThenContainsExpectedProductItem()
        {
            // Arrange
            var productItem = Mock.Of<IProductItem>();
            IShoppingCart shoppingCart = CreateShoppingCart();

            // Act
            shoppingCart.AddProductItem(productItem);


            // Assert
            Assert.That(shoppingCart.ProductItems.First(), Is.EqualTo(productItem));
        }

        [Test]
        public void GivenShoppingCartWithThreeItems_WhenGettingTotalPrice_ThenReturnsSumOfPriceOfContainedItems()
        {
            // Arrange
            IShoppingCart shoppingCart = CreateShoppingCart();

            var firstItemPrice = 100.00;
            var secondItemPrice = 0.65;
            var thirdItemPrice = 14.25;

            var firstProductItem = new Mock<IProductItem>();
            firstProductItem.Setup(pi => pi.Price).Returns(firstItemPrice);
            var secondProductItem = new Mock<IProductItem>();
            secondProductItem.Setup(pi => pi.Price).Returns(secondItemPrice);
            var thirdProductItem = new Mock<IProductItem>();
            thirdProductItem.Setup(pi => pi.Price).Returns(thirdItemPrice);
            
            shoppingCart.AddProductItem(firstProductItem.Object);
            shoppingCart.AddProductItem(secondProductItem.Object);
            shoppingCart.AddProductItem(thirdProductItem.Object);
            
            // Act
            var totalPrice = shoppingCart.TotalPrice;


            // Assert
            Assert.That(totalPrice, Is.EqualTo(firstItemPrice + secondItemPrice + thirdItemPrice));
        }

        [Test]
        public void GivenShoppingCartWithZeroItems_WhenGettingTotalPrice_ThenReturnsZero()
        {
            // Arrange
            IShoppingCart shoppingCart = CreateShoppingCart();
           
            // Act
            var totalPrice = shoppingCart.TotalPrice;
            
            // Assert
            Assert.That(totalPrice, Is.Zero);
        }

        private IShoppingCart CreateShoppingCart()
        {
            return new ShoppingCart.ShoppingCart();
        }
    }
}
