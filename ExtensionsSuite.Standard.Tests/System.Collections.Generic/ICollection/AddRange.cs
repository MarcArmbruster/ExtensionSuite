using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Collections.Generic.ICollection
{
    [TestClass]
    public class AddRange
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddRangeSourceNullTest()
        {
            ICollection<int> source = null;
            source.AddRange(new List<int> { 1, 2 });
        }

        [TestMethod]
        public void AddValuesAtEndForHashSetTest()
        {
            ICollection<int> source = new HashSet<int> { 1, 2 };
            source.AddRange(new List<int> { 2, 3 });

            Assert.AreEqual(3, source.Count);
            Assert.AreEqual(1, source.Count(i => i == 1));
            Assert.AreEqual(1, source.Count(i => i == 2));
            Assert.AreEqual(1, source.Count(i => i == 3));
            Assert.AreEqual(1, source.ElementAt(0));
            Assert.AreEqual(2, source.ElementAt(1));
            Assert.AreEqual(3, source.ElementAt(2));
        }

        [TestMethod]
        public void AddValuesAtEndForListTest()
        {
            ICollection<int> source = new List<int> { 1, 2 };
            source.AddRange(new List<int> { 2, 3 });

            Assert.AreEqual(4, source.Count);
            Assert.AreEqual(1, source.Count(i => i == 1));
            Assert.AreEqual(2, source.Count(i => i == 2));
            Assert.AreEqual(1, source.Count(i => i == 3));
            Assert.AreEqual(1, source.ElementAt(0));
            Assert.AreEqual(2, source.ElementAt(1));
            Assert.AreEqual(2, source.ElementAt(2));
            Assert.AreEqual(3, source.ElementAt(3));
        }

        [TestMethod]
        public void AddValuesToEmptyListTest()
        {
            ICollection<int> source = new HashSet<int>();
            source.AddRange(new List<int> { 2, 3 });

            Assert.AreEqual(2, source.Count);            
            Assert.AreEqual(1, source.Count(i => i == 2));
            Assert.AreEqual(1, source.Count(i => i == 3));
            Assert.AreEqual(2, source.ElementAt(0));
            Assert.AreEqual(3, source.ElementAt(1));
        }
    }
}