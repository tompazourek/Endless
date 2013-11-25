using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static partial class Enumerate
    {
        public static IEnumerable<BigInteger> From(BigInteger n0)
        {
            return n0.Iterate(x => ++x);
        }

        public static IEnumerable<BigInteger> FromThen(BigInteger n0, BigInteger n1)
        {
            BigInteger distance = n1 - n0;
            if (distance == 0)
                return n0.Yield();

            unchecked
            {
                return n0.Iterate(x => x + distance);
            }
        }

        public static IEnumerable<BigInteger> FromTo(BigInteger n0, BigInteger m)
        {
            return FromThenTo(n0, ++n0, m);
        }

        public static IEnumerable<BigInteger> FromThenTo(BigInteger n0, BigInteger n1, BigInteger m)
        {
            Func<BigInteger, bool> predicate = n0 > n1 ? (x => x >= m) : new Func<BigInteger, bool>(x => x <= m);
            return FromThen(n0, n1).TakeWhile(predicate);
        }
    }
}