namespace ExtensionsSuite.Standard.Tests.System.Int32Extensions
{
    using global::System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EvenOdd
    {
        [TestMethod]
        public void IsEvenTest()
        {
            int one = 1;
            int two = 2;

            Assert.IsFalse(one.IsEven());
            Assert.IsTrue(two.IsEven());
        }

        [TestMethod]
        public void IsOddTest()
        {
            int one = 1;
            int two = 2;

            Assert.IsTrue(one.IsOdd());
            Assert.IsFalse(two.IsOdd());
        }
    }
}