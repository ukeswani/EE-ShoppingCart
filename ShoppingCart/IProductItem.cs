namespace ShoppingCart
{
    public interface IProductItem
    {
        string Name { get; }

        double UnitPrice { get; }

        uint Quantity { get; }

        double Price { get; }

    }
}