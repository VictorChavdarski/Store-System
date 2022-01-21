namespace StoreSystem.Models
{
    using System;

    using StoreSystem.Models.Products;
    using StoreSystem.Models.Contracts;

    public class Cashier : ICashier
    {
        public void PrintRecipe(ICart cart, DateTime purchaseDate)
        {
            double subtotal = 0;
            double subtotalDiscount = 0;

            Console.WriteLine($"Date: {purchaseDate}\n");
            Console.WriteLine("----- Products -----\n");

            foreach (Product product in cart.Products)
            {
                double currentProductTotalPrice = product.Price * product.Quantity;
                subtotal += currentProductTotalPrice;

                Console.WriteLine(product.PrintOnRecipe());

                int discount = product.CheckForDiscount(purchaseDate);

                if (discount > 0)
                {
                    double totalSumOfDiscount = product.ApplyDiscount(discount);
                    subtotalDiscount += totalSumOfDiscount;

                    Console.WriteLine($"#discount {discount}% -${totalSumOfDiscount:f2}");
                }

                Console.WriteLine();
            }

            double totalSumAfterDiscount = subtotal - subtotalDiscount;

            Console.WriteLine(new String('-', 20));
            Console.WriteLine($"SUBTOTAL: ${subtotal:f2}");
            Console.WriteLine($"DISCOUNT: ${subtotalDiscount:f2}\n");
            Console.WriteLine($"TOTAL: ${totalSumAfterDiscount:f2}");
        }
    }
}
