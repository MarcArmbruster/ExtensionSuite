using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.DateTimeExtensions
{
    [TestClass]
    public class IsBetween
    {
        [TestMethod]
        public void NullTest()
        {
            DateTime? date1 = new DateTime(2018, 10, 27);
            DateTime? date2 = new DateTime(2018, 11, 27);
            DateTime? checkDate = null;

            Assert.IsFalse(checkDate.IsBetween(date1, date2));
        }

        [TestMethod]
        public void DefaultPositiveTest()
        {
            DateTime? date1 = new DateTime(2018, 10, 27);
            DateTime? date2 = new DateTime(2018, 11, 27);
            DateTime? checkDate = new DateTime(2018, 11, 11);

            Assert.IsTrue(checkDate.IsBetween(date1, date2));
        }

        [TestMethod]
        public void DefaultUpperBorderTest()
        {
            DateTime? date1 = new DateTime(2018, 10, 27);
            DateTime? date2 = new DateTime(2018, 11, 27);
            DateTime? checkDate = new DateTime(2018, 11, 27);

            Assert.IsTrue(checkDate.IsBetween(date1, date2));

            checkDate = checkDate.Value.AddDays(1);
            Assert.IsFalse(checkDate.IsBetween(date1, date2));
        }

        [TestMethod]
        public void DefaultLowerBorderTest()
        {
            DateTime? date1 = new DateTime(2018, 10, 27);
            DateTime? date2 = new DateTime(2018, 11, 27);
            DateTime? checkDate = new DateTime(2018, 10, 27);

            Assert.IsTrue(checkDate.IsBetween(date1, date2));

            checkDate = checkDate.Value.AddDays(-1);
            Assert.IsFalse(checkDate.IsBetween(date1, date2));
        }

        [TestMethod]
        public void DefaultUpperBorderNullTest()
        {
            DateTime? date1 = new DateTime(2018, 10, 27);
            DateTime? date2 = null;
            DateTime? checkDate = new DateTime(2018, 10, 27);

            Assert.IsFalse(checkDate.IsBetween(date1, date2));
        }

        [TestMethod]
        public void DefaultLowerBorderNullTest()
        {
            DateTime? date1 = null;
            DateTime? date2 = new DateTime(2018, 11, 27);
            DateTime? checkDate = new DateTime(2018, 10, 27);

            Assert.IsFalse(checkDate.IsBetween(date1, date2));
        }
    }
}
