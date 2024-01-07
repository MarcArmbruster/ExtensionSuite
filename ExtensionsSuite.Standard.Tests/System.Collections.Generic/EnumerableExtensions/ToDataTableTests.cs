namespace ExtensionsSuite.Standard.Tests.System.Collections.Generic.EnumerableExtensions
{
    using global::System.Data;
    using global::System.Linq;
    using global::System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }

    [TestClass]
    public class ToDataTableTests
    {
        [TestMethod]
        public void ToListTest()
        {
            List<Person> persons = new List<Person>
            {
                new Person { Id = 1, FirstName = "Marc", LastName = "Armbruster" },
                new Person { Id = 1, FirstName = "Donald", LastName = "Duck" },
                new Person { Id = 1, FirstName = "Daisy", LastName = "Duck" },
                new Person { Id = 1, FirstName = "Dagobert", LastName = "Duck" }
            };

            var dt = persons.ToDataTable();

            Assert.AreEqual(3, dt.Columns.Count);
            Assert.AreEqual(4, dt.Rows.Count);
            
            Assert.IsTrue(dt.Columns.Contains("Id"));
            Assert.IsTrue(dt.Columns.Contains("FirstName"));
            Assert.IsTrue(dt.Columns.Contains("LastName"));

            Assert.IsTrue(dt.Columns["Id"].DataType.Equals(typeof(int)));
            Assert.IsTrue(dt.Columns["FirstName"].DataType.Equals(typeof(string)));
            Assert.IsTrue(dt.Columns["LastName"].DataType.Equals(typeof(string)));
        }
    }
}
