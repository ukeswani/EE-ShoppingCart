using System;

namespace ShoppingCart
{
    public class Product : IProduct
    {
        public Product(string name, double unitPrice)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"Invalid value for {nameof(name)}. Value provided: {name}");
            }

            if (unitPrice < 0.00)
            {
                throw new ArgumentException($"Invalid value for {nameof(unitPrice)}. Value provided: {unitPrice}");
            }

            Name = name;
            UnitPrice = unitPrice;
        }

        public double UnitPrice
        {
            get;
        }

        public string Name
        {
            get;
        }
    }
}