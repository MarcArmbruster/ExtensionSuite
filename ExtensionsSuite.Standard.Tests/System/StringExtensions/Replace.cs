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
    }
}
