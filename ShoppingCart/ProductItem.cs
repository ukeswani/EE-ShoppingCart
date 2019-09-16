namespace ShoppingCart
{
    public class ProductItem
    {
        private readonly Product _product;

        public ProductItem(Product product, uint quantity)
        {
            _product = product;
            Quantity = quantity;
        }

        public double UnitPrice => _product.UnitPrice;

        public uint Quantity
        {
            get;
        }
    }
}