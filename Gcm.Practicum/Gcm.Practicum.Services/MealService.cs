using System;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     See IMealService for documentation.
    /// </summary>
    internal class MealService : IMealService
    {
        private const string Morning = "morning";
        private const string Night = "night";

        /// <summary>
        ///     See IMealService for documentation.
        /// </summary>
        public Meal Order(string timeOfDay, string[] dishTypes)
        {
            if (timeOfDay != null)
            {
                // consts are lowercase, so this should be too
                timeOfDay = timeOfDay.ToLower();
            }

            switch (timeOfDay)
            {
                case Morning:
                    return CreateMorningMeal(dishTypes);
                case Night:
                    return CreateNightMeal(dishTypes);
                default:
                    throw new OrderException();
            }
        }

        /// <summary>
        ///     Creates a morning meal from the specified dish types.
        /// </summary>
        /// <param name="dishTypes">Arrary of dish type numbers.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        private Meal CreateNightMeal(string[] dishTypes)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates a morning meal from the specified dish types.
        /// </summary>
        /// <param name="dishTypes">Array of dish type numbers.</param>
        /// <returns></returns>
        private Meal CreateMorningMeal(string[] dishTypes)
        {
            throw new NotImplementedException();
        }
    }
}