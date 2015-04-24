using System.Collections.Generic;
using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Describes a configuration of what may be served for a meal. In production this might be stored in a database.
    /// </summary>
    internal class MealConfiguration
    {
        public MealConfiguration(string timeOfDay, params Dish[] dishes)
        {
            TimeOfDay = timeOfDay;
            Dishes = dishes;
            DishesByType = dishes.ToDictionary(d => d.DishType);
        }

        public string TimeOfDay { get; private set; }
        public IEnumerable<Dish> Dishes { get; private set; }
        public Dictionary<DishType, Dish> DishesByType { get; private set; }
    }
}