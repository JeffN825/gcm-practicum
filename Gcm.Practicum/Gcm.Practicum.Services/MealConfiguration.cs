using System.Collections.Generic;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Describes a configuration of what may be served for a meal. In production this might be stored in a database.
    /// </summary>
    internal class MealConfiguration
    {
        public MealConfiguration(TimeOfDay timeOfDay, params Dish[] dishes)
        {
            TimeOfDay = timeOfDay;
            Dishes = dishes;
        }

        public TimeOfDay TimeOfDay { get; private set; }
        public IEnumerable<Dish> Dishes { get; private set; }
    }
}