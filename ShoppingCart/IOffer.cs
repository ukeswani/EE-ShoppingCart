using System;

namespace ShoppingCart
{
    public interface IOffer
    {
        Func<IProduct, uint, IProduct> GetOffer();
    }
}