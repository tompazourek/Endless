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
    public class IEnumerableVariationsExtensionsTest
    {
        [Test]
        public void Init()
        {
            // arrange
            var sequence = new[] { 1, 2, 3, 4, 5 };

            // action
            IEnumerable<int> result = sequence.Init();

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, result);
        }

        [Test]
        public void Init_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.Init();

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void Init_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            IEnumerable<int> result = sequence.Init();

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void IsEmpty_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            bool result = sequence.IsEmpty();

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmpty_NotEmpty()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            bool result = sequence.IsEmpty();

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SkipUntil_Any1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.SkipUntil(3);

            // assert
            CollectionAssert.AreEqual(new[] { 3 }, result);
        }

        [Test]
        public void SkipUntil_Any2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.SkipUntil(x => x == 3);

            // assert
            CollectionAssert.AreEqual(new[] { 3 }, result);
        }

        [Test]
        public void SkipUntil_Any3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.SkipUntil(x => true);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result);
        }

        [Test]
        public void SkipUntil_Empty1()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.SkipUntil(5);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SkipUntil_Empty2()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.SkipUntil(x => true);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SkipUntil_Empty3()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.SkipUntil(x => false);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SkipUntil_Empty4()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.SkipUntil((i, x) => false);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SkipUntil_Empty5()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.SkipUntil((i, x) => false);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SkipUntil_None1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.SkipUntil(-1);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SkipUntil_None2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.SkipUntil(x => x == -1);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void SkipUntil_None3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.SkipUntil(x => false);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void Sort()
        {
            // arrange
            var sequence = new[] { 2, 3, 1 };

            // action
            IEnumerable<int> result = sequence.Sort();

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result);
        }

        [Test]
        public void SortDescending()
        {
            // arrange
            var sequence = new[] { 2, 3, 1 };

            // action
            IEnumerable<int> result = sequence.SortDescending();

            // assert
            CollectionAssert.AreEqual(new[] { 3, 2, 1 }, result);
        }

        [Test]
        public void SortDescending_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.SortDescending();

            // assert
            Assert.IsEmpty(result);
        }


        [Test]
        public void SortDescending_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            IEnumerable<int> result = sequence.SortDescending();

            // assert
            CollectionAssert.AreEqual(new[] { 1 }, result);
        }

        [Test]
        public void Sort_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.Sort();

            // assert
            Assert.IsEmpty(result);
        }


        [Test]
        public void Sort_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            IEnumerable<int> result = sequence.Sort();

            // assert
            CollectionAssert.AreEqual(new[] { 1 }, result);
        }

        [Test]
        public void Tail()
        {
            // arrange
            var sequence = new[] { 1, 2, 3, 4, 5 };

            // action
            IEnumerable<int> result = sequence.Tail();

            // assert
            CollectionAssert.AreEqual(new[] { 2, 3, 4, 5 }, result);
        }

        [Test]
        public void Tail_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.Tail();

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void Tail_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            IEnumerable<int> result = sequence.Tail();

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void TakeUntil_Any1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.TakeUntil(3);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2 }, result);
        }

        [Test]
        public void TakeUntil_Any2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.TakeUntil(x => x == 3);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2 }, result);
        }

        [Test]
        public void TakeUntil_Any3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.TakeUntil(x => true);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void TakeUntil_Empty1()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.TakeUntil(5);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void TakeUntil_Empty2()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.TakeUntil(x => true);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void TakeUntil_Empty3()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.TakeUntil(x => false);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void TakeUntil_Empty4()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.TakeUntil((i, x) => false);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void TakeUntil_Empty5()
        {
            // arrange
            var sequence = new int[] { };

            // action
            IEnumerable<int> result = sequence.TakeUntil((i, x) => false);

            // assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void TakeUntil_None1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.TakeUntil(-1);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result);
        }

        [Test]
        public void TakeUntil_None2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.TakeUntil(x => x == -1);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result);
        }

        [Test]
        public void TakeUntil_None3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            IEnumerable<int> result = sequence.TakeUntil(x => false);

            // assert
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result);
        }
    }
}