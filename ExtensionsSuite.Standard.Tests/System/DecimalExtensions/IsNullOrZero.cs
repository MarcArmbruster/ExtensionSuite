namespace ExtensionsSuite.Standard.Tests.System.DecimalExtensions
{
    using global::System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IsNullOrZero
    {
        [TestMethod]
        public void NullTest()
        {
            decimal? value = null;
            Assert.IsTrue(value.IsNullOrZero());
        }

        [TestMethod]
        public void ZeroTest()
        {
            decimal? value = 0;
            Assert.IsTrue(value.IsNullOrZero());
        }

        [TestMethod]
        public void ValueTest()
        {
            decimal? value = 47;
            Assert.IsFalse(value.IsNullOrZero());
        }
    }
}