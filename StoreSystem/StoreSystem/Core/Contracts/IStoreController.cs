namespace StoreSystem.Core.Contracts
{
    using System;

    using StoreSystem.Models.Products;

    public interface IStoreController
    {
        void AddToCart(Product product);

        void PurchaseProducts(DateTime purchaseDate);
    }
}
