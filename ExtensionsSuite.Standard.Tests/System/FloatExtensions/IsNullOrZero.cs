namespace ExtensionsSuite.Standard.Tests.System.FloatExtensions
{
    using global::System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IsNullOrZero
    {
        [TestMethod]
        public void NullTest()
        {
            float? value = null;
            Assert.IsTrue(value.IsNullOrZero());
        }

        [TestMethod]
        public void ZeroTest()
        {
            float? value = 0;
            Assert.IsTrue(value.IsNullOrZero());
        }

        [TestMethod]
        public void ValueTest()
        {
            float? value = 47;
            Assert.IsFalse(value.IsNullOrZero());
        }
    }
}