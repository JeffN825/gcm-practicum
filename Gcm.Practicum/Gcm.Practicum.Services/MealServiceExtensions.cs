using System;
using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Extensions for IMealService.
    /// </summary>
    public static class MealServiceExtensions
    {
        /// <summary>
        ///     Orders the specified time of day.
        /// </summary>
        /// <param name="mealService">The meal service.</param>
        /// <param name="timeOfDay">The time of day. Valid values: morning, night (case insensitive)</param>
        /// <param name="dishTypes">
        ///     A list of dish types. Valid values for items in list: 1, 2, 3, 4.
        ///     The meaning of each number is:
        ///     1 (entrée): eggs in the morning, steak at night
        ///     2 (side): toast in the morning, potato at night (multiple are allowed)
        ///     3 (drink): coffee in the morning (multiple are allowed), wine at night
        ///     4 (dessert): none in the morning, cake at night
        /// </param>
        /// ///
        /// <returns></returns>
        public static Meal Order(this IMealService mealService, string timeOfDay, params string[] dishTypes)
        {
            if (timeOfDay == null)
            {
                throw new ArgumentNullException("timeOfDay");
            }

            TimeOfDay timeOfDayEnum;
            if (!Enum.TryParse(timeOfDay, true, out timeOfDayEnum))
            {
                throw new OrderException(string.Format("{0} is not a valid TimeOfDay.", timeOfDay));
            }

            DishType[] dishTypeEnums = dishTypes.Select(dt =>
            {
                int dishTypeId;
                int.TryParse(dt, out dishTypeId);
                return (DishType)dishTypeId;
            }).ToArray();

            return mealService.Order(timeOfDayEnum, dishTypeEnums);
        }
    }
}