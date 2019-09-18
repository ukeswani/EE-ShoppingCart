namespace ShoppingCart
{
    public class NullProduct : IProduct
    {
        public string Name => "Null Product";

        public double UnitPrice => 0.00;
    }
}