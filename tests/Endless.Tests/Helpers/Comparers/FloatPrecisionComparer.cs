using System;
using System.Collections.Generic;

namespace Endless.Tests.Helpers
{
    /// <summary>
    /// Compares two floats and takes only specific number of fractional digits into account.
    /// </summary>
    public class FloatPrecisionComparer : IComparer<float>, IEqualityComparer<float>
    {
        public FloatPrecisionComparer(int precision)
        {
            Precision = precision;
        }

        /// <summary>
        /// Number of fractional digits
        /// </summary>
        public int Precision { get; }

        public int Compare(float x, float y)
        {
            var xp = FloorWithPrecision(x, Precision);
            var yp = FloorWithPrecision(y, Precision);

            var result = Comparer<float>.Default.Compare(xp, yp);
            return result;
        }

        /// <summary>
        /// Floors number and preserves specific numer of decimal places.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        private static float FloorWithPrecision(float input, int decimalPlaces)
        {
            var power = (float)Math.Pow(10, decimalPlaces);
            var output = (float)Math.Floor(input * power) / power;
            return output;
        }

        public bool Equals(float x, float y) => Compare(x, y) == 0;

        public int GetHashCode(float obj) => throw new NotSupportedException();
    }
}