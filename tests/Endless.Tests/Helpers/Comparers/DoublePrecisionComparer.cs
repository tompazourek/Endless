﻿using System;
using System.Collections.Generic;

namespace Endless.Tests.Helpers
{
    /// <summary>
    /// Compares two doubles and takes only specific number of fractional digits into account.
    /// </summary>
    public class DoublePrecisionComparer : IComparer<double>, IEqualityComparer<double>
    {
        public DoublePrecisionComparer(int precision)
        {
            Precision = precision;
        }

        /// <summary>
        /// Number of fractional digits
        /// </summary>
        public int Precision { get; }

        public int Compare(double x, double y)
        {
            var xp = FloorWithPrecision(x, Precision);
            var yp = FloorWithPrecision(y, Precision);

            var result = Comparer<double>.Default.Compare(xp, yp);
            return result;
        }

        /// <summary>
        /// Floors number and preserves specific numer of decimal places.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        private static double FloorWithPrecision(double input, int decimalPlaces)
        {
            var power = Math.Pow(10, decimalPlaces);
            var output = Math.Floor(input * power) / power;
            return output;
        }

        public bool Equals(double x, double y) => Compare(x, y) == 0;

        public int GetHashCode(double obj) => throw new NotSupportedException();
    }
}