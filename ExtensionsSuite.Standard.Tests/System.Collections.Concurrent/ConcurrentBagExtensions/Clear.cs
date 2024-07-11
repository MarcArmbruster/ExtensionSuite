namespace ExtensionsSuite.Standard.Tests.System.Collections.Concurrent.ConcurrentBagExtensions
{
    using global::System;
    using global::System.Collections.Concurrent;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Clear
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ReplaceFirstSourceNullTest()
        {
            ConcurrentBag<string> data = null;
            data.Clear();
        }

        [TestMethod]
        public void ClearBag()
        {
            ConcurrentBag<string> data = new ConcurrentBag<string> { "X", "Y", "Z" };
            data.Clear();
            Assert.AreEqual(0, data.Count);
        }

        [TestMethod]
        public void ClearEmptyBag()
        {
            ConcurrentBag<string> data = new ConcurrentBag<string>();
            data.Clear();
            Assert.AreEqual(0, data.Count);
        }
    }
}
