namespace ShoppingCart
{
    public interface IAddableProductItem : IProductItem
    {
        void Add(IProductItem productItemToAdd);
    }
}