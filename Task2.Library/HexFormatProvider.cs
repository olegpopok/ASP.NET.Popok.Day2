using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;

namespace Task2.Library
{
    public class HexFormatProvider : IFormatProvider, ICustomFormatter
    {
        private static readonly string hexDigits = "0123456789abcdef";

        private IFormatProvider parent;

        public HexFormatProvider(IFormatProvider parent)
        {
            this.parent = parent;
        }

        public HexFormatProvider() 
            : this(CultureInfo.CurrentCulture) { }


        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(IFormatProvider))
                return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg == null || format != "H")
                return string.Format(parent, "{0:" + format + "}");

            byte[] bytes = GetBytes(arg);
            
            if (bytes != null)
            {
                string result = string.Empty;
                int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                for (int i = bytes.GetUpperBound(0); i >= bytes.GetLowerBound(0); i--)
                {
                    result = result + hexDigits[Array.IndexOf(digits, bytes[i] / 16)]
                        + hexDigits[Array.IndexOf(digits, bytes[i] % 16)];
                }
            }



            return String.Empty;

        }

        private static byte[] GetBytes(object arg)
        {
            if (arg is sbyte)
            {
                string byteString = ((sbyte)arg).ToString("X2");
                return new byte[1] { Byte.Parse(byteString, System.Globalization.NumberStyles.HexNumber) };
            }
            else if (arg is byte)
                return new byte[1] { (byte)arg };
            else if (arg is short)
                return BitConverter.GetBytes((short)arg);
            else if (arg is int)
                return BitConverter.GetBytes((int)arg);
            else if (arg is long)
                return BitConverter.GetBytes((long)arg);
            else if (arg is ushort)
                return BitConverter.GetBytes((ushort)arg);
            else if (arg is uint)
                return BitConverter.GetBytes((uint)arg);
            else if (arg is ulong)
                return BitConverter.GetBytes((ulong)arg);
            else if (arg is BigInteger)
                return ((BigInteger)arg).ToByteArray();
            else
                return null;
        }
    }
}
