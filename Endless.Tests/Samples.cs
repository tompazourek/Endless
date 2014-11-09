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
using System.IO;
using System.Linq;
using System.Text;
using Endless.Functional;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class Samples
    {
        /// <summary>
        /// Five weekends
        /// The month of October in 2010 has five Fridays, five Saturdays, and five Sundays. 
        /// 
        /// Task:
        /// Write a program to show all months that have this same characteristic of five full weekends from the year 1900 through 2100 (Gregorian calendar). 
        /// Show the number of months with this property (there should be 201).
        /// </summary>
        /// <remarks>http://rosettacode.org/wiki/Five_weekends</remarks>
        [Test]
        public void FiveWeekends_RosettaCode()
        {
            const int startYear = 1900, endYear = 2100;

            var days = new DateTime(startYear, 1, 1).Iterate(x => x.AddDays(1)).TakeWhile(x => x.Year <= endYear);
            var months = days.GroupBy(x => new { x.Year, x.Month });
            var fiveWeekendMonths = months.Where(x =>
                                                     x.Count(y => y.DayOfWeek == DayOfWeek.Friday) == 5 &&
                                                         x.Count(y => y.DayOfWeek == DayOfWeek.Saturday) == 5 &&
                                                         x.Count(y => y.DayOfWeek == DayOfWeek.Sunday) == 5);

            Assert.AreEqual(201, fiveWeekendMonths.Count());
        }

        [Test]
        public void FizzBuzz_Sample()
        {
            var fizzBuzz = Natural.Numbers.Select(x =>
                {
                    if (x % 15 == 0) return "Fizz Buzz";
                    if (x % 3 == 0) return "Fizz";
                    if (x % 5 == 0) return "Buzz";
                    return x.ToString();
                });
            var result = fizzBuzz.Take(35).JoinStrings(", ");
            Assert.AreEqual("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, Fizz Buzz, 16, 17, Fizz, 19, Buzz, Fizz, 22, 23, Fizz, Buzz, 26, Fizz, 28, 29, Fizz Buzz, 31, 32, Fizz, 34, Buzz", result);
        }

        [Test]
        public void DigitSum_Sample()
        {
            Func<int, int> digitSum = a => Math.Abs(a).Iterate(x => x / 10).TakeUntil(0).Select(x => x % 10).Sum();
            Assert.AreEqual(0, digitSum(0));
            Assert.AreEqual(1 + 2 + 3, digitSum(123));
            Assert.AreEqual(9 + 5 + 4 + 1 + 6, digitSum(95416));
            Assert.AreEqual(9 + 9 + 0 + 9 + 9, digitSum(99099));
            Assert.AreEqual(9 + 5 + 4 + 1 + 6, digitSum(-95416));
        }

        [Test]
        public void AlternatingDigitSum_Sample()
        {
            Func<int, IEnumerable<int>> digits =
                number => Math.Abs(number).Iterate(x => x / 10).TakeUntil(0).Select(x => x % 10).Reverse();

            Func<IEnumerable<int>, IEnumerable<int>> alternateSequence =
                sequence => sequence.Zip(new[] { 1, -1 }.Cycle(), (x, y) => x * y);

            Func<int, int> alternatingDigitSum = Function.Compose(x => x.Sum(), alternateSequence, digits); // sum of alternating sequence of digits

            Assert.AreEqual(0, alternatingDigitSum(0));
            Assert.AreEqual(1 - 2 + 3, alternatingDigitSum(123));
            Assert.AreEqual(9 - 5 + 4 - 1 + 6, alternatingDigitSum(95416));
            Assert.AreEqual(9 - 9 + 0 - 9 + 9, alternatingDigitSum(99099));
            Assert.AreEqual(9 - 5 + 4 - 1 + 6, alternatingDigitSum(-95416));
        }

        [Test]
        public void FridayThe13th_Sample()
        {
            var today = new DateTime(2013, 11, 3); // DateTime.Today;

            Func<DateTime, DateTime> nextFridayThe13thSince = day =>
                {
                    IEnumerable<DateTime> future = day.Iterate(x => x.AddDays(1));
                    return future.First(x => x.Day == 13 && x.DayOfWeek == DayOfWeek.Friday);
                };

            Assert.AreEqual(new DateTime(2013, 12, 13), nextFridayThe13thSince(today));
        }

        [Ignore]
        [Test]
        public void Sum1000Primes()
        {
            var primeNumbers = Sieve(Enumerate.From(2));
            var sum = primeNumbers.Take(1000).Sum();

            Assert.AreEqual(3682913, sum);
        }

        private IEnumerable<int> Sieve(IEnumerable<int> list)
        {
            int prime = list.First();
            yield return prime;

            foreach (var other in Sieve(list.Tail().Where(x => x % prime != 0)))
            {
                yield return other;
            }
        }

        [Test]
        public void Rot13()
        {
            const string input = @"How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.";
            const string output = @"Ubj pna lbh gryy na rkgebireg sebz na vagebireg ng AFN? In the elevators, the extrovert looks at the OTHER guy's shoes.";

            var rot = new Func<int, string, string>((degree, src) =>
                {
                    var alphabet = Enumerate.From('a').To('z');
                    var shiftedAlphabet = alphabet.Cycle().Skip(degree).Take(26);

                    var repeatWithUpperCase = new Func<IEnumerable<char>, IEnumerable<char>>(x => x.Concat(x.Select(char.ToUpper)));
                    var transformation = alphabet.Pipe(repeatWithUpperCase)
                                                 .Zip(shiftedAlphabet.Pipe(repeatWithUpperCase))
                                                 .ToDictionary();

                    var result = src.Select(c => transformation.ContainsKey(c) ? transformation[c] : c).BuildString();
                    return result;
                });
            var rot13 = rot.Curry()(13);

            Assert.AreEqual(output, rot13(input));
            Assert.AreEqual(input, rot13(output));
        }

        /// <summary>
        /// Detects UTF-8 BOM of the file
        /// </summary>
        [Test]
        public void UTF8ByteOrderMark()
        {
            // arrange
            var filename = Path.GetFullPath(Path.Combine("..", "..", "Samples.cs"));

            // action
            var hasBom = FileHasUTF8ByteOrderMark(filename);

            // assert
            Assert.IsTrue(hasBom);
        }

        private static bool FileHasUTF8ByteOrderMark(string filename)
        {
            using (var stream = File.OpenRead(filename))
                return stream.EnumerateBuffered(3).StartsWith<byte>(0xEF, 0xBB, 0xBF);
        }

        /// <summary>
        /// Detects non-ASCII characters in the file
        /// </summary>
        [Test]
        public void NotAsciiCharacters()
        {
            var filename = Path.GetFullPath(Path.Combine("..", "..", "Samples.cs"));
            using (var stream = File.OpenRead(filename))
            {
                var nonAsciiCharacters = stream.EnumerateBuffered().Where(x => x > 127).DynamicCast<char>();

                CollectionAssert.AreEqual(new[] { (char) 0xEF, (char) 0xBB, (char) 0xBF }, nonAsciiCharacters.Take(3));
            }
        }

        [Test]
        public void MonteCarloPi()
        {
            var randomGenerator = new Random(666);

            // infinite sequence of random numbers
            var randomNumbers = new Func<double>(randomGenerator.NextDouble).Repeat();

            // infinite sequence of random points
            var randomPoints = randomNumbers.Zip(randomNumbers, (x, y) => new { x, y });

            // infinite sequence of pi estimates with increasing precision
            var piSequence = randomPoints.Scan(
                // n is the number of points used
                // piQuarter is the current estimate for pi/4
                new { n = 0, piQuarter = 0d }, (previous, point) => new {
                    n = previous.n + 1,
                    piQuarter =
                    (
                        previous.piQuarter * previous.n +

                        // if the new point falls into the circle, we add 1, otherwise we add 0
                        (Math.Sqrt(point.x * point.x + point.y * point.y) < 1 ? 1 : 0)

                    ) / (previous.n + 1)
                }).Select(t => t.piQuarter * 4);

            var result = piSequence.ElementAt(10 * 1000 * 1000);
            Assert.IsTrue(Math.Abs(Math.PI - result) < 0.0001);
        }
    }
}