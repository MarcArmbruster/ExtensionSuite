namespace ExtensionsSuite.Standard.Tests.System
{
    using global::System;
    using global::System.Linq;
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

    public class Person
    {
        [MyTestClass]
        public string FirstName { get; set; }

        [MyTestClass]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    [TestClass]
    public class GetCustomAttributesDataTests
    {
        [TestMethod]
        public void GetAttributedPropertiesTest()
        {
            Person target = new Person();
            var pis = target.GetAttributedProperties(typeof(MyTestClassAttribute));

            Assert.AreEqual(2, pis.Count());
            Assert.IsTrue(pis.Any(x => x.Name == "FirstName"));
            Assert.IsTrue(pis.Any(x => x.Name == "LastName"));
            Assert.IsFalse(pis.Any(x => x.Name == "FullName"));
        }

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
            var value = target.IsTypeAttributedWith(typeof(MyTestClassAttribute));

            Assert.IsTrue(value);
        }

        [TestMethod]
        public void SetPropertyNamesTest()
        {
            var person = new Person();
            var names = person.GetSetablePropertyNames();

            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.Contains("FirstName"));
            Assert.IsTrue(names.Contains("LastName"));
        }

        [TestMethod]
        public void GetPropertyNamesTest()
        {
            var person = new Person();
            var names = person.GetGetablePropertyNames();

            Assert.AreEqual(3, names.Count);
            Assert.IsTrue(names.Contains("FirstName"));
            Assert.IsTrue(names.Contains("LastName"));
            Assert.IsTrue(names.Contains("FullName"));
        }
    }
}
