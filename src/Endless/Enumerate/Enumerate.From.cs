using System;
using System.Numerics;

namespace Endless
{
    public static class Enumerate
    {
        /// <summary>
        /// Endless collection of T incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<T> From<T>(T n0) where T : struct => new FromEnumerable<T>(n0);

        /// <summary>
        /// Endless collection of times incremented by one day.
        /// </summary>
        /// <returns>(t0, t0 + 1, t0 + 2, t0 + 3, ...)</returns>
        public static IFromEnumerable<DateTime> From(DateTime t0) => new FromEnumerable<DateTime>(new DateTimeFromStepToEnumerator(t0));

        /// <summary>
        /// Endless collection of times incremented by one day.
        /// </summary>
        /// <returns>(t0, t0 + 1, t0 + 2, t0 + 3, ...)</returns>
        public static IFromEnumerable<DateTimeOffset> From(DateTimeOffset t0) => new FromEnumerable<DateTimeOffset>(new DateTimeOffsetFromStepToEnumerator(t0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<BigInteger> From(BigInteger n0) => new FromEnumerable<BigInteger>(new BigIntegerFromStepToEnumerator(n0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<long> From(long n0) => new FromEnumerable<long>(new LongFromStepToEnumerator(n0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<int> From(int n0) => new FromEnumerable<int>(new IntFromStepToEnumerator(n0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<float> From(float n0) => new FromEnumerable<float>(new FloatFromStepToEnumerator(n0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<double> From(double n0) => new FromEnumerable<double>(new DoubleFromStepToEnumerator(n0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<decimal> From(decimal n0) => new FromEnumerable<decimal>(new DecimalFromStepToEnumerator(n0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<char> From(char n0) => new FromEnumerable<char>(new CharFromStepToEnumerator(n0));

        /// <summary>
        /// Endless collection of numbers incremented by one.
        /// </summary>
        /// <returns>(n0, n0 + 1, n0 + 2, n0 + 3, ...)</returns>
        public static IFromEnumerable<byte> From(byte n0) => new FromEnumerable<byte>(new ByteFromStepToEnumerator(n0));
    }
}