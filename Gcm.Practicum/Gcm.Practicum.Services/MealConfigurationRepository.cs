using System.Collections.Generic;
using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Implementation of IMealConfigurationRepository.
    /// </summary>
    internal class MealConfigurationRepository : IMealConfigurationRepository
    {
        // In production, this might come from a database
        private static readonly MealConfiguration[] MealConfigurations =
        {
            new MealConfiguration(TimeOfDay.Morning,
                new Dish(DishType.Entree, "eggs"),
                new Dish(DishType.Side, "toast"),
                new Dish(DishType.Drink, "coffee", true)
                ),
            new MealConfiguration(TimeOfDay.Night,
                new Dish(DishType.Entree, "steak"),
                new Dish(DishType.Side, "potato", true),
                new Dish(DishType.Drink, "wine"),
                new Dish(DishType.Dessert, "cake")
                )
        };

        private static readonly Dictionary<TimeOfDay, MealConfiguration> MealConfigurationsByTimeOfDay = MealConfigurations.ToDictionary(c => c.TimeOfDay);

        public MealConfiguration GetMealConfigurationByTimeOfDay(TimeOfDay timeOfDay)
        {
            MealConfiguration configuration;
            if (!MealConfigurationsByTimeOfDay.TryGetValue(timeOfDay, out configuration))
            {
                throw new OrderException(string.Format("TimeOfDay {0} is not supported.", timeOfDay));
            }
            return configuration;
        }
    }
}