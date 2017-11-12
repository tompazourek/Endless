﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Xunit;

namespace Endless.Tests
{
    public class ProjectEulerTests
    {
        /// <remarks>
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </remarks>
        [Fact]
        public void Problem1_MultiplesOf3And5()
        {
            var sum = Natural.Numbers.TakeUntil(1000).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
            Assert.Equal(233168, sum);
        }

        /// <remarks>
        /// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        /// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
        /// </remarks>
        [Fact]
        public void Problem2_EvenFibonacciNumbers()
        {
            var fibonacci = Tuple.Create(new BigInteger(0), new BigInteger(1)).Iterate(x => Tuple.Create(x.Item2, x.Item1 + x.Item2)).Select(x => x.Item1);
            var sequence = fibonacci.TakeWhile(x => x < 4 * 1000 * 1000).Where(x => x % 2 == 0);
            var sum = sequence.Aggregate((x, y) => x + y);

            Assert.Equal(new BigInteger(4613732), sum);
        }

        /// <remarks>
        /// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
        /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
        /// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
        /// </remarks>
        [Fact(Skip = "Takes long to compute.")]
        public void Problem34_DigitFactorials()
        {
            long Factorial(int n)
            {
                return 1.Yield()
                    .Concat(Natural.Numbers.Scan((x, y) => x * y))
                    .ElementAt(n);
            }

            IEnumerable<int> Digits(int n)
            {
                return n
                    .Iterate(x => x / 10)
                    .TakeUntil(0)
                    .Select(x => x % 10);
            }

            const int lowerBound = 10; // cannot be one digit
            var upperDigitCount = Enumerate.From(2).First(x => x * Factorial(9) < Math.Pow(10, x));
            var upperBound = (int)(upperDigitCount * Factorial(9));

            long numbersSum = Enumerate.From(lowerBound).To(upperBound).AsParallel()
                .Where(x => Digits(x).Sum((Func<int, long>)Factorial) == x) // sum+equals could be optimized
                .Sum();

            Assert.Equal(40730, numbersSum);
        }
    }
}