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
using System.Text;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class ScanTests
    {
        [Test]
        public void Scan_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;

            // action
            List<int> result = list.Scan(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<int> { 1, 3, 6, 10 }, result);
        }

        [Test]
        public void Scan_Test2()
        {
            // arrange
            var list = new List<float> { 64, 4, 2, 8 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            List<float> result = list.Scan(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 64f, 16f, 8f, 1f }, result);
        }

        [Test]
        public void Scan_Test3()
        {
            // arrange
            var list = new List<float>();
            Func<float, float, float> f = (x, y) => x / y;

            // action
            List<float> result = list.Scan(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float>(), result);
        }

        [Test]
        public void Scan_Test4()
        {
            // arrange
            var list = new List<float> { 10 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            List<float> result = list.Scan(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 10 }, result);
        }

        [Test]
        public void Scan_Seed_Test1()
        {
            // arrange
            var list = new List<int> { 4, 2, 4 };
            Func<float, int, float> f = (x, y) => x / y;
            const int seed = 64;

            // action
            List<float> result = list.Scan(seed, f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 64, 16, 8, 2 }, result);
        }

        [Test]
        public void Scan_Seed_Test2()
        {
            // arrange
            var list = new List<int>();
            Func<float, int, float> f = (x, y) => x / y;
            const int seed = 3;

            // action
            List<float> result = list.Scan(seed, f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 3 }, result);
        }

        [Test]
        public void ScanRight_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;

            // action
            List<int> result = list.ScanRight(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<int> { 10, 9, 7, 4 }, result);
        }

        [Test]
        public void ScanRight_Test2()
        {
            // arrange
            var list = new List<float> { 8, 12, 24, 2 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            List<float> result = list.ScanRight(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 8, 1, 12, 2 }, result);
        }

        [Test]
        public void ScanRight_Test3()
        {
            // arrange
            var list = new List<float> { 12 };
            Func<float, float, float> f = (x, y) => x / y;

            // action
            List<float> result = list.ScanRight(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 12 }, result);
        }

        [Test]
        public void ScanRight_Test4()
        {
            // arrange
            var list = new List<float>();
            Func<float, float, float> f = (x, y) => x / y;

            // action
            List<float> result = list.ScanRight(f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float>(), result);
        }

        [Test]
        public void ScanRight_Seed_Test1()
        {
            // arrange
            var list = new List<int> { 1, 2, 3, 4 };
            Func<int, int, int> f = (x, y) => x + y;
            const int seed = 5;

            // action
            List<int> result = list.ScanRight(seed, f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<int> { 15, 14, 12, 9, 5 }, result);
        }

        [Test]
        public void ScanRight_Seed_Test2()
        {
            // arrange
            var list = new List<int> { 8, 12, 24, 4 };
            Func<int, float, float> f = (x, y) => x / y;
            const float seed = 2f;

            // action
            List<float> result = list.ScanRight(seed, f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 8f, 1f, 12f, 2f, 2f }, result);
        }

        [Test]
        public void ScanRight_Seed_Test3()
        {
            // arrange
            var list = new List<int>();
            Func<int, float, float> f = (x, y) => x / y;
            const float seed = 2f;

            // action
            List<float> result = list.ScanRight(seed, f).ToList();

            // assert
            CollectionAssert.AreEqual(new List<float> { 2f }, result);
        }
    }
}