﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionsSuite.Standard.Tests.System.Int32Extensions
{
    [TestClass]
    public class IsNullOrZero
    {
        [TestMethod]
        public void NullTest()
        {
            int? value = null;
            Assert.IsTrue(value.IsNullOrZero());
        }

        [TestMethod]
        public void ZeroTest()
        {
            int? value = 0;
            Assert.IsTrue(value.IsNullOrZero());
        }

        [TestMethod]
        public void ValueTest()
        {
            int? value = 47;
            Assert.IsFalse(value.IsNullOrZero());
        }
    }
}
