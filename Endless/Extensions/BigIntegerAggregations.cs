#region License

// Copyright (C) Tomáš Pažourek, 2014
// All rights reserved.
// 
// Distributed under MIT license as a part of project Endless.
// https://github.com/tompazourek/Endless

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Endless
{
    /// <summary>
    /// Variants of Min, Max and Sum with BigInteger.
    /// </summary>
    public static class BigIntegerAggregations
    {
        /// <summary>
        /// Computes the sum of a sequence of <see cref="BigInteger"/> values.
        /// </summary>
        /// <param name="source">A sequence of <see cref="BigInteger"/> values to calculate the sum of.</param>
        /// <returns>The sum of the values in the sequence.</returns>
        public static BigInteger Sum(this IEnumerable<BigInteger> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            BigInteger result = source.Aggregate(new BigInteger(0), (x, y) => x + y);
            return result;
        }

        /// <summary>
        /// Computes the sum of a sequence of nullable <see cref="BigInteger"/> values.
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="BigInteger"/> values to calculate the sum of.</param>
        /// <returns> he sum of the values in the sequence.</returns>
        public static BigInteger? Sum(this IEnumerable<BigInteger?> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            BigInteger result = source
                .Where(x => x.HasValue)
                .Aggregate<BigInteger?, BigInteger>(0, (x, y) => x + y.GetValueOrDefault());

            return result;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of <see cref="BigInteger"/> values.
        /// </summary>
        /// <param name="source">A sequence of <see cref="BigInteger"/> values to determine the minimum value of.</param>
        /// <returns>The minimum value in the sequence.</returns>
        public static BigInteger Min(this IEnumerable<BigInteger> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            BigInteger minimum = 0;
            bool isFirstItemProcessed = false;
            foreach (BigInteger currentItem in source)
            {
                if (isFirstItemProcessed)
                {
                    if (currentItem < minimum)
                        minimum = currentItem;
                }
                else
                {
                    minimum = currentItem;
                    isFirstItemProcessed = true;
                }
            }

            if (!isFirstItemProcessed)
                throw new InvalidOperationException("Sequence does not contain any elements");

            return minimum;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of nullable <see cref="BigInteger"/> values.
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="BigInteger"/> values to determine the minimum value of.</param>
        /// <returns>The minimum value in the sequence.</returns>
        public static BigInteger? Min(this IEnumerable<BigInteger?> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            BigInteger? minimum = null;
            foreach (var currentItem in source)
            {
                if (!currentItem.HasValue)
                    continue;

                if (!minimum.HasValue || currentItem.Value < minimum.Value)
                    minimum = currentItem;
            }
            return minimum;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of <see cref="BigInteger"/> values.
        /// </summary>
        /// <param name="source">A sequence of <see cref="BigInteger"/> values to determine the maximum value of.</param>
        /// <returns>The maximum value in the sequence.</returns>
        public static BigInteger Max(this IEnumerable<BigInteger> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            BigInteger maximum = 0;
            bool isFirstItemProcessed = false;
            foreach (BigInteger currentItem in source)
            {
                if (isFirstItemProcessed)
                {
                    if (currentItem > maximum)
                        maximum = currentItem;
                }
                else
                {
                    maximum = currentItem;
                    isFirstItemProcessed = true;
                }
            }

            if (!isFirstItemProcessed)
                throw new InvalidOperationException("Sequence does not contain any elements");

            return maximum;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of nullable <see cref="BigInteger"/> values.
        /// </summary>
        /// <param name="source">A sequence of nullable <see cref="BigInteger"/> values to determine the maximum value of.</param>
        /// <returns>The maximum value in the sequence.</returns>
        public static BigInteger? Max(this IEnumerable<BigInteger?> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            BigInteger? maximum = null;
            foreach (var currentItem in source)
            {
                if (!currentItem.HasValue)
                    continue;

                if (!maximum.HasValue || currentItem.Value > maximum.Value)
                    maximum = currentItem;
            }
            return maximum;
        }
    }
}