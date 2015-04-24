using System;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     An exception related to a problem with the input provided when ordering food.
    /// </summary>
    public class OrderException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OrderException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="meal">The meal. May be a partial meal (the part of the order that succeeded).</param>
        /// <param name="innerException">The inner exception.</param>
        public OrderException(string message, Meal meal = null, Exception innerException = null)
            : base(message, innerException)
        {
            Meal = meal;
        }

        /// <summary>
        ///     A meal representing whatever part of the order succeeded.
        /// </summary>
        /// <value>
        ///     The meal.
        /// </value>
        public Meal Meal { get; private set; }

        /// <summary>
        ///     Returns a string representation of the meal along with the error that occurred.
        /// </summary>
        public string Output
        {
            get { return Meal == null ? "error" : string.Format("{0}, error", Meal); }
        }
    }
}