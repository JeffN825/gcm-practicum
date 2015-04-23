using System;
using System.Diagnostics;
using System.Linq;
using Gcm.Practicum.Services;

namespace Gcm.Practicum.Console
{
    internal class Program
    {
        /// <summary>
        ///     Entry point to the console application. Validates number of arguments and calls the IMealService if valid.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">args;There should be exactly 2 arguments.</exception>
        internal static void Main(params string[] args)
        {
            if (args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                throw new ArgumentOutOfRangeException("args", "There should be at least 1 arguments.");
            }

            try
            {
                var container = new ServiceContainer();
                var mealService = container.Resolve<IMealService>();
                Meal meal = mealService.Order(
                    // get rid of commas
                    args[0].Replace(",", string.Empty),
                    // get rid of commas and whitespace
                    args
                        .Skip(1)
                        .Where(i => !string.IsNullOrWhiteSpace(i))
                        .Select(i => i.Replace(",", string.Empty))
                        .ToArray());

                System.Console.WriteLine(meal);
            }
            catch (OrderException ex)
            {
                System.Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                // we would have a TraceListener logging somewhere accessible in production code
                Trace.TraceError(ex.ToString());
                throw;
            }

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();
        }
    }
}