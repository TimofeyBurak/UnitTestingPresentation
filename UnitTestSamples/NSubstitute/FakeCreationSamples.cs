using System;
using NSubstitute;
using Xunit;
using xUnit.Samples.NSubstitute.Utils;

namespace xUnit.Samples.NSubstitute
{
    public class FakeCreationSamples
    {
        [Fact]
        public void NSubstitute_CreatesInterfaceImplementation()
        {
            var implementation = Substitute.For<ITestInterface>();
            
            implementation.ParameterlessMethod();

            Assert.IsAssignableFrom<ITestInterface>(implementation);
        }



        [Fact]
        public void NSubstitute_CreatesImplementationForMultipleInterfaces()
        {
            var implemetation = Substitute.For(
                new[] {typeof(ITestInterface), typeof(IDisposable)}, 
                null);

            Assert.IsAssignableFrom<ITestInterface>(implemetation);
            Assert.IsAssignableFrom<IDisposable>(implemetation);
        }
        
        

        [Fact]
        public void NSubstitute_CreatesDelegate()
        {
            var action = Substitute.For<Action<int>>();
            
            action.Invoke(1);
            action(1);
            
            Assert.IsType<Action>(action);
        }
        
        

        [Fact]
        public void NSubstitute_CreatesAbstractClass()
        {
            var abstractClass = Substitute.For<AbstractClass>();

            abstractClass.DoSomething();
            
            Assert.IsAssignableFrom<AbstractClass>(abstractClass);
        }
    }
}