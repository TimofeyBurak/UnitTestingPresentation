using NSubstitute;
using Xunit;
using xUnit.Samples.NSubstitute.Utils;

namespace xUnit.Samples.NSubstitute
{
    public class CallCheckSamples
    {
        [Fact]
        public void NSubstitute_ChecksMethodBeenCalled()
        {
            var implementation = Substitute.For<ITestInterface>();
            
            implementation.ParameterlessMethod();
            
            implementation.Received().ParameterlessMethod();
        }
        
        
        
        [Fact]
        public void NSubstitute_ChecksMethodNotBeenCalled()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.DidNotReceive().ParameterlessMethod();
        }
        
        
        
        [Fact]
        public void NSubstitute_ChecksMethodBeenCalledMultipleTimes()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.ParameterlessMethod();
            implementation.ParameterlessMethod();
            implementation.ParameterlessMethod();
            
            implementation.Received(3).ParameterlessMethod();
        }
        
        
        
        [Fact]
        public void NSubstitute_CallChecksSupportArgumentFilters()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.MethodWithParameter(42);

            implementation.Received().MethodWithParameter(Arg.Any<int>());
            implementation.Received().MethodWithParameter(Arg.Is<int>(i => i > 0));
            implementation.DidNotReceive().MethodWithParameter(0);
        }



        [Fact]
        public void NSubstitute_CanCheckOrderOfCalls()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.MethodWithParameter(42);
            implementation.ParameterlessMethod();
            
            Received.InOrder(() =>
            {
                implementation.ParameterlessMethod();
                implementation.MethodWithParameter(42);
            });
        }
    }
}