using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Endless.Functional;
using Xunit;

namespace Endless.Tests
{
    public class FuncTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Compose()
        {
            Func<int, int> f = x => x * 2;
            Func<int, string> g = x => x.ToString(CultureInfo.InvariantCulture);

            var result = Function.Compose(g, f)(10);
            Assert.Equal("20", result);
        }
    }
}