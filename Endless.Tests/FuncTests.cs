using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Endless.Functional;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class FuncTests
    {
        [Test]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Compose()
        {
            Func<int, int> f = x => x * 2;
            Func<int, string> g = x => x.ToString(CultureInfo.InvariantCulture);

            var result = Function.Compose(g, f)(10);
            Assert.AreEqual("20", result);
        }
    }
}