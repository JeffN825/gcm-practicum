using System;
using System.Diagnostics;
using System.Linq;
using Gcm.Practicum.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gcm.Practicum.Tests
{
    /// <summary>
    ///     Many of these (all except the first) are really integration tests (and would not normally be run on build, but
    ///     rather on a separate schedule).
    /// </summary>
    [TestClass]
    public class ConsoleProgramTests
    {
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Main_ThrowsException_WhenNoParametersSupplied()
        {
            Program.Main(new string[0]);
        }

        [TestMethod]
        public void Main_ReturnsEggsToastCoffee_WhenMorningEggsToastCoffeeSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"morning,", "1,", "2,", "3,"});
            Assert.AreEqual(capturer.Output, "eggs, toast, coffee");
        }

        [TestMethod]
        public void Main_ReturnsEggsToastCoffee_WhenMorningToastEggsCoffeeSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"morning,", "2,", "1,", "3,"});
            Assert.AreEqual(capturer.Output, "eggs, toast, coffee");
        }

        [TestMethod]
        public void Main_ReturnsEggsToastCoffeeError_WhenMorningEggsToastCoffeeInvalidDishTypeSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"morning,", "1,", "2,", "3,", "4,"});
            Assert.AreEqual(capturer.Output, "eggs, toast, coffee, error");
        }

        [TestMethod]
        public void Main_ReturnsEggsToastCoffeex3_WhenMorningEggsToastTwoCoffeesSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"morning,", "1,", "2,", "3,", "3,", "3,"});
            Assert.AreEqual(capturer.Output, "eggs, toast, coffee(x3)");
        }

        [TestMethod]
        public void Main_ReturnsSteakPotatoWineCake_WhenNightSteakPotatoWineCakeSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"night,", "1,", "2,", "3,", "4,"});
            Assert.AreEqual(capturer.Output, "steak, potato, wine, cake");
        }

        [TestMethod]
        public void Main_ReturnsSteakPotatox2Cake_WhenNightSteakTwoPotatosCakeSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"night,", "1,", "2,", "2,", "4,"});
            Assert.AreEqual(capturer.Output, "steak, potato(x2), cake");
        }

        [TestMethod]
        public void Main_ReturnsSteakPotatoWineError_WhenNightSeakPotatoWineInvalidDishTypeSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"night,", "1,", "2,", "3,", "5,"});
            Assert.AreEqual(capturer.Output, "steak, potato, wine, error");
        }

        [TestMethod]
        public void Main_ReturnsSteakError_WhenNightMultipleEntreesSupplied()
        {
            var capturer = new ConsoleCapturingTraceListener();
            Trace.Listeners.Add(capturer);
            Program.Main(new[] {"night,", "1,", "1,", "2,", "3,", "5,"});
            Assert.AreEqual(capturer.Output, "steak, error");
        }

        [TestCleanup]
        public void RemoveConsoleCapturingTraceListener()
        {
            // if the test throws an exception, we want to clean this up anyway
            Trace.Listeners.OfType<ConsoleCapturingTraceListener>().ToList().ForEach(l => Trace.Listeners.Remove(l));
        }
    }
}