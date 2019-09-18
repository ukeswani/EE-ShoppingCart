namespace ShoppingCart
{
    public class DiscountAsProduct : IProduct
    {
        public DiscountAsProduct(string discountName, double discountAmount)
        {
            Name = discountName;
            UnitPrice = -1 * discountAmount;
        }

        public string Name { get; }

        public double UnitPrice { get; }
    }
}