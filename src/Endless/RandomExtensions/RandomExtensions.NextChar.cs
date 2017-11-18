using System;

namespace Endless
{
    public static partial class RandomExtensions
    {
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