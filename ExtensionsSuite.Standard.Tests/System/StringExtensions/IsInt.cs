namespace ExtensionsSuite.Standard.Tests.System.StringExtensions;

using global::System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class IsInt
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void IsIntSourceNullTest()
    {
        string source = null;
        source.IsInt();
    }

    [TestMethod]        
    public void IsIntFalseFromTextTest()
    {
        string source = "any text";
        Assert.IsFalse(source.IsInt());
    }

    [TestMethod]
    public void IsIntTrueTest()
    {
        string source = "132";
        Assert.IsTrue(source.IsInt());
    }

    [TestMethod]
    public void IsIntFalseFromCommaTest()
    {
        string source = "13,2";
        Assert.IsFalse(source.IsInt());
    }

    [TestMethod]
    public void IsIntFalseFromPointTest()
    {
        string source = "13.2";
        Assert.IsFalse(source.IsInt());
    }

    [TestMethod]
    public void IsIntToBigTest()
    {
        string source = (((long)int.MaxValue) + 1).ToString();
        Assert.IsFalse(source.IsInt());
    }

    [TestMethod]
    public void IsShortToLowTest()
    {
        string source = (((long)int.MinValue) - 1).ToString();
        Assert.IsFalse(source.IsInt());
    }
}
