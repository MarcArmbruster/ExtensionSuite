using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.StringExtensions;

[TestClass]
public class MatchesWildCardTests
{
    [TestMethod]
    public void WildCardCompleteTests()
    {            
        string text = "Jürgen";
        
        Assert.IsTrue(text.MatchesWildCard("*ü?g*"));
        Assert.IsTrue(text.MatchesWildCard("jü?g*"));
        Assert.IsTrue(text.MatchesWildCard("*ürg?*"));
    }

    [TestMethod]
    public void WildCardStartTests()
    {
        string text = "Jürgen";
        
        Assert.IsTrue(text.MatchesWildCard("*rgen"));
        Assert.IsTrue(text.MatchesWildCard("jürgen"));
        Assert.IsTrue(text.MatchesWildCard("*Jürgen"));
    }

    [TestMethod]
    public void WildCardEndTests()
    {
        string text = "Jürgen";

        Assert.IsTrue(text.MatchesWildCard("Jü*"));
        Assert.IsTrue(text.MatchesWildCard("jürgen"));
        Assert.IsTrue(text.MatchesWildCard("Jürgen*"));
    }
}
