using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static class Enumerate
    {
        #region int

        public static IEnumerable<int> From(int n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<int> FromThen(int n0, int n1)
        {
            int distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<int> FromTo(int n0, int m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<int> FromThenTo(int n0, int n1, int m)
        {
            Func<int, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<int, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }

        #endregion

        #region byte

        public static IEnumerable<byte> From(byte n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<byte> FromThen(byte n0, byte n1)
        {
            int distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => (byte) (x + distance));
            }
        }

        public static IEnumerable<byte> FromTo(byte n0, byte m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<byte> FromThenTo(byte n0, byte n1, byte m)
        {
            Func<byte, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<byte, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }

        #endregion

        #region long

        public static IEnumerable<long> From(long n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<long> FromThen(long n0, long n1)
        {
            long distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<long> FromTo(long n0, long m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<long> FromThenTo(long n0, long n1, long m)
        {
            Func<long, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<long, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }

        #endregion

        #region char

        public static IEnumerable<char> From(char n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<char> FromThen(char n0, char n1)
        {
            int distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => (char) (x + distance));
            }
        }

        public static IEnumerable<char> FromTo(char n0, char m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<char> FromThenTo(char n0, char n1, char m)
        {
            Func<char, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<char, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }

        #endregion

        #region double

        public static IEnumerable<double> From(double n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<double> FromThen(double n0, double n1)
        {
            double distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<double> FromTo(double n0, double m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<double> FromThenTo(double n0, double n1, double m)
        {
            Func<double, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<double, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }

        #endregion

        #region decimal

        public static IEnumerable<decimal> From(decimal n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<decimal> FromThen(decimal n0, decimal n1)
        {
            decimal distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<decimal> FromTo(decimal n0, decimal m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<decimal> FromThenTo(decimal n0, decimal n1, decimal m)
        {
            Func<decimal, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<decimal, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }

        #endregion

        #region float

        public static IEnumerable<float> From(float n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<float> FromThen(float n0, float n1)
        {
            float distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<float> FromTo(float n0, float m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<float> FromThenTo(float n0, float n1, float m)
        {
            Func<float, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<float, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }

        #endregion
    }
}