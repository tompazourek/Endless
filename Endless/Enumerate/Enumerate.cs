using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static class Enumerate
    {
        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<BigInteger> From(BigInteger n0)
        {
            return new FromEnumerable<BigInteger>(n0);
        }

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<long> From(long n0)
        {
            return new FromEnumerable<long>(n0);
        }

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<int> From(int n0)
        {
            return new FromEnumerable<int>(n0);
        }

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<float> From(float n0)
        {
            return new FromEnumerable<float>(n0);
        }

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<double> From(double n0)
        {
            return new FromEnumerable<double>(n0);
        }

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<decimal> From(decimal n0)
        {
            return new FromEnumerable<decimal>(n0);
        }

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<char> From(char n0)
        {
            return new FromEnumerable<char>(n0);
        }

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<byte> From(byte n0)
        {
            return new FromEnumerable<byte>(n0);
        }
    }
}