namespace StoreSystem.Core
{
    using System;

    using StoreSystem.Models;
    using StoreSystem.Core.Contracts;
    using StoreSystem.Models.Products;
    using StoreSystem.Models.Contracts;

    public class StoreController : IStoreController
    {
        private readonly ICart cart;
        private readonly ICashier cashier;

        public StoreController()
        {
            this.cart = new Cart();
            this.cashier = new Cashier();
        }

        public void AddToCart(Product product)
        {
            this.cart.Products.Add(product);
        }

        public void PurchaseProducts(DateTime purchaseDate)
        {
            this.cashier.PrintRecipe(cart, purchaseDate);
            this.cart.Products.Clear();
        }
    }
}
