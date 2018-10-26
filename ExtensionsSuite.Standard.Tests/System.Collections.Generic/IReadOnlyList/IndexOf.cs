using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Collections.Generic.IReadOnlyList
{   
    [TestClass]
    public class IndexOf
    {
        private class FakeClass
        {
            internal string Name { get; set; }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IndexOfSourceNullTest()
        {            
            IReadOnlyList<string> list = null;
            list.IndexOf<string>("B");
        }

        [TestMethod]        
        public void IndexOfFoundTest()
        {
            List<string> data = new List<string> { "A", "B", "C", "D" };
            IReadOnlyList<string> list = data.AsReadOnly();
            var indexA = list.IndexOf<string>("A");
            var indexB = list.IndexOf<string>("B");
            var indexC = list.IndexOf<string>("C");
            var indexD = list.IndexOf<string>("D");
            Assert.AreEqual(0, indexA);
            Assert.AreEqual(1, indexB);
            Assert.AreEqual(2, indexC);
            Assert.AreEqual(3, indexD);
        }

        [TestMethod]
        public void IndexOfNotFoundTest()
        {
            List<string> data = new List<string> { "A", "B", "C", "D" };
            IReadOnlyList<string> list = data.AsReadOnly();
            var index = list.IndexOf<string>("X");
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void IndexOfObjectTest()
        {
            var fakeOne = new FakeClass { Name = "Marc" };
            var fakeTwo = new FakeClass { Name = "Gerhard" };
            List<FakeClass> data = new List<FakeClass> { fakeOne, fakeTwo };
            IReadOnlyList<FakeClass> list = data.AsReadOnly();
            var index = list.IndexOf<FakeClass>(fakeTwo);
            Assert.AreEqual(1, index);
        }
    }
}
