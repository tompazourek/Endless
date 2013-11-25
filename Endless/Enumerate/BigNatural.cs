using System.Numerics;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Endless
{
    public static class BigNatural
    {
        public static IEnumerable<BigInteger> NumbersWithZero
        {
            get { return Enumerate.From(new BigInteger(0)); }
        }

        public static IEnumerable<BigInteger> Numbers
        {
            get { return Enumerate.From(new BigInteger(1)); }
        }
    }
}