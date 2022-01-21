namespace StoreSystem.Core
{
    using System;

    using StoreSystem.Core.Contracts;
    using StoreSystem.Models.Products;
    using StoreSystem.Utilities.Enums;

    public class Engine : IEngine
    {
        private readonly IStoreController controller;

        public Engine()
        {
            this.controller = new StoreController();
        }

        public void Run()
        {
            /* Choose what dates you will use to test the discounts.
            Тhere is a case in which the expiration date of food and beverages has expired completely,
            but in the condition of the task there is no mention of what to do in such a case,
            so I decided not to add a solution. */

            DateTime purchaseDate = new(2022, 1, 22);
            DateTime expirationDate = new(2022, 1, 22);

            //Created some products and added quantity as property of the classes.
            Product food = new Food("Apples", "Lidl", 1.50, 2.45, expirationDate);
            Product baverage = new Beverage("Energy Drink", "Monster", 2, 2, expirationDate);
            Product appliance = new Appliance("Laptop", "Asus", 2000, "Rog", 1, 2.5, DateTime.Now);
            Product cloth = new Cloth("Hoodie", "Nike", 120, 2, "Grey", ClothSize.M);

            this.controller.AddToCart(food);
            this.controller.AddToCart(baverage);
            this.controller.AddToCart(appliance);
            this.controller.AddToCart(cloth);

            this.controller.PurchaseProducts(purchaseDate);
        }
    }
}
