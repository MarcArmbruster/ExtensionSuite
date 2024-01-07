namespace ExtensionsSuite.Standard.Tests.System.Reflection.MethodInfo
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
        public int GetNumber() => 1;

        public string GetString() => "Test";
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class IsAttributedWithTests
    {
        [TestMethod]
        public void IsAttributedWithTest()
        {
            MethodInfo mi = typeof(TestClass).GetMethod("GetNumber");
            Assert.IsTrue(mi.IsMethodAttributedWith(typeof(MyTestAttribute)));
        }

        [TestMethod]
        public void IsNotAttributedWithTest()
        {
            MethodInfo mi = typeof(TestClass).GetMethod("GetString");
            Assert.IsFalse(mi.IsMethodAttributedWith(typeof(MyTestAttribute)));
        }
    }
}
