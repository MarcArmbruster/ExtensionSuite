using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions
{
    [TestClass]
    public class FirstWord
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstWordCharSourceNullTest()
        {
            string source = null;
            source.FirstWord(',');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstWordStringSourceNullTest()
        {
            string source = null;
            source.FirstWord(",;");
        }

        [TestMethod]
        public void FirstWordStringPositiveTest()
        {
            string source = "String extensions can be helpful!";
            string firstWord = source.FirstWord(" ");
            Assert.AreEqual("String", firstWord);
        }

        [TestMethod]
        public void FirstWordCharPositiveTest()
        {
            string source = "String extensions can be helpful!";
            string firstWord = source.FirstWord(' ');
            Assert.AreEqual("String", firstWord);
        }

        [TestMethod]
        public void FirstWordBlankTest()
        {
            string source = " String extensions can be helpful!";
            string firstWord = source.FirstWord(' ');
            Assert.AreEqual(string.Empty, firstWord);
        }

        [TestMethod]
        public void FirstWordTrimTest()
        {
            string source = " String;extensions;can;be;helpful!";
            string firstWord = source.FirstWord(';');
            Assert.AreEqual("String", firstWord);
        }

        [TestMethod]
        public void SingleFirstWordTest()
        {
            string source = "Test";
            string firstWord = source.FirstWord(',');
            Assert.AreEqual("Test", firstWord);
        }
    }
}
