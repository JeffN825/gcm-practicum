namespace Gcm.Practicum.Services
{
    /// <summary>
    /// Data source for MealConfigurations.
    /// </summary>
    internal interface IMealConfigurationRepository
    {
        /// <summary>
        ///     Returns a meal configuration for a specific time of day.
        /// </summary>
        /// <value>
        ///     The dishes.
        /// </value>
        MealConfiguration GetMealConfigurationByTimeOfDay(TimeOfDay timeOfDay);
    }
}