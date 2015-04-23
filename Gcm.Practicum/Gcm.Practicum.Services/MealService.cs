using System;
using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     See IMealService for documentation.
    /// </summary>
    internal class MealService : IMealService
    {
        private static readonly string[] validTimesOfDay = {"morning", "night"};

        /// <summary>
        ///     See IMealService for documentation.
        /// </summary>
        public Meal Order(string timeOfDay, string dishTypes)
        {
            if (!validTimesOfDay.Contains(timeOfDay, StringComparer.OrdinalIgnoreCase))
            {
                throw new OrderException(timeOfDay, null);
            }

            throw new NotImplementedException();
        }
    }
}