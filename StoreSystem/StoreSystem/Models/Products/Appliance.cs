namespace StoreSystem.Models.Products
{
    using System;
    using System.Text;

    public class Appliance : Product
    {
        public Appliance(string name, string brand, double price,
            string model, double quantity,
            double weight, DateTime productionDate)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Model = model;
            this.Quantity = quantity;
            this.Weight = weight;
            this.ProductionDate = productionDate;
        }

        public string Model { get; set; }

        public double Weight { get; set; }

        public DateTime ProductionDate { get; set; }

        public override int CheckForDiscount(DateTime purchaseDate)
        {
            int discount = 0;

            if (this.Price > 999)
            {
                switch (purchaseDate.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        discount = 5;
                        break;
                    case DayOfWeek.Sunday:
                        discount = 5;
                        break;
                }
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

            result.AppendLine($"{this.Name} {this.Brand} {this.Model}");
            result.AppendLine($"{this.Quantity} x ${this.Price} = ${totalPrice:f2}");

            return result.ToString().TrimEnd();
        }
    }
}
