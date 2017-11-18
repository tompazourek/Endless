using System;
using System.Collections;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
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
            Assert.Single((IEnumerable)chunks);
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
    }
}