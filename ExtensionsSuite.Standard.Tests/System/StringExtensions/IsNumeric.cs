using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    /// <summary>
    /// Summary description for IsNumeric
    /// </summary>
    [TestClass]
    public class IsNumeric
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNumericSourceNullTest()
        {
            string source = null;
            source.IsNumeric();
        }

        [TestMethod]        
        public void IsNumericSourceEmptyTest()
        {
            string source = string.Empty;
            Assert.IsFalse(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericFalseFromTextTest()
        {
            string source = "any text";
            Assert.IsFalse(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericTrueTest()
        {
            string source = "132";
            Assert.IsTrue(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericTrueFromCommaTest()
        {
            string source = "13,2";
            Assert.IsTrue(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericTrueFromPointTest()
        {
            string source = "13.2";
            Assert.IsTrue(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericTrueFromFormattedStringTest()
        {
            string source = "13.205.456.234,45";
            Assert.IsTrue(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericTrueFromFormattedNegativeValueTest()
        {
            string source = "-13.205.456.234,45";
            Assert.IsTrue(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericTrueFromFormattedPositiveValueTest()
        {
            string source = "+13.205.456.234,45";
            Assert.IsTrue(source.IsNumeric());
        }

        [TestMethod]
        public void IsNumericAllowMissingLeadingZeroTest()
        {
            string source = "0.3";
            Assert.IsTrue(source.IsNumeric());

            source = ".3";
            Assert.IsTrue(source.IsNumeric());
        }
    }
}
