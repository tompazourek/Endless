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
using System.Globalization;
using System.Linq;
using System.Text;
using Endless.Functional;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class FuncTests
    {
        [Test]
        public void Compose()
        {
            Func<int, int> f = x => x * 2;
            Func<int, string> g = x => x.ToString(CultureInfo.InvariantCulture);

            var result = Function.Compose(g, f)(10);
            Assert.AreEqual("20", result);
        }
    }
}