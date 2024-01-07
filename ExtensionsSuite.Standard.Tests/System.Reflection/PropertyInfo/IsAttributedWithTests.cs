namespace ExtensionsSuite.Standard.Tests.System.Reflection.PropertyInfo
{
    using global::System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using global::System.Reflection;

    public class MyTestAttribute : Attribute
    {
    }

    public class TestClass
    {
        [MyTest]
        public int Id { get; set; }

        public int Size { get; set; }

        [MyTest]
        public int GetNumber() => 1;

        public string GetString() => "Test";
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class IsAttributedWithTests
    {
        [TestMethod]
        public void IsAttributedWithTest()
        {
            PropertyInfo pi = typeof(TestClass).GetProperty("Id");
            Assert.IsTrue(pi.IsPropertyAttributedWith(typeof(MyTestAttribute)));
        }

        [TestMethod]
        public void IsNotAttributedWithTest()
        {
            var pi = typeof(TestClass).GetProperty("Size");
            Assert.IsFalse(pi.IsPropertyAttributedWith(typeof(MyTestAttribute)));
        }
    }
}
