using System;
using ExtensionsSuite.Standard.System;
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
            Assert.AreEqual(0, source.ToDecimal("de-De", NumericConversionBehavior.ReturnDefaultValueInsteadOfException));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToDecimalExceptionTest()
        {
            string source = string.Empty;
            source.ToDecimal("de-De", NumericConversionBehavior.Default);
        }

        [TestMethod]
        public void ToDecimalSourceWrongTest()
        {
            string source = "non decimal";
            Assert.AreEqual(0m, source.ToDecimal("de-De", NumericConversionBehavior.ReturnDefaultValueInsteadOfException));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToDecimalSourceWrongExceptionTest()
        {
            string source = "non decimal";
            source.ToDecimal("de-De", NumericConversionBehavior.Default);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToDecimalSourceWrongExceptionWithouParameterTest()
        {
            string source = "non integer";
            source.ToDecimal();
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
