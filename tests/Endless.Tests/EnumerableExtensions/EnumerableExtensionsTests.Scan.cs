using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Scan_Seed_Test1()
        {
            // arrange
            var list = new List<int> { 4, 2, 4 };
            Func<float, int, float> f = (x, y) => x / y;
            const int seed = 64;

            // action
            var result = list.Scan(seed, f).ToList();

            // assert
            Assert.Equal(new List<float> { 64, 16, 8, 2 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Scan_Seed_Test2()
        {
            // arrange
            var list = new List<int>();
            Func<float, int, float> f = (x, y) => x / y;
            const int seed = 3;

            // action
            var result = list.Scan(seed, f).ToList();

            // assert
            Assert.Equal(new List<float> { 3 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Scan_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;

            // action
            var result = list.Scan(f).ToList();

            // assert
            Assert.Equal(new List<int> { 1, 3, 6, 10 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Scan_Test2()
        {
            // arrange
            var list = new List<float> { 64, 4, 2, 8 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.Scan(f).ToList();

            // assert
            Assert.Equal(new List<float> { 64f, 16f, 8f, 1f }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Scan_Test3()
        {
            // arrange
            var list = new List<float>();
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.Scan(f).ToList();

            // assert
            Assert.Equal(new List<float>(), result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Scan_Test4()
        {
            // arrange
            var list = new List<float> { 10 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.Scan(f).ToList();

            // assert
            Assert.Equal(new List<float> { 10 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void ScanRight_Seed_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;
            const int seed = 5;

            // action
            var result = list.ScanRight(seed, f).ToList();

            // assert
            Assert.Equal(new List<int> { 15, 14, 12, 9, 5 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void ScanRight_Seed_Test2()
        {
            // arrange
            var list = new List<int> { 8, 12, 24, 4 };
            Func<int, float, float> f = (x, y) => x / y;
            const float seed = 2f;

            // action
            var result = list.ScanRight(seed, f).ToList();

            // assert
            Assert.Equal(new List<float> { 8f, 1f, 12f, 2f, 2f }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void ScanRight_Seed_Test3()
        {
            // arrange
            var list = new List<int>();
            Func<int, float, float> f = (x, y) => x / y;
            const float seed = 2f;

            // action
            var result = list.ScanRight(seed, f).ToList();

            // assert
            Assert.Equal(new List<float> { 2f }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void ScanRight_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;

            // action
            var result = list.ScanRight(f).ToList();

            // assert
            Assert.Equal(new List<int> { 10, 9, 7, 4 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void ScanRight_Test2()
        {
            // arrange
            var list = new List<float> { 8, 12, 24, 2 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.ScanRight(f).ToList();

            // assert
            Assert.Equal(new List<float> { 8, 1, 12, 2 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void ScanRight_Test3()
        {
            // arrange
            var list = new List<float> { 12 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.ScanRight(f).ToList();

            // assert
            Assert.Equal(new List<float> { 12 }, result);
        }

        [Fact]
        [SuppressMessage("ReSharper", "CollectionNeverUpdated.Local")]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void ScanRight_Test4()
        {
            // arrange
            var list = new List<float>();
            Func<float, float, float> f = (x, y) => x / y;

            // action
            var result = list.ScanRight(f).ToList();

            // assert
            Assert.Equal(new List<float>(), result);
        }
    }
}