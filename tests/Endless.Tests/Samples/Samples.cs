using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public class Samples
    {
        [Fact]
        public void AlternatingDigitSum_Sample()
        {
            IEnumerable<int> digits(int number)
                => Math.Abs(number)
                    .Iterate(x => x / 10)
                    .TakeUntil(0)
                    .Select(x => x % 10)
                    .Reverse();

            IEnumerable<int> alternateSequence(IEnumerable<int> sequence)
                => sequence
                    .Zip(new[] { 1, -1 }.Cycle(), (x, y) => x * y);

            int alternatingDigitSum(int number)
                => alternateSequence(digits(number)).Sum();

            Assert.Equal(0, alternatingDigitSum(0));
            Assert.Equal(1 - 2 + 3, alternatingDigitSum(123));
            Assert.Equal(9 - 5 + 4 - 1 + 6, alternatingDigitSum(95416));
            Assert.Equal(9 - 9 + 0 - 9 + 9, alternatingDigitSum(99099));
            Assert.Equal(9 - 5 + 4 - 1 + 6, alternatingDigitSum(-95416));
        }

        [Fact]
        public void DigitSum_Sample()
        {
            int digitSum(int number)
                => Math.Abs(number)
                    .Iterate(x => x / 10)
                    .TakeUntil(0)
                    .Select(x => x % 10)
                    .Sum();

            Assert.Equal(0, digitSum(0));
            Assert.Equal(1 + 2 + 3, digitSum(123));
            Assert.Equal(9 + 5 + 4 + 1 + 6, digitSum(95416));
            Assert.Equal(9 + 9 + 0 + 9 + 9, digitSum(99099));
            Assert.Equal(9 + 5 + 4 + 1 + 6, digitSum(-95416));
        }

        /// <summary>
        /// Five weekends
        /// The month of October in 2010 has five Fridays, five Saturdays, and five Sundays.
        /// Task:
        /// Write a program to show all months that have this same characteristic of five full weekends from the year 1900 through 2100 (Gregorian calendar).
        /// Show the number of months with this property (there should be 201).
        /// </summary>
        /// <remarks>http://rosettacode.org/wiki/Five_weekends</remarks>
        [Fact]
        public void FiveWeekends_RosettaCode()
        {
            const int startYear = 1900, endYear = 2100;

            var days = new DateTime(startYear, 1, 1).Iterate(x => x.AddDays(1)).TakeWhile(x => x.Year <= endYear);
            var months = days.GroupBy(x => new { x.Year, x.Month });
            var fiveWeekendMonths = months.Where(x =>
                x.Count(y => y.DayOfWeek == DayOfWeek.Friday) == 5 &&
                x.Count(y => y.DayOfWeek == DayOfWeek.Saturday) == 5 &&
                x.Count(y => y.DayOfWeek == DayOfWeek.Sunday) == 5);

            Assert.Equal(201, fiveWeekendMonths.Count());
        }

        [Fact]
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
            Assert.Equal("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, Fizz Buzz, 16, 17, Fizz, 19, Buzz, Fizz, 22, 23, Fizz, Buzz, 26, Fizz, 28, 29, Fizz Buzz, 31, 32, Fizz, 34, Buzz", result);
        }

        [Fact]
        public void FridayThe13th_Sample()
        {
            var today = new DateTime(2013, 11, 3); // DateTime.Today;

            DateTime nextFridayThe13ThSince(DateTime day)
            {
                var future = day.Iterate(x => x.AddDays(1));
                return future.First(x => x.Day == 13 && x.DayOfWeek == DayOfWeek.Friday);
            }

            Assert.Equal(new DateTime(2013, 12, 13), nextFridayThe13ThSince(today));
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
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
                new { n = 0, piQuarter = 0d }, (previous, point) => new
                {
                    n = previous.n + 1,
                    piQuarter =
                    (
                        previous.piQuarter * previous.n +

                        // if the new point falls into the circle, we add 1, otherwise we add 0
                        (Math.Sqrt(point.x * point.x + point.y * point.y) < 1 ? 1 : 0)
                    ) / (previous.n + 1)
                }).Select(t => t.piQuarter * 4);

            var result = piSequence.ElementAt(10 * 1000 * 1000);
            Assert.True(Math.Abs(Math.PI - result) < 0.0001);
        }

        /// <summary>
        /// Detects non-ASCII characters in the file
        /// </summary>
        [Fact]
        public void NotAsciiCharacters()
        {
            var filename = Path.GetFullPath(Path.Combine("..", "..", "..", "Samples", "Samples.cs"));
            using (var stream = File.OpenRead(filename))
            {
                var nonAsciiCharacters = stream.EnumerateBuffered().Where(x => x > 127).DynamicCast<char>();

                Assert.Equal(new[] { (char)0xEF, (char)0xBB, (char)0xBF }, nonAsciiCharacters.Take(3));
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void Rot13()
        {
            const string input = @"How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.";
            const string output = @"Ubj pna lbh gryy na rkgebireg sebz na vagebireg ng AFN? In the elevators, the extrovert looks at the OTHER guy's shoes.";

            string rot(int degree, string src)
            {
                var alphabet = Enumerate.From('a').To('z');
                var shiftedAlphabet = alphabet.Cycle().Skip(degree).Take(alphabet.Count());

                IEnumerable<char> repeatWithUpperCase(IEnumerable<char> x)
                    => x.Concat(x.Select(char.ToUpper));

                var transformation = repeatWithUpperCase(alphabet)
                    .Zip(repeatWithUpperCase(shiftedAlphabet))
                    .ToDictionary();

                var result = src.Select(c => transformation.ContainsKey(c) ? transformation[c] : c).BuildString();
                return result;
            }

            var rot13 = ((Func<int, string, string>)rot).Curry()(13);

            Assert.Equal(output, rot13(input));
            Assert.Equal(input, rot13(output));
        }

        [Fact(Skip = "Takes long to compute.")]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void Sum1000Primes()
        {
            // ReSharper disable once FunctionRecursiveOnAllPaths
            IEnumerable<int> sieve(IEnumerable<int> list)
            {
                var prime = list.First();
                yield return prime;

                foreach (var other in sieve(list.Tail().Where(x => x % prime != 0)))
                {
                    yield return other;
                }
            }

            var primeNumbers = sieve(Enumerate.From(2));
            var sum = primeNumbers.Take(1000).Sum();

            Assert.Equal(3682913, sum);
        }

        /// <summary>
        /// Detects UTF-8 BOM of the file
        /// </summary>
        [Fact]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public void UTF8ByteOrderMark()
        {
            // arrange
            var filename = Path.GetFullPath(Path.Combine("..", "..", "..", "Samples", "Samples.cs"));

            bool FileHasUTF8ByteOrderMark(string x)
            {
                using (var stream = File.OpenRead(x))
                {
                    return stream.EnumerateBuffered(3).StartsWith<byte>(0xEF, 0xBB, 0xBF);
                }
            }

            // action
            var hasBom = FileHasUTF8ByteOrderMark(filename);

            // assert
            Assert.True(hasBom);
        }
    }
}