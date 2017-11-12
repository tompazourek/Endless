using System.Linq;
using Xunit;

namespace Endless.Tests
{
    public class StringTests
    {
        [Fact]
        public void BuildString()
        {
            // arrange
            var chars = new[] { 'h', 'e', 'l', 'l', 'o' };

            // action
            var result = chars.BuildString();

            // assert
            Assert.Equal("hello", result);
        }

        [Fact]
        public void BuildString_Empty()
        {
            // arrange
            var chars = Enumerable.Empty<char>();

            // action
            var result = chars.BuildString();

            // assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void JoinStrings()
        {
            // arrange
            var strings = new[] { "hello", null, " ", "world", "", "!" };

            // action
            var result = strings.JoinStrings();

            // assert
            Assert.Equal("hello world!", result);
        }

        [Fact]
        public void JoinStrings_Empty()
        {
            // arrange
            var strings = Enumerable.Empty<string>();

            // action
            var result = strings.JoinStrings();

            // assert
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void JoinStrings_Separator()
        {
            // arrange
            var strings = new[] { "abc", null, null, "x", " ", string.Empty, "def" };

            // action
            var result = strings.JoinStrings(",");

            // assert
            Assert.Equal("abc,,,x, ,,def", result);
        }

        [Fact]
        public void JoinStrings_Separator_Empty()
        {
            // arrange
            var strings = Enumerable.Empty<string>();

            // action
            var result = strings.JoinStrings(", ");

            // assert
            Assert.Equal(string.Empty, result);
        }
    }
}