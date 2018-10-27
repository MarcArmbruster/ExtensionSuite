using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Int32Extensions
{
    [TestClass]
    public class GaussianSum
    {
        [TestMethod]
        public void ZeroTest()
        {
            int value = 0;
            Assert.AreEqual(0, value.GaussianSum());
        }

        [TestMethod]
        public void FiveTest()
        {
            int value = 5;
            Assert.AreEqual(15, value.GaussianSum());
        }

        [TestMethod]
        public void TenTest()
        {
            int value = 10;
            Assert.AreEqual(55, value.GaussianSum());
        }

        [TestMethod]
        public void HundredTest()
        {
            int value = 100;
            Assert.AreEqual(5050, value.GaussianSum());
        }

        [TestMethod]
        public void NegativeValueTest()
        {
            int value = -10;
            Assert.AreEqual(45, value.GaussianSum());
        }
    }
}
