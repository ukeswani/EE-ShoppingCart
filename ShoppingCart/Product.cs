namespace ShoppingCart
{
    public class Product
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