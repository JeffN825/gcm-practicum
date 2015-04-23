using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Describes a meal.
    /// </summary>
    public class Meal
    {
        public Meal(string[] entrees, string[] sides, string[] drinks, string[] desserts)
        {
            Entrees = entrees;
            Sides = sides;
            Drinks = drinks;
            Desserts = desserts;
        }

        public string[] Entrees { get; private set; }
        public string[] Sides { get; private set; }
        public string[] Drinks { get; private set; }
        public string[] Desserts { get; private set; }

        /// <summary>
        ///     Prints food in the following order: entrée, side, drink, dessert.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Join(", ", new[] {Entrees, Sides, Drinks, Desserts}
                .Where(i => i != null && i.Length > 0) // only include meal parts that exist
                .Select(i => i.Length == 1 ? i[0] : (i + string.Format("({0})", i.Length))) // add count of that part in parentheses if multiple
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .ToArray());
        }
    }
}