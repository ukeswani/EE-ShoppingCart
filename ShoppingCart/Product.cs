namespace ShoppingCart
{
    public class Product : IProduct
    {
        public Product(string name, double unitPrice)
        {
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