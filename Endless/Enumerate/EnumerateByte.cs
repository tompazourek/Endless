using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static partial class Enumerate
    {
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
    }
}