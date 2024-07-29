namespace ExtensionsSuite.Core.Tests.System.Security.SecureStringExtensions;

using global::System;
using global::System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ToRawStringTests
{
    [TestMethod]
    public void ToRawStringTest()
    {
        string origValue = "This is an example string text";

        SecureString secure = origValue.ToSecureString();

        string rawValue = secure.ToRawString();

        Assert.AreEqual(origValue, rawValue);
    }
}