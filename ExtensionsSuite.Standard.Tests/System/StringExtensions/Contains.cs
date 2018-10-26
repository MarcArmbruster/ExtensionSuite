using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    [TestClass]
    public class Contains
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsSourceNullTest()
        {
            string source = null;
            source.Contains("Test",StringComparison.OrdinalIgnoreCase);
        }

        [TestMethod]
        public void ContainsStringLowerPositiveTest()
        {
            string source = "String extensions can be helpful!";
            bool isContains = source.Contains("can", StringComparison.OrdinalIgnoreCase);
            Assert.AreEqual(isContains, true);
        }

        [TestMethod]
        public void ContainsStringUpperPositiveTest()
        {
            string source = "String extensions can be helpful!";
            bool isContains = source.Contains("CAN", StringComparison.OrdinalIgnoreCase);
            Assert.AreEqual(isContains, true);
        }

        [TestMethod]
        public void ContainsStringNegativeTest()
        {
            string source = "String extensions can be helpful!";
            bool isContains = source.Contains("???", StringComparison.OrdinalIgnoreCase);
            Assert.AreEqual(isContains, false);
        }
    }
}
