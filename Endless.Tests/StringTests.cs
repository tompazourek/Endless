using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Endless.Tests
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void BuildString()
        {
            // arrange
            var chars = new[] { 'h', 'e', 'l', 'l', 'o' };

            // action
            var result = chars.BuildString();

            // assert
            Assert.AreEqual("hello", result);
        }

        [Test]
        public void BuildString_Empty()
        {
            // arrange
            var chars = Enumerable.Empty<char>();

            // action
            var result = chars.BuildString();

            // assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void JoinStrings()
        {
            // arrange
            var strings = new[] { "hello", null, " ", "world", "", "!" };

            // action
            var result = strings.JoinStrings();

            // assert
            Assert.AreEqual("hello world!", result);
        }

        [Test]
        public void JoinStrings_Empty()
        {
            // arrange
            var strings = Enumerable.Empty<string>();

            // action
            var result = strings.JoinStrings();

            // assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void JoinStrings_Separator()
        {
            // arrange
            var strings = new[] { "abc", null, null, "x", " ", string.Empty, "def" };

            // action
            var result = strings.JoinStrings(",");

            // assert
            Assert.AreEqual("abc,,,x, ,,def", result);
        }

        [Test]
        public void JoinStrings_Separator_Empty()
        {
            // arrange
            var strings = Enumerable.Empty<string>();

            // action
            var result = strings.JoinStrings(", ");

            // assert
            Assert.AreEqual(string.Empty, result);
        }
    }
}
