using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    [TestClass]
    public class IsShort
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsShortSourceNullTest()
        {
            string source = null;
            source.IsShort();
        }

        [TestMethod]
        public void IsShortFalseFromTextTest()
        {
            string source = "any text";
            Assert.IsFalse(source.IsShort());
        }

        [TestMethod]
        public void IsShortTrueTest()
        {
            string source = "132";
            Assert.IsTrue(source.IsShort());
        }

        [TestMethod]
        public void IsShortFalseFromCommaTest()
        {
            string source = "13,2";
            Assert.IsFalse(source.IsShort());
        }

        [TestMethod]
        public void IsShortFalseFromPointTest()
        {
            string source = "13.2";
            Assert.IsFalse(source.IsShort());
        }

        [TestMethod]
        public void IsShortToBigTest()
        {
            string source = (((long)short.MaxValue) + 1).ToString();
            Assert.IsFalse(source.IsShort());
        }

        [TestMethod]
        public void IsShortToLowTest()
        {
            string source = (((long)short.MinValue) - 1).ToString();
            Assert.IsFalse(source.IsShort());
        }
    }
}
