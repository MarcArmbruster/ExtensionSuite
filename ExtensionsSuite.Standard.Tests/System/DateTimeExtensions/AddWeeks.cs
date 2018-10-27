using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.DateTimeExtensions
{
    [TestClass]
    public class AddWeeks
    {
        [TestMethod]        
        public void TwoWeeksTest()
        {
            DateTime source = new DateTime(2018, 10, 27);
            var result = source.AddWeeks(2);
            Assert.AreEqual(2018, result.Year);
            Assert.AreEqual(11, result.Month);
            Assert.AreEqual(10, result.Day);
        }

        [TestMethod]
        public void NegativeWeeksTest()
        {
            DateTime source = new DateTime(2018, 10, 27);
            var result = source.AddWeeks(-2);
            Assert.AreEqual(2018, result.Year);
            Assert.AreEqual(10, result.Month);
            Assert.AreEqual(13, result.Day);
        }
    }
}
