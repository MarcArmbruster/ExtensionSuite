namespace ExtensionsSuite.Standard.Tests.System.Dynamic
{
    using global::System;
    using global::System.Data;
    using global::System.Dynamic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for ExpandoObjectTests
    /// </summary>
    [TestClass]
    public class ExpandoObjectTests
    {
        [TestMethod]
        public void ContainsPropertyTest()
        {
            var target = new ExpandoObject();

            target.SetPropertyValue<string>("Text", "Hello");
            target.SetPropertyValue<int>("Number", 12);

            Assert.IsTrue(target.ContainsProperty("Text"));
            Assert.IsFalse(target.ContainsProperty("text"));

            Assert.IsTrue(target.ContainsProperty("Number"));
            Assert.IsFalse(target.ContainsProperty("NumBer"));

            Assert.IsFalse(target.ContainsProperty("AnyOther"));
        }

        [TestMethod]
        public void GetPropertyValueTest()
        {
            var target = new ExpandoObject();

            target.SetPropertyValue<string>("Text", "Hello");
            target.SetPropertyValue<int>("Number", 12);

            Assert.AreEqual("Hello", target.GetPropertyValue<string>("Text"));
            Assert.IsNull(target.GetPropertyValue<object>("Something"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void GetPropertyValueInvalidCastTest()
        {
            var target = new ExpandoObject();

            target.SetPropertyValue<string>("Text", "Hello");

            Assert.AreEqual(default(decimal), target.GetPropertyValue<decimal>("Text"));
        }

        [TestMethod]
        public void TryGetPropertyValueFoundTest()
        {
            var target = new ExpandoObject();

            target.SetPropertyValue<string>("Text", "Hello");

            string value;
            bool success = target.TryGetPropertyValue<string>("Text", out value);
            Assert.IsTrue(success);
            Assert.AreEqual("Hello", value);
        }

        [TestMethod]
        public void TryGetPropertyValueNotFoundTest()
        {
            var target = new ExpandoObject();

            target.SetPropertyValue<string>("Text2", "Hello");

            string value;
            bool success = target.TryGetPropertyValue<string>("Text", out value);
            Assert.IsFalse(success);
            Assert.AreEqual(default(string), value);
        }

        [TestMethod]
        public void CreatePropertyTest()
        {
            var target = new ExpandoObject();

            target.CreateProperty<string>("ColorCode");
            
            Assert.IsTrue(target.ContainsProperty("ColorCode"));
            Assert.IsTrue(target.IsNullOrDefault<string>("ColorCode"));
        }

        [TestMethod]
        public void IsNullTest()
        {
            var target = new ExpandoObject();

            target.CreateProperty<DataTable>("ColorTabke");

            Assert.IsTrue(target.IsNull("ColorTabke"));
        }

        [TestMethod]
        public void SetPropertyTest()
        {
            var target = new ExpandoObject();

            target.SetPropertyValue<string>("ColorCode", "Blue");
            target.SetPropertyValue<string>("ColorCode", "Green");

            Assert.IsTrue(target.ContainsProperty("ColorCode"));
            Assert.AreEqual("Green", target.GetPropertyValue<string>("ColorCode"));
        }
    }
}
