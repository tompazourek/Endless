using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endless.Func;
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
