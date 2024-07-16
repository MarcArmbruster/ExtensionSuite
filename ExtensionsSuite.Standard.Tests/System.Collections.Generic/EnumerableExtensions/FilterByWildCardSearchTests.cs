namespace ExtensionsSuite.Core.System.Collections.Generic
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// TODO -> Unit Tests.
    /// </summary>
    /// <remarks>
    ///   <para><b>History</b></para>
    ///   <list type="table">
    ///   <item>
    ///   <term><b>Author:</b></term>
    ///   <description>armbrusm, PTA GmbH</description>
    ///   </item>
    ///   <item>
    ///   <term><b>Date:</b></term>
    ///   <description>7/16/2024 8:53:11 AM</description>
    ///   </item>
    ///   <item>
    ///   <term><b>Remarks:</b></term>
    ///   <description>Initial version.</description>
    ///   </item>
    ///   </list>
    /// </remarks>
    [TestClass]
    public class FilterByWildCardSearchTests
    {
        /// <summary>
        /// Filter Test Method.
        /// </summary>  
        [TestMethod]
        public void FilterTest()
        {
            // Arrange
            IEnumerable<string> data = ["Marc", "Armbruster", "Gerhard", "Ahrens"];
            // Act
            IEnumerable<string> result = data.FilterByWildCardSearch("*ar*");

            // Assert
            Assert.IsTrue(result.Any(i => i == "Marc"));
            Assert.IsTrue(result.Any(i => i == "Armbruster"));
            Assert.IsTrue(result.Any(i => i == "Gerhard"));
            Assert.IsFalse(result.Any(i => i == "Ahrens"));

            Assert.AreEqual(3, result.Count());
        }
    }
}