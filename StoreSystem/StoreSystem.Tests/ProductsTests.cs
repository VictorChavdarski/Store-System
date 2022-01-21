namespace StoreSystem.Tests
{
    using System;

    using NUnit.Framework;

    using StoreSystem.Models.Products;
    using StoreSystem.Utilities.Enums;

    public class ProdutsTests
    {
        private Food food;
        private Beverage beverage;
        private Cloth cloth;
        private Appliance appliance;

        [SetUp]
        public void Setup()
        {
            food = new Food("TestFoodName", "TestBrand", 1, 1, DateTime.Now);
            beverage = new Beverage("TestBeverageName", "TestBrand", 1, 1, DateTime.Now);
            cloth = new Cloth("TestClothName", "TestBrand", 1, 1, "TestColor", ClothSize.M);
            appliance = new Appliance("TestApplianceName", "TestBrand", 1, "TestModel", 1, 1, DateTime.Now);
        }

        [Test]
        public void WhenFoodIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("TestFoodName", food.Name);
            Assert.AreEqual("TestBrand", food.Brand);
            Assert.AreEqual(1, food.Price);
            Assert.AreEqual(1, food.Quantity);
            Assert.AreEqual(DateTime.Now.Day, food.ExpirationDate.Day);
        }

        [Test]
        public void WhenBeverageIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("TestBeverageName", beverage.Name);
            Assert.AreEqual("TestBrand", beverage.Brand);
            Assert.AreEqual(1, beverage.Price);
            Assert.AreEqual(1, beverage.Quantity);
            Assert.AreEqual(DateTime.Now.Day, beverage.ExpirationDate.Day);
        }

        [Test]
        public void WhenClothIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("TestClothName", cloth.Name);
            Assert.AreEqual("TestBrand", cloth.Brand);
            Assert.AreEqual(1, cloth.Price);
            Assert.AreEqual(1, cloth.Quantity);
            Assert.AreEqual("TestColor", cloth.Color);
            Assert.AreEqual(ClothSize.M, cloth.ClothSize);
        }

        [Test]
        public void WhenApplianceIsCreated_PropertiesShouldBeSet()
        {
            Assert.AreEqual("TestApplianceName", appliance.Name);
            Assert.AreEqual("TestBrand", appliance.Brand);
            Assert.AreEqual(1, appliance.Price);
            Assert.AreEqual("TestModel", appliance.Model);
            Assert.AreEqual(1, appliance.Quantity);
            Assert.AreEqual(1, appliance.Weight);
            Assert.AreEqual(DateTime.Now.Day, appliance.ProductionDate.Day);
        }

        [Test]
        public void WhenFoodExpirationDateIsEqualToPurchaseDate_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 22);

            food.ExpirationDate = purchaseDate;

            int disocunt = food.CheckForDiscount(purchaseDate);

            Assert.AreEqual(50, disocunt);
        }

        [Test]
        public void WhenFoodExpirationDateIsWithinNextFiveDays_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 22);

            food.ExpirationDate = new DateTime(2022,1,23);

            int disocunt = food.CheckForDiscount(purchaseDate);

            Assert.AreEqual(10, disocunt);
        }

        [Test]
        public void WhenBeverageExpirationDateIsEqualToPurchaseDate_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 22);

            beverage.ExpirationDate = purchaseDate;

            int disocunt = beverage.CheckForDiscount(purchaseDate);

            Assert.AreEqual(50, disocunt);
        }

        [Test]
        public void WhenBeverageExpirationDateIsWithinNextFiveDays_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 22);

            beverage.ExpirationDate = new DateTime(2022, 1, 23);

            int disocunt = beverage.CheckForDiscount(purchaseDate);

            Assert.AreEqual(10, disocunt);
        }

        [Test]
        public void WhenClothIsBoughtDuringWeekdays_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 24); //Monday
           
            int disocunt = cloth.CheckForDiscount(purchaseDate);

            Assert.AreEqual(10, disocunt);
        }

        [Test]
        public void WhenClothIsBoughtDuringWeekend_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 23); //Sunday

            int disocunt = cloth.CheckForDiscount(purchaseDate);

            Assert.AreEqual(0, disocunt);
        }

        [Test]
        public void WhenApplianceIsBoughtDuringWeekendAndPriceIsAbove999_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 23); //Sunday

            appliance.Price = 1000;

            int disocunt = appliance.CheckForDiscount(purchaseDate);

            Assert.AreEqual(5, disocunt);
        }

        [Test]
        public void WhenApplianceIsBoughtDuringWeekdays_CheckForDiscountShouldWorkProperly()
        {
            DateTime purchaseDate = new(2022, 1, 24); //Monday

            appliance.Price = 1000;

            int disocunt = appliance.CheckForDiscount(purchaseDate);

            Assert.AreEqual(0, disocunt);
        }
    }
}