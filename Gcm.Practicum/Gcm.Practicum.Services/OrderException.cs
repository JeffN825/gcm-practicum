using System;
using System.Linq;

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
        /// <param name="meal">The meal. May be a partial meal (the part of the order that succeeded).</param>
        /// <param name="innerException">The inner exception.</param>
        public OrderException(Meal meal = null, Exception innerException = null)
            : base("error" /* in reality, we might want the caller to be able to specify a more descriptive error */, innerException)
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
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        public override string ToString()
        {
            return string.Join(", ", new object[] { Meal, Message }.Where(i => i != null).ToArray());
        }
    }
}