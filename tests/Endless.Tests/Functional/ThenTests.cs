using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Endless.Functional;
using Xunit;

namespace Endless.Tests.Functional
{
    public class ThenTests
    {
        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void Then()
        {
            Func<int, int> f = x => x * 2;
            Func<int, string> g = x => x.ToString(CultureInfo.InvariantCulture);

            var result = f.Then(g)(10);
            Assert.Equal("20", result);
        }
    }
}