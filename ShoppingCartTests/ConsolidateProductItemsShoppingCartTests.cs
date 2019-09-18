using Moq;
using NUnit.Framework;
using ShoppingCart;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartTests
{
    [TestFixture]
    class ConsolidateProductItemsShoppingCartTests
    {
        [Test]
        public void GivenNoObject_WhenCreatingNewConsolidateProductItemsShoppingCart_ReturnsAnInstanceOfIShoppingCart()
        {
            // Arrange, Act
            var shoppingCart = new ConsolidateProductItemsShoppingCart();

            // Assert
            Assert.That(shoppingCart, Is.InstanceOf(typeof(IShoppingCart)));
        }

        [Test]
        public void GivenConsolidateProductItemsShoppingCart_WhenAddTwoProductItemsWithSameName_ThenContainsSingleProductItemWithCombinedQuantity()
        {
            // Arrange
            var shoppingCart = new ConsolidateProductItemsShoppingCart();

            var firstProductItem = new Mock<IProductItem>();
            firstProductItem.Setup(pi => pi.Name).Returns("product name");
            firstProductItem.Setup(pi => pi.Quantity).Returns(10);
            IAddableProductItem addableProductItem = new AddableProductItem(firstProductItem.Object);

            var secondProductItem = new Mock<IProductItem>();
            secondProductItem.Setup(pi => pi.Name).Returns("product name");
            secondProductItem.Setup(pi => pi.Quantity).Returns(7);

            // Act
            shoppingCart.AddProductItem(firstProductItem.Object);
            shoppingCart.AddProductItem(secondProductItem.Object);


            // Assert
            Assert.That(shoppingCart.ProductItems.First().Quantity, Is.EqualTo(17));
        }
    }

    internal class ConsolidateProductItemsShoppingCart : IShoppingCart
    {
        private readonly Dictionary<string, AddableProductItem> _productItems;

        public ConsolidateProductItemsShoppingCart()
        {
            _productItems = new Dictionary<string, AddableProductItem>();
        }

        public void AddProductItem(IProductItem productItem)
        {            
            if (_productItems.Keys.Contains(productItem.Name))
            {
                _productItems[productItem.Name].Add(productItem);
                return;
            }
           
            _productItems.Add(productItem.Name, new AddableProductItem(productItem));
        }

        public IEnumerable<IProductItem> ProductItems => _productItems.Values;

        public double TotalPrice => _productItems.Values.Select(pi => pi.Price).Sum();
    }
}
