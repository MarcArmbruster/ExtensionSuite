using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    [TestClass]
    public class Replace
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReplaceWithNull()
        {
            string source = null;
            source.Replace("AA","??",StringComparison.CurrentCultureIgnoreCase);
        }

        [TestMethod]
        public void ReplaceStringLowerTest()
        {
            string source = "String Text original!";
            string replaceText = source.Replace("original","replaced",StringComparison.CurrentCultureIgnoreCase);
            Assert.AreEqual("String Text replaced!", replaceText);
        }

        [TestMethod]
        public void ReplaceStringUpperLowerTest()
        {
            string source = "String Text ORIGINAL!";
            string replaceText = source.Replace("original", "REPLACED", StringComparison.CurrentCultureIgnoreCase);
            Assert.AreEqual("String Text REPLACED!", replaceText);
        }
    }
}
