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
            : this((IFormatProvider)CultureInfo.CurrentCulture) { }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            byte[] bytes;
            if (GetBytes(arg, out bytes) && format == "H")
            {
                return GetHexNumber(bytes);
            }
            else
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            }
        

        }

        private bool GetBytes(object arg, out byte[] bytes)
        {
            if (arg is sbyte)
            {
                string byteString = ((sbyte)arg).ToString("X2");
                bytes = new byte[1] { Byte.Parse(byteString, System.Globalization.NumberStyles.HexNumber) };
            }
            else if (arg is byte)
                bytes = new byte[1] { (byte)arg };
            else if (arg is short)
                bytes = BitConverter.GetBytes((short)arg);
            else if (arg is int)
                bytes = BitConverter.GetBytes((int)arg);
            else if (arg is long)
                bytes = BitConverter.GetBytes((long)arg);
            else if (arg is ushort)
                bytes = BitConverter.GetBytes((ushort)arg);
            else if (arg is uint)
                bytes = BitConverter.GetBytes((uint)arg);
            else if (arg is ulong)
                bytes = BitConverter.GetBytes((ulong)arg);
            else if (arg is BigInteger)
                bytes = ((BigInteger)arg).ToByteArray();
            else
            {
                bytes = new byte[0];
                return false;
            }
            return true;
        }

        private string GetHexNumber(byte[] bytes)
        {
            string result = string.Empty;
            int[] digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            for (int i = bytes.GetUpperBound(0); i >= bytes.GetLowerBound(0); i--)
            {
                char firstHexDigitInByte = hexDigits[Array.IndexOf(digits, bytes[i] / 16)];
                char lastHexDigitInByte = hexDigits[Array.IndexOf(digits, bytes[i] % 16)];
                result = result + firstHexDigitInByte + lastHexDigitInByte;
            }
            return result.TrimStart('0');
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, parent);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
}
