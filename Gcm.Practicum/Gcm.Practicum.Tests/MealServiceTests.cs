using System;
using System.Linq;
using Gcm.Practicum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gcm.Practicum.Tests
{
    [TestClass]
    public class MealServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Resolve_ThrowsException_WhenUnsupportedServiceIsRequested()
        {
            new ServiceContainer().Resolve<object>();
        }

        [TestMethod]
        public void Resolve_Succeeds_WhenIMealServiceIsRequested()
        {
            Assert.IsInstanceOfType(new ServiceContainer().Resolve<IMealService>(), typeof(MealService));
        }


        [TestMethod]
        public void Order_ThrowsException_WhenInvalidTimeOfDayEntered()
        {
            IMealService mealService = new MealService();

            try
            {
                mealService.Order("foo", new[] { "1" });

                Assert.Fail();
            }
            catch (OrderException ex)
            {
                Assert.IsNull(ex.Meal);
                Assert.AreEqual(ex.ToString(), "error");
            }
        }

        [TestMethod]
        public void Order_ReturnsMeal_WhenMorningEggsToastCoffeeRequested()
        {
            IMealService mealService = new MealService();
            var meal = mealService.Order("morning", new[] { "1", "2", "3" });
            Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "eggs");
            Assert.IsTrue(meal.Sides.Length == 1 && meal.Sides[0] == "toast");
            Assert.IsTrue(meal.Drinks.Length == 1 && meal.Drinks[0] == "coffee");
            Assert.IsTrue(meal.Desserts.Length == 0);
        }


        /// <summary>
        /// Validates that order doesn't matter
        /// </summary>
        [TestMethod]
        public void Order_ReturnsMeal_WhenMorningToastEggsCoffeeRequested()
        {
            IMealService mealService = new MealService();
            var meal = mealService.Order("morning", new[] { "1", "2", "3" });
            Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "eggs");
            Assert.IsTrue(meal.Sides.Length == 1 && meal.Sides[0] == "toast");
            Assert.IsTrue(meal.Drinks.Length == 1 && meal.Drinks[0] == "coffee");
            Assert.IsTrue(meal.Desserts.Length == 0);
        }

        [TestMethod]
        public void Order_ThrowsMealException_WhenMorningToastEggsCoffeeDessertRequested()
        {
            try
            {
                IMealService mealService = new MealService();
                mealService.Order("morning", new[] { "1", "2", "3", "4" });

                Assert.Fail();
            }
            catch (OrderException ex)
            {
                Assert.IsNotNull(ex.Meal);
                var meal = ex.Meal;
                Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "eggs");
                Assert.IsTrue(meal.Sides.Length == 1 && meal.Sides[0] == "toast");
                Assert.IsTrue(meal.Drinks.Length == 1 && meal.Drinks[0] == "coffee");
                Assert.IsTrue(meal.Desserts.Length == 0);
                Assert.AreEqual(ex.ToString(), "eggs, toast, coffee, error");
            }
        }

        /// <summary>
        /// Validates multiple coffees are supported for breakfast.
        /// </summary>
        [TestMethod]
        public void Order_ReturnsMeal_WhenMorningEggsToastCoffeex3Requested()
        {
            IMealService mealService = new MealService();
            var meal = mealService.Order("morning", new[] { "1", "2", "3", "3", "3" });
            Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "eggs");
            Assert.IsTrue(meal.Sides.Length == 1 && meal.Sides[0] == "toast");
            Assert.IsTrue(meal.Drinks.Length == 3 && meal.Drinks.All(d => d == "coffee"));
            Assert.IsTrue(meal.Desserts.Length == 0);
        }

        [TestMethod]
        public void Order_ReturnsMeal_WhenNightSteakPotatoWineCakeRequested()
        {
            IMealService mealService = new MealService();
            var meal = mealService.Order("morning", new[] { "1", "2", "3", "4" });
            Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "steak");
            Assert.IsTrue(meal.Sides.Length == 1 && meal.Sides[0] == "potato");
            Assert.IsTrue(meal.Drinks.Length == 1 && meal.Drinks[0] == "wine");
            Assert.IsTrue(meal.Desserts.Length == 1 && meal.Desserts[0] == "cake");
        }

        /// <summary>
        /// Validates multiple potatos are supported at night.
        /// </summary>
        [TestMethod]
        public void Order_ReturnsMeal_WhenNightSteakPotatox2CakeRequested()
        {
            IMealService mealService = new MealService();
            var meal = mealService.Order("morning", new[] { "1", "2", "3", "4" });
            Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "steak");
            Assert.IsTrue(meal.Sides.Length == 1 && meal.Sides[0] == "potato");
            Assert.IsTrue(meal.Drinks.Length == 0);
            Assert.IsTrue(meal.Desserts.Length == 1 && meal.Desserts[0] == "cake");
        }

        [TestMethod]
        public void Order_ThrowsMealException_WhenNightSteakPotatoWineInvalidDishTypeRequested()
        {
            try
            {
                IMealService mealService = new MealService();
                mealService.Order("night", new[] { "1", "2", "3", "5" });

                Assert.Fail();
            }
            catch (OrderException ex)
            {
                Assert.IsNotNull(ex.Meal);
                var meal = ex.Meal;
                Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "steak");
                Assert.IsTrue(meal.Sides.Length == 1 && meal.Sides[0] == "potato");
                Assert.IsTrue(meal.Drinks.Length == 1 && meal.Drinks[0] == "wine");
                Assert.IsTrue(meal.Desserts.Length == 0);
                Assert.AreEqual(ex.ToString(), "steak, potato, wine, error");
            }
        }

        /// <summary>
        /// Tests that multiple entrees are not supported at night.
        /// </summary>
        [TestMethod]
        public void Order_ThrowsMealException_WhenNightSteakSteakPotatoWineInvalidDishTypeRequested()
        {
            try
            {
                IMealService mealService = new MealService();
                mealService.Order("night", new[] { "1", "1", "2", "3", "5" });

                Assert.Fail();
            }
            catch (OrderException ex)
            {
                Assert.IsNotNull(ex.Meal);
                var meal = ex.Meal;
                Assert.IsTrue(meal.Entrees.Length == 1 && meal.Entrees[0] == "steak");
                Assert.IsTrue(meal.Sides.Length == 0);
                Assert.IsTrue(meal.Drinks.Length == 0);
                Assert.IsTrue(meal.Desserts.Length == 0);
                Assert.AreEqual(ex.ToString(), "steak, error");
            }
        }
    }
}