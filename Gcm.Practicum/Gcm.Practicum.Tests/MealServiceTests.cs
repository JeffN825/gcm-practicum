using Gcm.Practicum.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gcm.Practicum.Tests
{
    [TestClass]
    public class MealServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof (OrderException))]
        public void Order_ThrowsException_WhenInvalidTimeOfDayEntered()
        {
            IMealService mealService = new MealService();

            mealService.Order("foo", "bar");
        }
    }
}