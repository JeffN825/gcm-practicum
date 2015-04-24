namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     A dish that is part of a meal configuration.
    /// </summary>
    internal class Dish
    {
        public Dish(DishType dishType, string name, bool allowMultiple = false)
        {
            DishType = dishType;
            Name = name;
            AllowMultiple = allowMultiple;
        }

        public DishType DishType { get; private set; }
        public string Name { get; private set; }
        public bool AllowMultiple { get; private set; }
    }
}