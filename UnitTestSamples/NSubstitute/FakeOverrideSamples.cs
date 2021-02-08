using System;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.Extensions;
using Xunit;
using xUnit.Samples.NSubstitute.Utils;

namespace xUnit.Samples.NSubstitute
{
    public class FakeOverrideSamples
    {
        [Fact]
        public void NSubstitute_OverridesReturnValue()
        {
            var implementation = Substitute.For<ITestInterface>();

            var r1 = implementation.MethodWithReturnValue();
            
            implementation.Configure()
                .MethodWithReturnValue()
                .Returns(42);

            var r2 = implementation.MethodWithReturnValue();

            Assert.Equal(42, r2);
        }
        
        
        
        [Fact]
        public void NSubstitute_OverridesReturnSequenceOfValues()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.Configure()
                .MethodWithReturnValue()
                .Returns(0, 1, 2, 3);
            
            Assert.Equal(0, implementation.MethodWithReturnValue());
            Assert.Equal(1, implementation.MethodWithReturnValue());
            Assert.Equal(2, implementation.MethodWithReturnValue());
            Assert.Equal(3, implementation.MethodWithReturnValue());
        }
        
        
        
        [Fact]
        public void NSubstitute_ThrowsException()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.Configure()
                .MethodWithReturnValue()
                .Throws(new StackOverflowException());

            Assert.Throws<StackOverflowException>(() => implementation.MethodWithReturnValue());
        }
        
        
        
        [Fact]
        public void NSubstitute_DetectsMethodCall()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.Configure()
                .When(x => x.ParameterlessMethod())
                .Do(c =>
                {
                    //set breakpoint to catch the call
                });

            implementation.ParameterlessMethod();
        }
        


        [Fact]
        public void NSubstitute_OverridesLogic()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.Configure()
                .Append(Arg.Any<string>(), Arg.Any<int>())
                .Returns(callInfo =>
                {
                    var inputString = callInfo.Arg<string>();
                    var inputInt = callInfo.Arg<int>();

                    return $"{inputString} = {inputInt}";
                });

            var result = implementation.Append("Zero", 0);
            
            Assert.Equal("Zero = 0", result);
        }



        [Fact]
        public void NSubstitute_FiltersCallsByArguments()
        {
            var implementation = Substitute.For<ITestInterface>();

            implementation.Configure()
                .Transform(Arg.Any<int>())
                .Returns(1);
            implementation.Configure()
                .Transform(Arg.Is<int>(i => i > 0))
                .Returns(-1);
            implementation.Configure()
                .Transform(42)
                .Returns(0);
            
            Assert.Equal(0, implementation.Transform(42));
            Assert.Equal(-1, implementation.Transform(10));
            Assert.Equal(1, implementation.Transform(-100));
        }
        
        
        
        [Fact]
        public void NSubstitute_WorksWithEvents()
        {
            var implementation = Substitute.For<ITestInterface>();
            var eventHandler = Substitute.For<EventHandler>();
            
            eventHandler.Configure()
                .When(x => x.Invoke(Arg.Any<object>(), Arg.Any<EventArgs>()))
                .Do(c =>
                {
                    //set breakpoint to catch the call
                });

            implementation.SomethingHappened += eventHandler;

            implementation.SomethingHappened += Raise.Event();
        }
    }
}