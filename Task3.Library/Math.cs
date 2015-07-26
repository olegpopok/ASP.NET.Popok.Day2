using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    public static class Math
    {
        public static int EuclideanGCD(int a, int b)
        {
            return b == 0 ? a : EuclideanGCD(b, a % b);
        }

        public static int EuclideanGCD(int a, int b, int c)
        {
            return EuclideanGCD(EuclideanGCD(a, b), c);
        }

        public static int EuclideanGCD(params int[] numbers)
        {
            return CalculateGcdHelper(numbers, EuclideanGCD);
        }

        public static int BinaryGCD(int a, int b)
        {
            if (a == b)
            {
                return a;
            }
            if (b == 0 || a == 0)
            {
                return a == 0 ? b : a;
            }
            if (a % 2 == 0 && b % 2 == 0)
            {
                return 2 * BinaryGCD(a / 2, b / 2);
            }
            if (a % 2 == 0 || b % 2 == 0)
            {
                return a % 2 == 0 ? BinaryGCD(a / 2, b) : BinaryGCD(a, b / 2);
            }
            return a > b ? BinaryGCD((a - b) / 2, b) : BinaryGCD((b - a) / 2, a);
        }

        public static int BinaryGCD(int a, int b, int c)
        {
            return BinaryGCD(BinaryGCD(a, b), c);
        }

        public static int BinaryGCD(params int[] numbers)
        {
            return CalculateGcdHelper(numbers, BinaryGCD);
        }

        private static int CalculateGcdHelper(int[] numbers, Func<int, int, int> GcdAlgorithm)
        {
            int gcd = GcdAlgorithm(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length; i++)
            {
                gcd = GcdAlgorithm(gcd, numbers[i]);
            }
            return gcd;
        }
    }
}
