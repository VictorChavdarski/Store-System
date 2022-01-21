namespace StoreSystem.Models.Products
{
    using System;

    public abstract class Product
    {
        public string Name { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public abstract int CheckForDiscount(DateTime purchaseDate);

        public abstract double ApplyDiscount(int discount);

        public abstract string PrintOnRecipe();
    }
}
