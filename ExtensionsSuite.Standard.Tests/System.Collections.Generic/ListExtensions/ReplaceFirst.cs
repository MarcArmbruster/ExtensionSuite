namespace ExtensionsSuite.Standard.Tests.System.Collections.Generic.ListExtensions
{
    using global::System;
    using global::System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReplaceFirst
    {        
        [TestMethod]
        public void ReplaceFirstPositiveTest()
        {
            List<string> data = new List<string> { "X", "Y", "Z" };
            data.ReplaceFirst(s => s == "Y", "A");

            CollectionAssert.AllItemsAreNotNull(data);
            CollectionAssert.AllItemsAreUnique(data);
            CollectionAssert.Contains(data, "X");
            CollectionAssert.Contains(data, "A");
            CollectionAssert.Contains(data, "Z");
            Assert.AreEqual(1, data.IndexOf("A"));
        }

        [TestMethod]
        public void ReplaceFirstNotFoundTest()
        {
            List<string> data = new List<string> { "X", "Y", "Z" };
            data.ReplaceFirst(s => s == "W", "A");

            CollectionAssert.AllItemsAreNotNull(data);
            CollectionAssert.AllItemsAreUnique(data);
            CollectionAssert.Contains(data, "X");
            CollectionAssert.Contains(data, "Y");
            CollectionAssert.Contains(data, "Z");
            Assert.AreEqual(-1, data.IndexOf("A"));
        }

        [TestMethod]
        public void ReplaceFirstNullValueTest()
        {
            List<string> data = new List<string> { "X", "Y", "Z" };
            data.ReplaceFirst(s => s == "X", null);

            CollectionAssert.AllItemsAreUnique(data);
            CollectionAssert.Contains(data, null);
            CollectionAssert.Contains(data, "Y");
            CollectionAssert.Contains(data, "Z");
            Assert.IsNull(data[0]);
        }
    }
}
