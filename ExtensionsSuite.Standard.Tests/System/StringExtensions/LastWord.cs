namespace ExtensionsSuite.Standard.Tests.System.StringExtensions;

using global::System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LastWord
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastWordCharSourceNullTest()
    {
        string source = null;
        source.LastWord(' ');
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void LastWordStringSourceNullTest()
    {
        string source = null;
        source.LastWord(" ");
    }

    [TestMethod]
    public void LastWordStringPositiveTest()
    {
        string source = "String extensions can be helpful!";
        string lastWord = source.LastWord(" ");
        Assert.AreEqual("helpful!", lastWord);
    }

    [TestMethod]
    public void LastWordCharPositiveTest()
    {
        string source = "String extensions can be helpful!";
        string lastWord = source.LastWord(' ');
        Assert.AreEqual("helpful!", lastWord);
    }

    [TestMethod]
    public void SingleLastWordTest()
    {
        string source = "Test";
        string firstWord = source.FirstWord(',');
        Assert.AreEqual("Test", firstWord);
    }
}
