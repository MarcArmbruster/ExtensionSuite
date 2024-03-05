namespace ExtensionsSuite.Standard.Tests.System.Int32Extensions
{
    using global::System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Add
    {
        #region Non-Nullable-Tests

        [TestMethod]
        public void DefaultAddTest()
        {
            int value = 5555;
            int result = value.Add(44);
            Assert.AreEqual(5599, result);
        }

        [TestMethod]
        public void DefaultSubstractTest()
        {
            int value = 5555;
            int result = value.Add(-44);
            Assert.AreEqual(5511, result);
        }

        [TestMethod]
        public void OverflowSaveAddTest()
        {
            int value = int.MaxValue;
            int result = value.Add(44);
            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void OverflowSaveAddTest2()
        {
            int value = int.MaxValue - 22;
            int result = value.Add(44);
            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void OverflowSaveSubstractTest()
        {
            int value = int.MinValue;
            int result = value.Add(-44);
            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        public void OverflowSaveSubstractTest2()
        {
            int value = int.MinValue + 22;
            int result = value.Add(-44);
            Assert.AreEqual(int.MinValue, result);
        }

        #endregion Non-Nullable-Tests

        #region Nullable-Tests

        [TestMethod]
        public void NullableDefaultAddTest()
        {
            int? value = 5555;
            int? result = value.Add(44);
            Assert.AreEqual(5599, result);
        }

        [TestMethod]
        public void NullableDefaultSubstractTest()
        {
            int? value = 5555;
            int? result = value.Add(-44);
            Assert.AreEqual(5511, result);
        }

        [TestMethod]
        public void NullableOverflowSaveAddTest()
        {
            int? value = int.MaxValue;
            int? result = value.Add(44);
            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void NullableOverflowSaveAddTest2()
        {
            int? value = int.MaxValue - 22;
            int? result = value.Add(44);
            Assert.AreEqual(int.MaxValue, result);
        }

        [TestMethod]
        public void NullableOverflowSaveSubstractTest()
        {
            int? value = int.MinValue;
            int? result = value.Add(-44);
            Assert.AreEqual(int.MinValue, result);
        }

        [TestMethod]
        public void NullableOverflowSaveSubstractTest2()
        {
            int? value = int.MinValue + 22;
            int? result = value.Add(-44);
            Assert.AreEqual(int.MinValue, result);
        }

        #endregion Nullable-Tests
    }
}
