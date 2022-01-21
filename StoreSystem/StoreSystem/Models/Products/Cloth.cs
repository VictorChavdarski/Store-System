namespace StoreSystem.Models.Products
{
    using System;
    using System.Text;

    using StoreSystem.Utilities.Enums;

    public class Cloth : Product
    {
        public Cloth(string name, string brand, double price, double quantity, string color,ClothSize size)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Quantity = quantity;
            this.Color = color;
            this.ClothSize = size;
        }

        public string Color { get; set; }

        public ClothSize ClothSize { get; set; }

        public override int CheckForDiscount(DateTime purchaseDate)
        {
            int discount = 0;

            switch (purchaseDate.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    discount = 10;
                    break;
                case DayOfWeek.Tuesday:
                    discount = 10;
                    break;
                case DayOfWeek.Wednesday:
                    discount = 10;
                    break;
                case DayOfWeek.Thursday:
                    discount = 10;
                    break;
                case DayOfWeek.Friday:
                    discount = 10;
                    break;
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

            result.AppendLine($"{this.Name} {this.Brand} {this.ClothSize} {this.Color}");
            result.AppendLine($"{this.Quantity} x ${this.Price} = ${totalPrice:f2}");

            return result.ToString().TrimEnd();
        }
    }
}
