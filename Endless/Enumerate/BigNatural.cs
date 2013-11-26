using System.Numerics;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

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
        public static IEnumerable<BigInteger> NumbersWithZero
        {
            get { return Enumerate.From(new BigInteger(0)); }
        }

        /// <summary>
        /// Sequence of natural numbers (1, 2, 3, ...)
        /// </summary>
        public static IEnumerable<BigInteger> Numbers
        {
            get { return Enumerate.From(new BigInteger(1)); }
        }
    }
}