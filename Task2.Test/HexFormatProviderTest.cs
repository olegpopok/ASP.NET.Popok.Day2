using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Library;

namespace Task2.Test
{
    [TestClass]
    public class HexFormatProviderTest
    {
        [TestMethod]
        public void FormatTest()
        {
            int number = 327497;

            string convert = Convert.ToString(number, 16);
            string hexFormatProvider = String.Format(new HexFormatProvider(),"{0:H}", number);
            Assert.AreEqual(convert, hexFormatProvider);

            convert = Convert.ToString(-number, 16);
            hexFormatProvider = String.Format(new HexFormatProvider(), "{0:H}", -number);
            Assert.AreEqual(convert, hexFormatProvider);
        }
    }
}
