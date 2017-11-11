using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
    [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
    public class AggregateTests
    {
        [Test]
        public void Aggregate_Seed_Test1()
        {
            // arrange
            var list = new List<int> { 4, 2, 4 };
            Func<float, int, float> f = (x, y) => x / y;
            const int seed = 64;

            // action
            var result = list.Aggregate(seed, f);

            // assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Aggregate_Seed_Test2()
        {
            // arrange
            var list = new List<int>();
            Func<float, int, float> f = (x, y) => x / y;
            const int seed = 3;

            // action
            var result = list.Aggregate(seed, f);

            // assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Aggregate_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;

            // action
            var result = list.Aggregate(f);

            // assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Aggregate_Test2()
        {
            // arrange
            var list = new List<float> { 64, 4, 2, 8 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.Aggregate(f);

            // assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Aggregate_Test3()
        {
            // arrange
            var list = new List<float>();
            Func<float, float, float> f = (x, y) => x / y;

            // action
            Assert.Catch<InvalidOperationException>(() => list.Aggregate(f));
        }

        [Test]
        public void Aggregate_Test4()
        {
            // arrange
            var list = new List<float> { 10 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.Aggregate(f);

            // assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void AggregateRight_Seed_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;
            const int seed = 5;

            // action
            var result = list.AggregateRight(seed, f);

            // assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void AggregateRight_Seed_Test2()
        {
            // arrange
            var list = new List<int> { 8, 12, 24, 4 };
            Func<int, float, float> f = (x, y) => x / y;
            const float seed = 2f;

            // action
            var result = list.AggregateRight(seed, f);

            // assert
            Assert.AreEqual(8f, result);
        }

        [Test]
        public void AggregateRight_Seed_Test3()
        {
            // arrange
            var list = new List<int>();
            Func<int, float, float> f = (x, y) => x / y;
            const float seed = 2f;

            // action
            var result = list.AggregateRight(seed, f);

            // assert
            Assert.AreEqual(2f, result);
        }

        [Test]
        public void AggregateRight_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;

            // action
            var result = list.AggregateRight(f);

            // assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void AggregateRight_Test2()
        {
            // arrange
            var list = new List<float> { 8, 12, 24, 2 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.AggregateRight(f);

            // assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void AggregateRight_Test3()
        {
            // arrange
            var list = new List<float> { 12 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.AggregateRight(f);

            // assert
            Assert.AreEqual(12, result);
        }

        [Test]
        public void AggregateRight_Test4()
        {
            // arrange
            var list = new List<float>();
            Func<float, float, float> f = (x, y) => x / y;

            // action
            Assert.Catch<InvalidOperationException>(() => list.AggregateRight(f));
        }
    }
}