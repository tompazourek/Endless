using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;

namespace Endless.Tests
{
    public class EnumerableCustomTest
    {
        [Fact]
        public void Cached()
        {
            // arrange
            var random = new Random(666);
            using (var cached = new Func<int>(random.Next).Repeat().Cached())
            {
                // action
                var sequence1 = cached.Take(10).ToList();
                var sequence2 = cached.Take(10).ToList();

                // assert
                Assert.Equal(sequence1, sequence2);
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        public void Cached_TakeMore()
        {
            // arrange
            var random1 = new Random(666);
            var random2 = new Random(666);
            var uncached = new Func<int>(random2.Next).Repeat();
            using (var cached = new Func<int>(random1.Next).Repeat().Cached())
            {
                // action
                var sequence1 = cached.Take(10).ToList();
                var sequence2 = cached.Take(15).ToList();
                var sequence3 = uncached.Take(15).ToList();

                // assert
                Assert.Equal(sequence3, sequence2);
            }
        }

        [Fact]
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public void Cached_Without()
        {
            // arrange
            var random = new Random(666);
            var uncached = new Func<int>(random.Next).Repeat();

            // action
            var sequence1 = uncached.Take(10).ToList();
            var sequence2 = uncached.Take(10).ToList();

            // assert
            Assert.NotEqual(sequence1, sequence2);
        }

        [Fact]
        public void Chunk()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            var chunks = collection.Chunk(4).ToList();

            // assert
            Assert.Equal(3, chunks.Count);
            Assert.Equal(new[] { 1, 2, 3, 4 }, chunks[0]);
            Assert.Equal(new[] { 5, 6, 7, 8 }, chunks[1]);
            Assert.Equal(new[] { 9, 10 }, chunks[2]);
        }

        [Fact]
        public void Chunk_Empty()
        {
            // arrange
            var collection = Enumerable.Empty<int>();

            // action
            var chunks = collection.Chunk(5).ToList();

            // assert
            Assert.Empty(chunks);
        }

        [Fact]
        public void Chunk_Length0()
        {
            // arrange
            var collection = new[] { 1, 2, 3 };

            // action
            Assert.Throws<ArgumentException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var x = collection.Chunk(0).ToList();
            });
        }

        [Fact]
        public void Chunk_Length1()
        {
            // arrange
            var collection = new[] { 1, 2, 3 };

            // action
            var chunks = collection.Chunk(1).ToList();

            // assert
            Assert.Equal(3, chunks.Count);
            Assert.Equal(new[] { 1 }, chunks[0]);
            Assert.Equal(new[] { 2 }, chunks[1]);
            Assert.Equal(new[] { 3 }, chunks[2]);
        }

        [Fact]
        public void Chunk_LengthGreater()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            var chunks = collection.Chunk(11).ToList();

            // assert
            Assert.Single(chunks);
            Assert.Equal(collection, chunks[0]);
        }

        [Fact]
        public void Chunk_LengthNegative()
        {
            // arrange
            var collection = new[] { 1, 2, 3 };

            // action
            Assert.Throws<ArgumentException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var x = collection.Chunk(-1).ToList();
            });
        }

        [Fact]
        public void Chunk2()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            var chunks = collection.Chunk(5).ToList();

            // assert
            Assert.Equal(2, chunks.Count);
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, chunks[0]);
            Assert.Equal(new[] { 6, 7, 8, 9, 10 }, chunks[1]);
        }

        [Fact]
        public void ChunkBy()
        {
            // arrange
            var list = new[]
            {
                new { Key = "A", Value = "We" },
                new { Key = "A", Value = "Think" },
                new { Key = "A", Value = "That" },
                new { Key = "B", Value = "Linq" },
                new { Key = "C", Value = "Is" },
                new { Key = "A", Value = "Really" },
                new { Key = "B", Value = "Cool" },
                new { Key = "B", Value = "!" }
            };

            // action
            var chunked = list.ChunkBy(p => p.Key).ToList();

            // assert
            Assert.Equal(new[] { "A", "B", "C", "A", "B" }, chunked.Select(x => x.Key));
            Assert.Equal(new[] { "We", "Think", "That" }, chunked.ElementAt(0).Select(x => x.Value));
            Assert.Equal(new[] { "Linq" }, chunked.ElementAt(1).Select(x => x.Value));
            Assert.Equal(new[] { "Is" }, chunked.ElementAt(2).Select(x => x.Value));
            Assert.Equal(new[] { "Really" }, chunked.ElementAt(3).Select(x => x.Value));
            Assert.Equal(new[] { "Cool", "!" }, chunked.ElementAt(4).Select(x => x.Value));
        }

        [Fact]
        public void ChunkBy_Empty()
        {
            // arrange
            var list = new int[] { };

            // action
            var chunked = list.ChunkBy().ToList();

            // assert
            Assert.Empty(chunked);
        }

        [Fact]
        public void ChunkBy_Simple()
        {
            // arrange
            var list = new byte[] { 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1 };

            // action
            var chunked = list.ChunkBy().ToList();

            // assert
            Assert.Equal(6, chunked.Count);
        }

        [Fact]
        public void DynamicCast()
        {
            // arrange
            var input = new[] { (byte)'h', (byte)'e', (byte)'l', (byte)'l', (byte)'o' };
            var expectedOutput = new[] { 'h', 'e', 'l', 'l', 'o' };

            // act
            var output = input.DynamicCast<char>().ToArray();

            // assert
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void DynamicCast_Invalid()
        {
            // arrange
            var input = new[] { "Hello", "world" };

            // act
            Assert.Throws<RuntimeBinderException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var x = input.DynamicCast<char>().ToArray();
            });
        }

        [Fact]
        public void DynamicCast_MultiType()
        {
            // arrange
            var input = new object[] { 'h', 1.5d, new BigInteger(5) };
            var expectedOutput = new[] { 104, 1, 5 };

            // act
            var output = input.DynamicCast<int>().ToArray();

            // assert
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void DynamicCast_WithoutIt()
        {
            // arrange
            var input = new[] { (byte)'h', (byte)'e', (byte)'l', (byte)'l', (byte)'o' };

            // act
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.Throws<InvalidCastException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var x = input.Cast<char>().ToArray();
            });
        }

        [Fact]
        public void Random()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var picks = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                picks.Add(collection.Random());
            }
            var groups = picks.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() });

            // assert
            Assert.Equal(6, groups.Count());
        }

        [Fact]
        public void Random_Empty()
        {
            // arrange
            var collection = Enumerable.Empty<int>();

            // action
            Assert.Throws<InvalidOperationException>(() => collection.Random());
        }

        [Fact]
        public void Random_Predicate()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var picks = new List<int>();
            for (var i = 0; i < 1000; i++)
            {
                picks.Add(collection.Random(x => x % 2 == 0));
            }
            var groups = picks.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).ToList();

            // assert
            Assert.Equal(3, groups.Count);
            Assert.Equal(new[] { 2, 4, 6 }, groups.Select(x => x.Key).OrderBy(x => x));
        }

        [Fact]
        public void Random_Predicate_Empty()
        {
            // arrange
            var collection = Enumerable.Empty<int>();

            // action
            Assert.Throws<InvalidOperationException>(() => collection.Random(x => x % 2 == 0));
        }

        [Fact]
        public void Shuffle()
        {
            // arrange
            var collection = Enumerable.Range(1, 20).ToList();

            // action
            var shuffled = collection.Shuffle().ToList();

            // assert
            Assert.Equal(collection, shuffled.OrderBy(x => x));
            Assert.NotEqual(collection, shuffled);
        }

        [Fact]
        public void Shuffle_Empty()
        {
            // arrange
            var collection = Enumerable.Empty<int>();

            // action
            var shuffled = collection.Shuffle();

            // assert
            Assert.Empty(shuffled);
        }

        [Fact]
        public void StartsWith_Empty1()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            var subsequence = Enumerable.Empty<int>();

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void StartsWith_Empty2()
        {
            // arrange
            var collection = Enumerable.Empty<int>();
            IEnumerable<int> subsequence = new[] { 1, 2, 3, 4, 5 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void StartsWith_False()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 3 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void StartsWith_Longer()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.False(result);
        }

        [Fact]
        public void StartsWith_True()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 2 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.True(result);
        }
    }
}