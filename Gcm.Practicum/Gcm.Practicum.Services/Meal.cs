using System.Collections.Generic;
using System.Linq;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     Describes a meal.
    /// </summary>
    public class Meal
    {
        private readonly List<Dish> dishes = new List<Dish>();

        internal List<Dish> Dishes
        {
            get { return dishes; }
        }

        public IEnumerable<string> Entrees
        {
            get { return dishes.Where(d => d.DishType == DishType.Entree).Select(d => d.Name); }
        }

        public IEnumerable<string> Sides
        {
            get { return dishes.Where(d => d.DishType == DishType.Side).Select(d => d.Name); }
        }

        public IEnumerable<string> Drinks
        {
            get { return dishes.Where(d => d.DishType == DishType.Drink).Select(d => d.Name); }
        }

        public IEnumerable<string> Desserts
        {
            get { return dishes.Where(d => d.DishType == DishType.Dessert).Select(d => d.Name); }
        }

        /// <summary>
        ///     Prints food in the following order: entrée, side, drink, dessert.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Join(", ", new[] { Entrees, Sides, Drinks, Desserts }
                .Where(i => i != null && i.Any()) // only include meal parts that exist
                .Select(i => i.ToArray() /* avoid multiple enumeration */)
                .Select(i => new
                {
                    Name = i[0],
                    Count = i.Length == 1 ? string.Empty : string.Format("(x{0})", i.Length)  // add count of that part in parentheses if multiple
                })
                .Select(i => i.Name + i.Count)
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .ToArray());
        }
    }
}