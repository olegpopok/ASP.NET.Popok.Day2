using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Library;

namespace Task1.Test
{
    [TestClass]
    public class NewtonTest
    {
        [TestMethod]
        public void RadicalTest()
        {
            double epsilon = 0.0001;

            double value = Newton.Radical(8, 3, epsilon);

            Assert.AreEqual(2, value, epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RadicalErorTest()
        {
            Newton.Radical(-16, 4, 0.01);
        }
    }
}
