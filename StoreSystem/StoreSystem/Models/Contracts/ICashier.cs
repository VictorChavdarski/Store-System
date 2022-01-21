namespace StoreSystem.Models.Contracts
{
    using System;

    public interface ICashier
    {
        void PrintRecipe(ICart cart, DateTime purchaseDate);
    }
}
