namespace StoreSystem.Models.Contracts
{
    using System.Collections.Generic;

    using StoreSystem.Models.Products;

    public interface ICart
    {
        ICollection<Product> Products { get; set; }
    }
}
