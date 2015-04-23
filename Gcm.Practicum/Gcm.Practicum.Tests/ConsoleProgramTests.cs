using System;
using Gcm.Practicum.Console;
using Gcm.Practicum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gcm.Practicum.Tests
{
    [TestClass]
    public class ConsoleProgramTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Main_ThrowsException_WhenNoParametersSupplied()
        {
            Program.Main(new string[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Main_ThrowsException_WhenTooManyParametersSupplied()
        {
            Program.Main(new string[3]);
        }
    }
}
