using Moq;
using NUnit.Framework;
using ShoppingCart;
using System;

namespace ShoppingCartTests
{
    [TestFixture]
    class TotalPriceAdditionalProcessingShoppingCartDecoratorTests
    {
        [Test]
        public void GivenNoObject_WhenCreatingObjectWithNullIProductAddingShoppingCartInstance_ThenThrowsArgumentNullException()
        {
            // Arrange
            Func<double, double> additionalProcessing = (a) => a;

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new TotalPriceAdditionalProcessingShoppingCartDecorator(null, additionalProcessing));
        }

        [Test]
        public void GivenNoObject_WhenCreatingObjectWithNullAdditionalProcessingFunc_ThenThrowsArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new TotalPriceAdditionalProcessingShoppingCartDecorator(Mock.Of<IProductAddingShoppingCart>(), null));
        }

        [Test]
        public void GivenNoObject_WhenDecoratorObjectCreated_ThenReturnsAnInstanceOfIProductAddingShoppingCart()
        {
            // Arrange, Act, 
            Func<double, double> additionalProcessing = (a) => a;
            var decorator = new TotalPriceAdditionalProcessingShoppingCartDecorator(Mock.Of<IProductAddingShoppingCart>(), additionalProcessing);

            // Assert;
            Assert.That(decorator, Is.InstanceOf(typeof(IProductAddingShoppingCart)));
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(-50)]
        public void GivenNoObject_WhenDecoratorObjectCreated_ThenReturnsAnInstanceOfIProductAddingShoppingCart(int addToTotalPrice)
        {
            // Arrange, Act, 
            Func<double, double> additionalProcessing = (a) => a + addToTotalPrice;
            var decorator = new TotalPriceAdditionalProcessingShoppingCartDecorator(new RunningProductsCountShoppingCart(), additionalProcessing);
            decorator.AddProduct(new Product("Dove Soap", 39.99), 5);

            // Assert;
            Assert.That(decorator.GetTotalPrice(), Is.EqualTo(199.95 + addToTotalPrice));
        }
    }
}
