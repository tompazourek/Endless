using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.CSharp.RuntimeBinder;
using System.Numerics;

namespace Endless.Tests
{
    [TestFixture]
    public class EnumerableCustomTest
    {
        [Test]
        public void Chunk()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            List<IEnumerable<int>> chunks = collection.Chunk(4).ToList();

            // assert
            Assert.AreEqual(3, chunks.Count());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, chunks[0]);
            CollectionAssert.AreEqual(new[] { 5, 6, 7, 8 }, chunks[1]);
            CollectionAssert.AreEqual(new[] { 9, 10 }, chunks[2]);
        }

        [Test]
        public void Chunk2()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            List<IEnumerable<int>> chunks = collection.Chunk(5).ToList();

            // assert
            Assert.AreEqual(2, chunks.Count());
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, chunks[0]);
            CollectionAssert.AreEqual(new[] { 6, 7, 8, 9, 10 }, chunks[1]);
        }

        [Test]
        public void Chunk_Empty()
        {
            // arrange
            IEnumerable<int> collection = Enumerable.Empty<int>();

            // action
            List<IEnumerable<int>> chunks = collection.Chunk(5).ToList();

            // assert
            CollectionAssert.IsEmpty(chunks);
        }

        [Test]
        public void Chunk_Length0()
        {
            // arrange
            var collection = new[] { 1, 2, 3 };

            // action
            Assert.Throws<ArgumentException>(() => collection.Chunk(0).ToList());
        }

        [Test]
        public void Chunk_Length1()
        {
            // arrange
            var collection = new[] { 1, 2, 3 };

            // action
            List<IEnumerable<int>> chunks = collection.Chunk(1).ToList();

            // assert
            Assert.AreEqual(3, chunks.Count());
            CollectionAssert.AreEqual(new[] { 1 }, chunks[0]);
            CollectionAssert.AreEqual(new[] { 2 }, chunks[1]);
            CollectionAssert.AreEqual(new[] { 3 }, chunks[2]);
        }

        [Test]
        public void Chunk_LengthGreater()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            List<IEnumerable<int>> chunks = collection.Chunk(11).ToList();

            // assert
            Assert.AreEqual(1, chunks.Count());
            CollectionAssert.AreEqual(collection, chunks[0]);
        }

        [Test]
        public void Chunk_LengthNegative()
        {
            // arrange
            var collection = new[] { 1, 2, 3 };

            // action
            Assert.Throws<ArgumentException>(() => collection.Chunk(-1).ToList());
        }

        [Test]
        public void Random()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var picks = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                picks.Add(collection.Random());
            }
            var groups = picks.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() });

            // assert
            Assert.AreEqual(6, groups.Count());
        }

        [Test]
        public void Random_Empty()
        {
            // arrange
            IEnumerable<int> collection = Enumerable.Empty<int>();

            // action
            Assert.Throws<InvalidOperationException>(() => collection.Random());
        }

        [Test]
        public void Random_Predicate()
        {
            // arrange
            var collection = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var picks = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                picks.Add(collection.Random(x => x % 2 == 0));
            }
            var groups = picks.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).ToList();

            // assert
            Assert.AreEqual(3, groups.Count());
            CollectionAssert.AreEquivalent(new[] { 2, 4, 6 }, groups.Select(x => x.Key));
        }

        [Test]
        public void Random_Predicate_Empty()
        {
            // arrange
            IEnumerable<int> collection = Enumerable.Empty<int>();

            // action
            Assert.Throws<InvalidOperationException>(() => collection.Random(x => x % 2 == 0));
        }

        [Test]
        public void Shuffle()
        {
            // arrange
            List<int> collection = Enumerable.Range(1, 20).ToList();

            // action
            List<int> shuffled = collection.Shuffle().ToList();

            // assert
            CollectionAssert.AreEquivalent(collection, shuffled);
            CollectionAssert.AreNotEqual(collection, shuffled);
        }

        [Test]
        public void Shuffle_Empty()
        {
            // arrange
            IEnumerable<int> collection = Enumerable.Empty<int>();

            // action
            IEnumerable<int> shuffled = collection.Shuffle();

            // assert
            CollectionAssert.IsEmpty(shuffled);
        }

        [Test]
        public void StartsWith_Empty1()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = Enumerable.Empty<int>();

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void StartsWith_Empty2()
        {
            // arrange
            IEnumerable<int> collection = Enumerable.Empty<int>();
            IEnumerable<int> subsequence = new[] { 1, 2, 3, 4, 5 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void StartsWith_True()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 2 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void StartsWith_False()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 3 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void StartsWith_Longer()
        {
            // arrange
            IEnumerable<int> collection = new[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> subsequence = new[] { 1, 2, 3, 4, 5, 6 };

            // action
            var result = collection.StartsWith(subsequence);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Cached_Without()
        {
            // arrange
            var random = new Random(666);
            var uncached = new Func<int>(random.Next).Repeat();

            // action
            var sequence1 = uncached.Take(10).ToList();
            var sequence2 = uncached.Take(10).ToList();

            // assert
            CollectionAssert.AreNotEqual(sequence1, sequence2);
        }

        [Test]
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
                CollectionAssert.AreEqual(sequence1, sequence2);
            }
        }

        [Test]
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
                CollectionAssert.AreEqual(sequence3, sequence2);
            }
        }

        [Test]
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
            CollectionAssert.AreEqual(new[] { "A", "B", "C", "A", "B" }, chunked.Select(x => x.Key));
            CollectionAssert.AreEqual(new[] { "We", "Think", "That" }, chunked.ElementAt(0).Select(x => x.Value));
            CollectionAssert.AreEqual(new[] { "Linq" }, chunked.ElementAt(1).Select(x => x.Value));
            CollectionAssert.AreEqual(new[] { "Is" }, chunked.ElementAt(2).Select(x => x.Value));
            CollectionAssert.AreEqual(new[] { "Really" }, chunked.ElementAt(3).Select(x => x.Value));
            CollectionAssert.AreEqual(new[] { "Cool", "!" }, chunked.ElementAt(4).Select(x => x.Value));
        }

        [Test]
        public void ChunkBy_Empty()
        {
            // arrange
            var list = new int[] { };

            // action
            var chunked = list.ChunkBy().ToList();

            // assert
            CollectionAssert.IsEmpty(chunked);
        }

        [Test]
        public void ChunkBy_Simple()
        {
            // arrange
            var list = new byte[] { 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1 };

            // action
            var chunked = list.ChunkBy().ToList();

            // assert
            Assert.AreEqual(6, chunked.Count);
        }

        [Test]
        public void DynamicCast_WithoutIt()
        {
            // arrange
            var input = new[] { (byte)'h', (byte)'e', (byte)'l', (byte)'l', (byte)'o' };

            // act
            Assert.Throws<InvalidCastException>(() => input.Cast<char>().ToArray());
        }

        [Test]
        public void DynamicCast()
        {
            // arrange
            var input = new[] { (byte)'h', (byte)'e', (byte)'l', (byte)'l', (byte)'o' };
            var expectedOutput = new[] { 'h', 'e', 'l', 'l', 'o' };

            // act
            var output = input.DynamicCast<char>().ToArray();

            // assert
            CollectionAssert.AreEqual(expectedOutput, output);
        }

        [Test]
        public void DynamicCast_Invalid()
        {
            // arrange
            var input = new[] { "Hello", "world" };

            // act
            Assert.Throws<RuntimeBinderException>(() => input.DynamicCast<char>().ToArray());
        }

        [Test]
        public void DynamicCast_MultiType()
        {
            // arrange
            var input = new object[] { 'h', 1.5d, new BigInteger(5)};
            var expectedOutput = new[] { 104, 1, 5 };

            // act
            var output = input.DynamicCast<int>().ToArray();

            // assert
            CollectionAssert.AreEqual(expectedOutput, output);
        }
    }
}