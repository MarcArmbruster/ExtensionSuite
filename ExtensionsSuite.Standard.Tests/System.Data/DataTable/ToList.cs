namespace ExtensionsSuite.Standard.Tests.System.Data
{
    using global::System.Collections.Generic;
    using global::System.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    public class TestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
        
    [TestClass]
    public class ToList
    {
        [TestMethod]
        public void PositiveTest()
        {
            var datatable = new DataTable();
            datatable.Columns.Add("Id", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Value", typeof(decimal));

            datatable.Rows.Add(new object[] { 1, "A", 11m });
            datatable.Rows.Add(new object[] { 2, "B", 22m });
            datatable.Rows.Add(new object[] { 3, "C", 33m });

            List<TestEntity> list = datatable.ToList<TestEntity>();

            Assert.AreEqual(3, list.Count);
            
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual("A", list[0].Name);
            Assert.AreEqual(11m, list[0].Value);

            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual("B", list[1].Name);
            Assert.AreEqual(22m, list[1].Value);

            Assert.AreEqual(3, list[2].Id);
            Assert.AreEqual("C", list[2].Name);
            Assert.AreEqual(33m, list[2].Value);
        }
    }
}
