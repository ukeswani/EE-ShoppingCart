namespace ShoppingCart
{
    public class Product : IProduct
    {
        public Product(string name, double unitPrice)
        {
            UnitPrice = unitPrice;
        }

        public double UnitPrice
        {
            get;
        }
    }
}