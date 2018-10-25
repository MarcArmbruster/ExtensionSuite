using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    /// <summary>
    /// Summary description for IsDecimal
    /// </summary>
    [TestClass]
    public class IsDecimal
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsDecimalSourceNullTest()
        {
            string source = null;
            source.IsDecimal();
        }

        [TestMethod]
        public void IsDecimalFalseFromTextTest()
        {
            string source = "any text";
            Assert.IsFalse(source.IsDecimal());
        }

        [TestMethod]
        public void IsDecimalTrueTest()
        {
            string source = "132";
            Assert.IsTrue(source.IsDecimal());
        }

        [TestMethod]
        public void IsDecimalTrueFromCommaTest()
        {
            string source = "13,2";
            Assert.IsTrue(source.IsDecimal());
        }

        [TestMethod]
        public void IsDecimalTrueFromPointTest()
        {
            string source = "13.2";
            Assert.IsTrue(source.IsDecimal());
        }

        [TestMethod]
        public void IsDecimalToBigTest()
        {
            string source = decimal.MaxValue.ToString() + "0";
            Assert.IsFalse(source.IsDecimal());
        }

        [TestMethod]
        public void IsDecimalToLowTest()
        {
            string source = decimal.MinValue.ToString() + "0";
            Assert.IsFalse(source.IsDecimal());
        }
    }
}
