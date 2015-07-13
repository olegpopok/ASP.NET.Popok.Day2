using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Task3.Test
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void EuclideanGCDTestMethod()
        {
            Assert.AreEqual(24, Library.Math.EuclideanGCD(48, 72));
            Assert.AreEqual(3, Library.Math.EuclideanGCD(9, 12, 18));
            Assert.AreEqual(4, Library.Math.EuclideanGCD(8, 12, 16, 20));
        }

        [TestMethod]
        public void BinaryGCDTestMethod()
        {
            Assert.AreEqual(24, Library.Math.BinaryGCD(48, 72));
            Assert.AreEqual(3, Library.Math.BinaryGCD(9, 12, 18));
            Assert.AreEqual(4, Library.Math.BinaryGCD(8, 12, 16, 20));
        }
    }
}
