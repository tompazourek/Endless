using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

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
    }
}