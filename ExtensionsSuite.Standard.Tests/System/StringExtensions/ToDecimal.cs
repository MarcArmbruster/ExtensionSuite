using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    [TestClass]
    public class ToDecimal
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToDecimalSourceNullTest()
        {
            string source = null;
            source.ToDecimal();
        }

        [TestMethod]
        public void ToDecimalSourceEmptyTest()
        {
            string source = string.Empty;
            Assert.AreEqual(0, source.ToDecimal());
        }

        [TestMethod]
        public void ToDecimalSourceWrongTest()
        {
            string source = "non decimal";
            Assert.AreEqual(0, source.ToDecimal());
        }

        [TestMethod]
        public void ToDecimalPositiveValueTest()
        {
            string source = "32.1";
            Assert.AreEqual(321m, source.ToDecimal("de-DE"));

            source = "32.1";
            Assert.AreEqual(32.1m, source.ToDecimal("en-US"));
        }

        [TestMethod]
        public void ToDecimalNegativeValueTest()
        {
            string source = "-3.21";
            Assert.AreEqual(-321m, source.ToDecimal("de-DE"));

            source = "-3.21";
            Assert.AreEqual(-3.21m, source.ToDecimal("en-US"));
        }
    }
}
