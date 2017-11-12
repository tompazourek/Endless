using System.Numerics;

namespace Endless
{
    /// <summary>
    /// Natural numbers
    /// </summary>
    public static class BigNatural
    {
        /// <summary>
        /// Sequence of natural numbers with zero (0, 1, 2, 3, ...)
        /// </summary>
        public static IFromEnumerable<BigInteger> NumbersWithZero => Enumerate.From(new BigInteger(0));

        /// <summary>
        /// Sequence of natural numbers (1, 2, 3, ...)
        /// </summary>
        public static IFromEnumerable<BigInteger> Numbers => Enumerate.From(new BigInteger(1));
    }
}