using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Int32Extensions
{
    [TestClass]
    public class IsNotNullAndNotZero
    {
        [TestMethod]
        public void NullTest()
        {
            int? value = null;
            Assert.IsFalse(value.IsNotNullAndNotZero());
        }

        [TestMethod]
        public void ZeroTest()
        {
            int? value = 0;
            Assert.IsFalse(value.IsNotNullAndNotZero());
        }

        [TestMethod]
        public void ValueTest()
        {
            int? value = 47;
            Assert.IsTrue(value.IsNotNullAndNotZero());
        }
    }
}
