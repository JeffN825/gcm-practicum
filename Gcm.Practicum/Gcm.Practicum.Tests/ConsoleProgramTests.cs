using System;
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
        public void Run_ThrowsException_WhenNoParametersSupplied()
        {
            try
            {
                Program.Run(new string[0]);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual("args", ex.ParamName);
            }
        }

        [TestMethod]
        public void Run_ReturnsEggsToastCoffee_WhenMorningEggsToastCoffeeSupplied()
        {
            string output = Program.Run(new[] {"morning,", "1,", "2,", "3,"});
            Assert.AreEqual("eggs, toast, coffee", output);
        }

        [TestMethod]
        public void Run_ReturnsEggsToastCoffee_WhenMorningToastEggsCoffeeSupplied()
        {
            string output = Program.Run(new[] {"morning,", "2,", "1,", "3,"});
            Assert.AreEqual("eggs, toast, coffee", output);
        }

        [TestMethod]
        public void Run_ReturnsEggsToastCoffeeError_WhenMorningEggsToastCoffeeInvalidDishTypeSupplied()
        {
            string output = Program.Run(new[] {"morning,", "1,", "2,", "3,", "4,"});
            Assert.AreEqual("eggs, toast, coffee, error", output);
        }

        [TestMethod]
        public void Run_ReturnsEggsToastCoffeex3_WhenMorningEggsToastTwoCoffeesSupplied()
        {
            string output = Program.Run(new[] {"morning,", "1,", "2,", "3,", "3,", "3,"});
            Assert.AreEqual("eggs, toast, coffee(x3)", output);
        }

        [TestMethod]
        public void Run_ReturnsSteakPotatoWineCake_WhenNightSteakPotatoWineCakeSupplied()
        {
            string output = Program.Run(new[] {"night,", "1,", "2,", "3,", "4,"});
            Assert.AreEqual("steak, potato, wine, cake", output);
        }

        [TestMethod]
        public void Run_ReturnsSteakPotatox2Cake_WhenNightSteakTwoPotatosCakeSupplied()
        {
            string output = Program.Run(new[] {"night,", "1,", "2,", "2,", "4,"});
            Assert.AreEqual("steak, potato(x2), cake", output);
        }

        [TestMethod]
        public void Run_ReturnsSteakPotatoWineError_WhenNightSeakPotatoWineInvalidDishTypeSupplied()
        {
            string output = Program.Run(new[] {"night,", "1,", "2,", "3,", "5,"});
            Assert.AreEqual("steak, potato, wine, error", output);
        }

        [TestMethod]
        public void Run_ReturnsSteakError_WhenNightMultipleEntreesSupplied()
        {
            string output = Program.Run(new[] {"night,", "1,", "1,", "2,", "3,", "5,"});
            Assert.AreEqual("steak, error", output);
        }
    }
}