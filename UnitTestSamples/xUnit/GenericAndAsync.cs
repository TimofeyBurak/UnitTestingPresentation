using System;
using System.Threading.Tasks;
using Xunit;

namespace xUnit.Samples.xUnit
{
    public class GenericAndAsync
    {
        [Theory]
        [InlineData(0)]
        [InlineData(0.1f)]
        [InlineData("100")]
        [InlineData(new[] {-1})]
        public void GenericUnitTest_UsesTypeOfParameter<T>(T parameter)
        {
            //set breakpoint to see each parameter
        }


        [Fact]
        public async Task AsyncUnitTest_SupportsAsyncOperations()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}