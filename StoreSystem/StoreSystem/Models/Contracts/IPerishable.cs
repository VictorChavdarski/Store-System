namespace StoreSystem.Models.Contracts
{
    using System;

    public interface IPerishable
    {
        DateTime ExpirationDate { get; set; }
    }
}
