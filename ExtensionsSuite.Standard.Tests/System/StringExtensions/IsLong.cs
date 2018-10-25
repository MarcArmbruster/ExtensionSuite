using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    [TestClass]
    public class IsLong
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsLongSourceNullTest()
        {
            string source = null;
            source.IsLong();
        }

        [TestMethod]
        public void IsLongFalseFromTextTest()
        {
            string source = "any text";
            Assert.IsFalse(source.IsLong());
        }

        [TestMethod]
        public void IsLongTrueTest()
        {
            string source = "132";
            Assert.IsTrue(source.IsLong());
        }

        [TestMethod]
        public void IsLongFalseFromCommaTest()
        {
            string source = "13,2";
            Assert.IsFalse(source.IsLong());
        }

        [TestMethod]
        public void IsLongFalseFromPointTest()
        {
            string source = "13.2";
            Assert.IsFalse(source.IsLong());
        }

        [TestMethod]
        public void IsLongToBigTest()
        {
            string source = long.MaxValue.ToString() + "0";
            Assert.IsFalse(source.IsLong());
        }

        [TestMethod]
        public void IsLongToLowTest()
        {
            string source = long.MinValue.ToString() + "0";
            Assert.IsFalse(source.IsLong());
        }
    }
}
