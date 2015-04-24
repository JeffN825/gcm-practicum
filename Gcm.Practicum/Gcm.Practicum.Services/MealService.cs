using System;
using System.Collections.Generic;
using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Implementation of IMealService.
    /// </summary>
    internal class MealService : IMealService
    {
        private readonly IMealConfigurationRepository dishRepository;

        public MealService(IMealConfigurationRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        /// <summary>
        ///     See IMealService for documentation.
        /// </summary>
        public Meal Order(TimeOfDay timeOfDay, params DishType[] dishTypes)
        {
            if (!Enum.IsDefined(typeof (TimeOfDay), timeOfDay))
            {
                throw new ArgumentOutOfRangeException("timeOfDay");
            }

            MealConfiguration configuration = dishRepository.GetMealConfigurationByTimeOfDay(timeOfDay);

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
        private Meal CreateMeal(MealConfiguration configuration, IEnumerable<DishType> dishTypes)
        {
            // group so we can get a count of each dish type requested
            IEnumerable<IGrouping<DishType, DishType>> groupedDishTypes = dishTypes.GroupBy(i => i);

            // to dictionary for fast lookup
            Dictionary<DishType, Dish> dishesByType = configuration.Dishes.ToDictionary(d => d.DishType);

            var meal = new Meal();

            foreach (var group in groupedDishTypes)
            {
                Dish dish;

                if (!Enum.IsDefined(typeof (DishType), group.Key))
                {
                    throw new OrderException(string.Format("{0} is not a valid DishType.", group.Key), meal);
                }

                if (!dishesByType.TryGetValue(group.Key, out dish))
                {
                    throw new OrderException(string.Format("{0} is not a valid DishType for {1}.", group.Key, configuration.TimeOfDay), meal);
                }

                int count = group.Count();

                if (count > 1 && !dish.AllowMultiple)
                {
                    // add 1 dish even though we will throw an exception because they tried to order more than 1
                    meal.Dishes.Add(dish);

                    throw new OrderException(string.Format("Only 1 {0} is allowed at {1}.", dish.Name, configuration.TimeOfDay), meal);
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