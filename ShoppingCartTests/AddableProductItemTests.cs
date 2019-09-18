using System;
using Moq;
using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    class AddableProductItemTests
    {
        [Test]
        public void GivenNoObject_WhenAddableProductItemCreated_ThenReturnsAnInstanceOfIProductItem()
        {
            // Arrange, Act
            var addableProductItem = new AddableProductItem(Mock.Of<IProductItem>());

            // Assert
            Assert.That(addableProductItem, Is.InstanceOf(typeof(IProductItem)));
        }
   
        [Test]
        public void GivenNoObject_WhenAddableProductItemCreated_ThenReturnsAnInstanceOfIAddableProductItem()
        {
            // Arrange, Act
            var addableProductItem = new AddableProductItem(Mock.Of<IProductItem>());

            // Assert
            Assert.That(addableProductItem, Is.InstanceOf(typeof(IAddableProductItem)));
        }

        [Test]
        public void GivenAddableProductItem_WhenAddCalledWithNullProductItem_ThenThrowsArgumentNullException()
        {
            // Arrange
            IAddableProductItem addableProductItem = new AddableProductItem(Mock.Of<IProductItem>());

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => addableProductItem.Add(null));
        }

        [Test]
        public void GivenAddableProductItem_WhenAddCalledWithInvalidProductItem_ThenThrowsArgumentException()
        {
            // Arrange
            var productItemToAddTo = new Mock<IProductItem>();
            productItemToAddTo.Setup(pi => pi.Name).Returns("Some product name");
            IAddableProductItem addableProductItem = new AddableProductItem(productItemToAddTo.Object);

            var productItemToAdd = new Mock<IProductItem>();
            productItemToAdd.Setup(pi => pi.Name).Returns("Different product name");

            // Act, Assert
            Assert.Throws<ArgumentException>(() => addableProductItem.Add(productItemToAdd.Object));
        }

        [Test]
        public void GivenAddableProductItem_WhenAddCalledWithValidProductItem_ThenReturnsCombinedQuantity()
        {
            // Arrange
            var productItemToAddTo = new Mock<IProductItem>();
            productItemToAddTo.Setup(pi => pi.Name).Returns("product name");
            productItemToAddTo.Setup(pi => pi.Quantity).Returns(10);
            IAddableProductItem addableProductItem = new AddableProductItem(productItemToAddTo.Object);

            var productItemToAdd = new Mock<IProductItem>();
            productItemToAdd.Setup(pi => pi.Name).Returns("product name");
            productItemToAdd.Setup(pi => pi.Quantity).Returns(7);

            // Act, Assert
            addableProductItem.Add(productItemToAdd.Object);

            // Assert
            Assert.That(addableProductItem.Quantity, Is.EqualTo(17));
        }
    }
}
