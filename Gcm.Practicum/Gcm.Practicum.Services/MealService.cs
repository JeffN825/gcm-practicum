using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     See IMealService for documentation.
    /// </summary>
    internal class MealService : IMealService
    {
        // In production, this might come from a database
        private static readonly MealConfiguration[] MealConfigurations =
        {
            new MealConfiguration("morning",
                new Dish(DishType.Entree, "eggs"),
                new Dish(DishType.Side, "toast"),
                new Dish(DishType.Drink, "coffee", true)
                ),
            new MealConfiguration("night",
                new Dish(DishType.Entree, "steak"),
                new Dish(DishType.Side, "potato", true),
                new Dish(DishType.Drink, "wine"),
                new Dish(DishType.Dessert, "cake")
                )
        };

        private static readonly Dictionary<string, MealConfiguration> MealConfigurationsByTimeOfDay = MealConfigurations.ToDictionary(c => c.TimeOfDay);

        private static readonly Dictionary<string, DishType> DishTypesById = Enum.GetValues(typeof (DishType)).OfType<DishType>().ToDictionary(i => ((int)i).ToString());

        /// <summary>
        ///     See IMealService for documentation.
        /// </summary>
        public Meal Order(string timeOfDay, string[] dishTypes)
        {
            if (timeOfDay == null)
            {
                throw new ArgumentNullException("timeOfDay");
            }

            if (dishTypes == null)
            {
                throw new ArgumentNullException("dishTypes");
            }

            // consts are lowercase, so this should be too
            timeOfDay = timeOfDay.ToLower();

            MealConfiguration configuration;
            if (!MealConfigurationsByTimeOfDay.TryGetValue(timeOfDay, out configuration))
            {
                throw new OrderException();
            }

            Meal meal = CreateMeal(configuration, dishTypes);

            return meal;
        }

        /// <summary>
        ///     Creates a meal from the specified dish types based on the configuration provided.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="dishTypes">Array of dish type numbers.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private Meal CreateMeal(MealConfiguration configuration, string[] dishTypes)
        {
            // group so we can get a count of each dish type requested
            IEnumerable<IGrouping<string, string>> groupedDishTypes = dishTypes.GroupBy(i => i);

            var meal = new Meal();

            foreach (var group in groupedDishTypes)
            {
                DishType dishType;
                if (!DishTypesById.TryGetValue(group.Key, out dishType))
                {
                    // not a valid dish type
                    throw new OrderException(meal);
                }

                Dish dish;

                if (!configuration.DishesByType.TryGetValue(dishType, out dish))
                {
                    // dish type not supported
                    throw new OrderException(meal);
                }

                int count = group.Count();

                if (count > 1 && !dish.AllowMultiple)
                {
                    // add 1 dish even though we will throw an exception because they tried to order more than 1
                    meal.Dishes.Add(dish);
                    // multiples dishes are not supported
                    throw new OrderException(meal);
                }

                for (int i = 0; i < count; i++)
                {
                    // add dishes multiple times if necessary
                    meal.Dishes.Add(dish);
                }
            }

            return meal;
        }
    }
}