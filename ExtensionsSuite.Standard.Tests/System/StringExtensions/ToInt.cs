using System;
using ExtensionsSuite.Standard.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    [TestClass]
    public class ToInt
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToIntSourceNullTest()
        {
            string source = null;
            source.ToInt32();
        }

        [TestMethod]
        public void ToIntSourceEmptyTest()
        {
            string source = string.Empty;
            Assert.AreEqual(0, source.ToInt32(NumericConversionBehavior.ReturnDefaultValueInsteadOfException));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToIntSourceEmptyExceptionTest()
        {
            string source = string.Empty;
            source.ToInt32(NumericConversionBehavior.Default);
        }

        [TestMethod]
        public void ToIntSourceWrongTest()
        {
            string source = "non integer";
            Assert.AreEqual(0, source.ToInt32(NumericConversionBehavior.ReturnDefaultValueInsteadOfException));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToIntSourceWrongExceptionTest()
        {
            string source = "non integer";
            source.ToInt32(NumericConversionBehavior.Default);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToIntSourceWrongExceptionWithouParameterTest()
        {
            string source = "non integer";
            source.ToInt32();
        }

        [TestMethod]
        public void ToIntPositiveValueTest()
        {
            string source = "321";
            Assert.AreEqual(321, source.ToInt32());
        }

        [TestMethod]
        public void ToIntNegativeValueTest()
        {
            string source = "-321";
            Assert.AreEqual(-321, source.ToInt32());
        }
    }
}