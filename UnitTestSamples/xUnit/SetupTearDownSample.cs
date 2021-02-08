using System;
using Xunit;

namespace xUnit.Samples.xUnit
{
    public class SetupTearDownSample : IDisposable
    {
        private readonly Object _testObject;
        
        public SetupTearDownSample()
        {
            // Setup before each test
            _testObject = new object();
        }
        
        [Fact]
        public void Fact1_ExecutedOnce()
        {
            //use _testObject
        }
        
        [Fact]
        public void Fact2_ExecutedOnce()
        {
            //use _testObject
        }

        public void Dispose()
        {
            // TearDown after each test
        }
    }
}