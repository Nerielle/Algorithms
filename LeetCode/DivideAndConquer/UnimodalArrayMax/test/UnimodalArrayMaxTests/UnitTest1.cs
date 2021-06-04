using System;
using UnimodalArrayMax;
using Xunit;

namespace UnimodalArrayMaxTests
{
    public class UnitTest1
    {
        [Fact]
        public void OneElementTest()
        {
            var arr = new UnimodalArray(new int[] { 1 });
            Assert.Equal(1, 1);
        }

        [Fact]
        public void EmptyArrayTest()
        {
            var arr = new UnimodalArray(new int[] { });
            Assert.Equal(0, 0);
        }

        [Fact]
        public void TestName()
        {
            var arr = new UnimodalArray(new int[] { 1, 3, 6, 7, 5, 3, 2, 1 });
            Assert.Equal(7, 7);
        }

        [Fact]
        public void Array1Test()
        {
            var arr = new UnimodalArray(new int[] { 8, 10, 20, 80, 100, 200, 400, 500, 3, 2, 1 });
            Assert.Equal(500, 500);
        }

        [Fact]
        public void Array2Test()
        {
            var arr = new UnimodalArray(new int[] { 1, 3, 50, 10, 9, 7, 6 });
            Assert.Equal(50, 50);
        }

        [Fact]
        public void NoDecreasingPartTest()
        {
            var arr = new UnimodalArray(new int[] { 10, 20, 30, 40, 50 });
            Assert.Equal(50, 50);
        }

        [Fact]
        public void NoEncreasingPartTest()
        {
            var arr = new UnimodalArray(new int[] { 120, 100, 80, 20, 0 });
            Assert.Equal(120, 120);
        }

    }


}
