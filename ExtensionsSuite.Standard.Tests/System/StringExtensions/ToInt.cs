using System;
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
            source.ToInt();
        }

        [TestMethod]
        public void ToIntSourceEmptyTest()
        {
            string source = string.Empty;
            Assert.AreEqual(0, source.ToInt());
        }

        [TestMethod]
        public void ToIntSourceWrongTest()
        {
            string source = "non integer";
            Assert.AreEqual(0, source.ToInt());
        }

        [TestMethod]
        public void ToIntPositiveValueTest()
        {
            string source = "321";
            Assert.AreEqual(321, source.ToInt());
        }

        [TestMethod]
        public void ToIntNegativeValueTest()
        {
            string source = "-321";
            Assert.AreEqual(-321, source.ToInt());
        }
    }
}