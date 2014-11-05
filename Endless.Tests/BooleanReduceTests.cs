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
    public class BooleanReduceTests
    {
        [Test]
        public void And_Empty()
        {
            // arrange
            IEnumerable<bool> conditions = Enumerable.Empty<bool>();

            // act
            bool result = conditions.And();

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void And_False()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { true, true, false, true };

            // act
            bool result = conditions.And();

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void And_Lazy_True()
        {
            // arrange
            var funcResults = new[] { true, true, true, true };
            var funcWasCalled = new bool[funcResults.Length];
            List<Func<bool>> predicates = funcResults.Select((_, i) => new Func<bool>(() =>
                {
                    funcWasCalled[i] = true;
                    return funcResults[i];
                })).ToList();

            // act
            bool result = predicates.And();

            // assert
            Assert.IsTrue(result);
            Assert.IsTrue(funcWasCalled[0]);
            Assert.IsTrue(funcWasCalled[1]);
            Assert.IsTrue(funcWasCalled[2]);
            Assert.IsTrue(funcWasCalled[3]);
        }

        [Test]
        public void And_True()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { true, true, true, true };

            // act
            bool result = conditions.And();

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Or_Empty()
        {
            // arrange
            IEnumerable<bool> conditions = Enumerable.Empty<bool>();

            // act
            bool result = conditions.Or();

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Or_False()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { false, false, false, false };

            // act
            bool result = conditions.Or();

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Or_Lazy_True()
        {
            // arrange
            var funcResults = new[] { false, true, true, true };
            var funcWasCalled = new bool[funcResults.Length];
            List<Func<bool>> predicates = funcResults.Select((_, i) => new Func<bool>(() =>
                {
                    funcWasCalled[i] = true;
                    return funcResults[i];
                })).ToList();

            // act
            bool result = predicates.Or();

            // assert
            Assert.IsTrue(result);
            Assert.IsTrue(funcWasCalled[0]);
            Assert.IsTrue(funcWasCalled[1]);
            Assert.IsFalse(funcWasCalled[2]);
            Assert.IsFalse(funcWasCalled[3]);
        }

        [Test]
        public void Or_True()
        {
            // arrange
            IEnumerable<bool> conditions = new[] { false, true, false, true };

            // act
            bool result = conditions.Or();

            // assert
            Assert.IsTrue(result);
        }
    }
}