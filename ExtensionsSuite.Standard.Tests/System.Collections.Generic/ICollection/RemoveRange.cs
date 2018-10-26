using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ExtensionsSuite.Standard.Tests.System.Collections.Generic.ICollection
{
    [TestClass]
    public class RemoveRange
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveRangeSourceNullTest()
        {
            ICollection<int> source = null;
            source.AddRange(new List<int> { 1, 2 });
        }

        [TestMethod]
        public void RemoveValuesFromHashSetTest()
        {
            ICollection<int> source = new HashSet<int> { 1, 2, 3, 4, 5, 6 };
            source.RemoveRange(new List<int> { 2, 4, 6 });

            Assert.AreEqual(3, source.Count);
            Assert.AreEqual(1, source.Count(i => i == 1));
            Assert.AreEqual(1, source.Count(i => i == 3));
            Assert.AreEqual(1, source.Count(i => i == 5));
            Assert.AreEqual(0, source.Count(i => i == 2));
            Assert.AreEqual(0, source.Count(i => i == 4));
            Assert.AreEqual(0, source.Count(i => i == 6));

            Assert.AreEqual(1, source.ElementAt(0));
            Assert.AreEqual(3, source.ElementAt(1));
            Assert.AreEqual(5, source.ElementAt(2));
        }

        [TestMethod]
        public void AddValuesToEmptyListTest()
        {
            ICollection<int> source = new HashSet<int>();
            source.RemoveRange(new List<int> { 2, 3 });

            Assert.AreEqual(0, source.Count);
        }
    }
}