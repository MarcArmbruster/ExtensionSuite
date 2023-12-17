namespace ExtensionsSuite.Standard.Tests.System.Reflection.PropertyInfo
{
    using global::System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class MyTestClassAttribute : Attribute
    {
        public string Info { get; set; }
    }

    public class MyTestPropertyAttribute : Attribute
    {
        public int Size { get; set; }
    }

    [MyTestClass(Info = "Marc")]
    public class MyTestClass
    {
        [MyTestProperty(Size = 9)]
        public string Something { get; set; }
    }

    [TestClass]
    public class GetCustomAttributesDataTests
    {
        [TestMethod]
        public void GetAttributeValueTest()
        {
            MyTestClass target = new MyTestClass();
            var value = target.GetAttributeValue<int>(nameof(MyTestClass.Something), typeof(MyTestPropertyAttribute), nameof(MyTestPropertyAttribute.Size));
            
            Assert.AreEqual(9, value);
        }

        [TestMethod]
        public void IsAttributedTest()
        {
            MyTestClass target = new MyTestClass();
            var value = target.IsAttributedWith(typeof(MyTestClassAttribute));

            Assert.IsTrue(value);
        }
    }
}
