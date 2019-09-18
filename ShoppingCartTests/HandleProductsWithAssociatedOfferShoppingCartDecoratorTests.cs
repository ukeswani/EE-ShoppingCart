using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    class HandleProductsWithAssociatedOfferShoppingCartDecoratorTests
    {
        [Test]
        public void GivenNoObject_WhenDecoratorCreated_ThenReturnsAnInstanceOfIProductAddingShoppingCart()
        {
            // Arrange, Act
            var cart = new HandleProductsWithAssociatedOfferShoppingCartDecorator(Mock.Of<IProductAddingShoppingCart>());

            // Assert
            Assert.That(cart, Is.InstanceOf(typeof(IProductAddingShoppingCart)));
        }

        [Test]
        public void GivenNoObject_WhenDecoratorCreatedWithNullIProductAddingShoppingCart_ThenThrowsException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new HandleProductsWithAssociatedOfferShoppingCartDecorator((IProductAddingShoppingCart) null));
        }

        [Test]
        public void GivenEmptyDecoratorOnRunningProductsCountShoppingCart_WhenProductsWithNoAssociatedOfferAdded_ThenBehavesAsRunningProductsCountShoppingCart()
        {
            // Arrange
            var product1 = new Product("some product", 3.0);
            var product2 = new Product("another product", 5.0);
            var cart = new HandleProductsWithAssociatedOfferShoppingCartDecorator(new RunningProductsCountShoppingCart());

            //Act
            cart.AddProduct(product1, 4);
            cart.AddProduct(product2, 12);
            cart.AddProduct(product2, 8);

            // Assert
            Assert.That(cart.Products.Count(p => p.Name == "another product"), Is.EqualTo(20));
            Assert.That(cart.Products.Count, Is.EqualTo(24));
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(112.00));
        }

        [Test]
        public void GivenEmptyDecoratorOnRunningProductsCountShoppingCart_WhenProductsWithAssociatedOfferAdded_ThenBehavesAsExpected()
        {
            // Arrange
            var product1 = new Product("some product", 3.0);
            var product2 = new Product("another product", 5.0);
            var cart = new HandleProductsWithAssociatedOfferShoppingCartDecorator(new RunningProductsCountShoppingCart());

            IProduct Offer(IProduct product, uint quantity)
            {
                if (quantity >= 1)
                {
                    return new DiscountAsProduct(product.Name + " - Buy 1 get 50% off next", product.UnitPrice / 2);
                }

                return new NullProduct();
            }

            var product1WithOffer = new ProductWithAssociatedOffer(product1, Offer);

            //Act
            cart.AddProduct(product1WithOffer, 4);
            cart.AddProduct(product2, 12);
            cart.AddProduct(product2, 8);
            cart.AddProduct(product1WithOffer, 2);

            // Assert
            Assert.That(cart.GetTotalPrice(), Is.EqualTo(116.50));
            Assert.That(cart.GetTotalDiscount(), Is.EqualTo(1.50));
        }
    }
}
