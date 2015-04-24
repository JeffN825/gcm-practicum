using System;

namespace Gcm.Practicum.Services
{
    /// <summary>
    ///     An IOC container for services. In production code would be replaced by an open source widely used one (Autofac,
    ///     NInject, Windsor, Unity, etc.)
    /// </summary>
    public class ServiceContainer
    {
        /// <summary>
        ///     Resolves an instance of TService. Would use a standard IOC container in production code.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public TService Resolve<TService>()
        {
            if (typeof(TService) == typeof(IMealService))
            {
                return (TService)(object)new MealService(new MealConfigurationRepository());
            }

            throw new NotSupportedException(string.Format("{0} service is not supported.", typeof(TService).FullName));
        }
    }
}