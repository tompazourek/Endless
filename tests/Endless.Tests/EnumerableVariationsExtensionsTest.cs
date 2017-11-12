using System.Collections.Generic;
using Xunit;

namespace Endless.Tests
{
    public class EnumerableVariationsExtensionsTest
    {
        [Fact]
        public void IndexOf_Exists1()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(1);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void IndexOf_Exists2()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(3);

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_Exists3()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3, 1, 2, 3 };

            // action
            var result = sequence.IndexOf(3);

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void IndexOf_NotExists1()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(4);

            // assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void IndexOf_NotExists2()
        {
            // arrange
            IEnumerable<int> sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.IndexOf(0);

            // assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Init()
        {
            // arrange
            var sequence = new[] { 1, 2, 3, 4, 5 };

            // action
            var result = sequence.Init();

            // assert
            Assert.Equal(new[] { 1, 2, 3, 4 }, result);
        }

        [Fact]
        public void Init_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.Init();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void Init_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.Init();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void IsEmpty_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.IsEmpty();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmpty_NotEmpty()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.IsEmpty();

            // assert
            Assert.False(result);
        }

        [Fact]
        public void SkipUntil_Any1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(3);

            // assert
            Assert.Equal(new[] { 3 }, result);
        }

        [Fact]
        public void SkipUntil_Any2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => x == 3);

            // assert
            Assert.Equal(new[] { 3 }, result);
        }

        [Fact]
        public void SkipUntil_Any3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => true);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void SkipUntil_Empty1()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil(5);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty2()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil(x => true);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty3()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil(x => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty4()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_Empty5()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SkipUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_None1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(-1);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_None2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => x == -1);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void SkipUntil_None3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.SkipUntil(x => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void Sort()
        {
            // arrange
            var sequence = new[] { 2, 3, 1 };

            // action
            var result = sequence.Sort();

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void Sort_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.Sort();

            // assert
            Assert.Empty(result);
        }


        [Fact]
        public void Sort_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.Sort();

            // assert
            Assert.Equal(new[] { 1 }, result);
        }

        [Fact]
        public void SortDescending()
        {
            // arrange
            var sequence = new[] { 2, 3, 1 };

            // action
            var result = sequence.SortDescending();

            // assert
            Assert.Equal(new[] { 3, 2, 1 }, result);
        }

        [Fact]
        public void SortDescending_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.SortDescending();

            // assert
            Assert.Empty(result);
        }


        [Fact]
        public void SortDescending_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.SortDescending();

            // assert
            Assert.Equal(new[] { 1 }, result);
        }

        [Fact]
        public void Tail()
        {
            // arrange
            var sequence = new[] { 1, 2, 3, 4, 5 };

            // action
            var result = sequence.Tail();

            // assert
            Assert.Equal(new[] { 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void Tail_Empty()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.Tail();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void Tail_One()
        {
            // arrange
            var sequence = new[] { 1 };

            // action
            var result = sequence.Tail();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Any1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(3);

            // assert
            Assert.Equal(new[] { 1, 2 }, result);
        }

        [Fact]
        public void TakeUntil_Any2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => x == 3);

            // assert
            Assert.Equal(new[] { 1, 2 }, result);
        }

        [Fact]
        public void TakeUntil_Any3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => true);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty1()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil(5);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty2()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil(x => true);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty3()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil(x => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty4()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_Empty5()
        {
            // arrange
            var sequence = new int[] { };

            // action
            var result = sequence.TakeUntil((i, x) => false);

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public void TakeUntil_None1()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(-1);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void TakeUntil_None2()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => x == -1);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void TakeUntil_None3()
        {
            // arrange
            var sequence = new[] { 1, 2, 3 };

            // action
            var result = sequence.TakeUntil(x => false);

            // assert
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }
    }
}