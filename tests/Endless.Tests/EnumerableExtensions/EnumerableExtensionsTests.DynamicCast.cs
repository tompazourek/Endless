using System;
using System.Linq;
using System.Numerics;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;

namespace Endless.Tests
{
    public partial class EnumerableExtensionsTests
    {
        [Fact]
        public void DynamicCast()
        {
            // arrange
            var input = new[] { (byte)'h', (byte)'e', (byte)'l', (byte)'l', (byte)'o' };
            var expectedOutput = new[] { 'h', 'e', 'l', 'l', 'o' };

            // act
            var output = input.DynamicCast<char>().ToArray();

            // assert
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void DynamicCast_Invalid()
        {
            // arrange
            var input = new[] { "Hello", "world" };

            // act
            Assert.Throws<RuntimeBinderException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var x = input.DynamicCast<char>().ToArray();
            });
        }

        [Fact]
        public void DynamicCast_MultiType()
        {
            // arrange
            var input = new object[] { 'h', 1.5d, new BigInteger(5) };
            var expectedOutput = new[] { 104, 1, 5 };

            // act
            var output = input.DynamicCast<int>().ToArray();

            // assert
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void DynamicCast_WithoutIt()
        {
            // arrange
            var input = new[] { (byte)'h', (byte)'e', (byte)'l', (byte)'l', (byte)'o' };

            // act
            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.Throws<InvalidCastException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var x = input.Cast<char>().ToArray();
            });
        }
    }
}