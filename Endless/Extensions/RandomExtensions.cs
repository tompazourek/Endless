using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endless
{
    public static class RandomExtensions
    {
        public static byte NextByte(this Random random)
        {
            var result = (byte)random.Next(byte.MinValue, byte.MaxValue + 1);
            return result;
        }

        public static char NextChar(this Random random)
        {
            var result = (char)random.Next(char.MinValue, char.MaxValue + 1);
            return result;
        }
    }
}
