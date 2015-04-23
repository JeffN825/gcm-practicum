using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gcm.Practicum.Services
{
    /// <summary>
    /// A meal service that allows you to order food.
    /// </summary>
    public interface IMealService
    {
        /// <summary>
        /// Orders the dish types specified for the specified time of day.
        /// </summary>
        /// <param name="timeOfDay">The time of day. Valid values: morning, night (case insensitive)</param>
        /// <param name="dishTypes">A command delimited list of dish types. Valid values: comma delmited 1,2,3, or 4.
        /// The meaning of each number is:
        /// 1 (entrée): eggs in the morning, steak at night
        /// 2 (side): toast in the morning, potato at night (multiple are allowed)
        /// 3 (drink): coffee in the morning (multiple are allowed), wine at night
        /// 4 (dessert): none in the morning, cake at night
        /// <returns>A mean based on the time of day and dish types desired.</returns>
        Meal Order(string timeOfDay, string dishTypes);
    }
}
