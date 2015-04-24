namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     A meal service that allows you to order food.
    /// </summary>
    public interface IMealService
    {
        /// <summary>
        /// Orders the dish types specified for the specified time of day.
        /// </summary>
        /// <param name="timeOfDay">The time of day.</param>
        /// <param name="dishTypes">The dish types.</param>
        /// <returns>
        /// A meal based on the time of day and dish types desired.
        /// </returns>
        Meal Order(TimeOfDay timeOfDay, params DishType[] dishTypes);
    }
}