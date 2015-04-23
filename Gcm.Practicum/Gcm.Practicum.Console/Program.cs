using System;

namespace Gcm.Practicum.Console
{
    internal class Program
    {
        /// <summary>
        /// Entry point to the console application. Validates number of arguments and calls the IMealService if valid.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">args;There should be exactly 2 arguments.</exception>
        internal static void Main(string[] args)
        {
            if (args == null || args.Length != 2)
            {
                throw new ArgumentOutOfRangeException("args", "There should be exactly 2 arguments.");
            }
        }
    }
}