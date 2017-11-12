using System;

namespace Endless
{
    /// <summary>
    /// Extensions to <see cref="Random" />
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns one random byte.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static byte NextByte(this Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            var result = (byte)random.Next(byte.MinValue, byte.MaxValue + 1);
            return result;
        }

        /// <summary>
        /// Returns one random char.
        /// </summary>
        /// <param name="random"></param>
        /// <returns></returns>
        public static char NextChar(this Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            var result = (char)random.Next(char.MinValue, char.MaxValue + 1);
            return result;
        }
    }
}