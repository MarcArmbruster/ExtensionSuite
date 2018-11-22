using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Collections.Generic.ICollectionExtensions
{
    [TestClass]
    public class Contains
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsSourceNullTest()
        {
            ICollection<int> source = null;
            source.Contains(i => i > 0);
        }

        [TestMethod]
        public void ContainsPositvesTest()
        {
            ICollection<int> source = new List<int> { -2, -1, 0, 1, 2 };

            Assert.IsTrue(source.Contains(i => i >= 1));
            Assert.IsTrue(source.Contains(i => i == 0));
            Assert.IsTrue(source.Contains(i => i < 0));
            Assert.IsTrue(source.Contains(i => i < -1));
            Assert.IsTrue(source.Contains(i => Math.Abs(i) <= 2));
        }

        [TestMethod]
        public void ContainsNothingTest()
        {
            ICollection<int> source = new List<int> { -2, -1, 0, 1, 2 };
            Assert.IsFalse(source.Contains(i => i > 2));
            Assert.IsFalse(source.Contains(i => i < -2));
        }
    }
}