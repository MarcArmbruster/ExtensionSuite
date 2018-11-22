using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Collections.Generic.ICollectionExtensions
{
    [TestClass]
    public class Matches
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatchesSourceNullTest()
        {
            ICollection<int> source = null;
            source.Matches(i => i > 0);
        }

        [TestMethod]       
        public void MatchesPositvesTest()
        {
            ICollection<int> source = new List<int> { -2, -1 , 0 , 1, 2 };
            var result = source.Matches(i => i > 0);
            Assert.IsTrue(result.Any());
            Assert.IsFalse(result.Any(i => i == -2));
            Assert.IsFalse(result.Any(i => i == -1));
            Assert.IsFalse(result.Any(i => i == 0));
            Assert.IsTrue(result.Any(i => i == 1));
            Assert.IsTrue(result.Any(i => i == 2));
        }

        [TestMethod]
        public void MatchesNothingTest()
        {
            ICollection<int> source = new List<int> { -2, -1, 0, 1, 2 };
            var result = source.Matches(i => i <= -13);
            Assert.IsFalse(result.Any());
        }
    }
}
