using System;
using Xunit;

namespace xUnit.Samples.xUnit
{
    public class AssertionSamples
    {
        [Fact]
        public void Assertion_WithTrueAssumption_Passes()
        {
            Assert.True(true);
        }
        
        
        [Fact]
        public void Assertion_WithFalseAssumption_Fails()
        {
            Assert.False(true);
        }


        [Theory]
        [InlineData(1, 1)]
        public void Assertion_Equals(int a, int b)
        {
            Assert.Equal(a, b);
        }


        [Theory]
        [InlineData(new[] {1, -2, 3})]
        public void Assertion_CheckCollections(int[] values)
        {
            Assert.Contains(values, x => x < 0);
        }


        [Theory]
        [InlineData(null)]
        public void Assertion_ExpectedException(IDisposable parameter)
        {
            Assert.Throws<NullReferenceException>(() => parameter.Dispose());
            Assert.ThrowsAsync<NullReferenceException>(async () => parameter.Dispose());
        }
    }
}