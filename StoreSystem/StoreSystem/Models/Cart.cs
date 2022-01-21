namespace StoreSystem.Models
{
    using System.Collections.Generic;

    using StoreSystem.Models.Products;
    using StoreSystem.Models.Contracts;

    public class Cart : ICart
    {
        public Cart()
        {
            this.Products = new List<Product>();
        }

        public ICollection<Product> Products { get; set; }
    }
}
