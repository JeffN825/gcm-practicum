using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Describes a meal.
    /// </summary>
    public class Meal
    {
        public Meal(string entree, string side, string drink, string dessert)
        {
            Entree = entree;
            Side = side;
            Drink = drink;
            Dessert = dessert;
        }

        public string Entree { get; private set; }
        public string Side { get; private set; }
        public string Drink { get; private set; }
        public string Dessert { get; private set; }

        /// <summary>
        ///     Prints food in the following order: entrée, side, drink, dessert.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Join(", ", new[] {Entree, Side, Drink, Dessert}.Where(i => !string.IsNullOrWhiteSpace(i)).ToArray());
        }
    }
}