namespace StoreSystem.Models.Products
{
    using System;
    using System.Text;

    using StoreSystem.Models.Contracts;

    public class Beverage : Product, IPerishable
    {
        public Beverage(string name, string brand, double price,
            double quantity, DateTime expirationDate)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Quantity = quantity;
            this.ExpirationDate = expirationDate;
        }

        public DateTime ExpirationDate { get; set; }

        public override int CheckForDiscount(DateTime purchaseDate)
        {
            int discount = 0;

            if (this.ExpirationDate.Day == purchaseDate.Day)
            {
                discount = 50;
            }
            else if (this.ExpirationDate > purchaseDate && this.ExpirationDate <= purchaseDate.AddDays(5))
            {
                discount = 10;
            }

            return discount;
        }

        public override double ApplyDiscount(int discount)
        {
            double currentProductPrice = this.Price;

            //Applying discount.
            this.Price -= (this.Price * discount) / 100;

            //Calculating total price after discount.
            double totalProductsPrice = (currentProductPrice - this.Price) * this.Quantity;

            return totalProductsPrice;
        }

        public override string PrintOnRecipe()
        {
            double totalPrice = this.Price * this.Quantity;

            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} {this.Brand}");
            result.AppendLine($"{this.Quantity} x ${this.Price} = ${totalPrice:f2}");

            return result.ToString().TrimEnd();
        }
    }
}
