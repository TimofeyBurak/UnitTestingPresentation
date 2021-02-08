using System.Collections.Generic;
using Xunit;

namespace xUnit.Samples.xUnit
{
    [Collection("")]
    public class ExecutionSamples
    {
        [Fact]
        public void Fact_ExecutedOnce()
        {
        }


        
        [Fact(Skip = "Explanation, why is this test is skipped")]
        public void Fact_Skipped()
        {
        }



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Theory_ExecutedForEachSetOfParameters(int parameter)
        {
        }


        
        [Theory(Skip = "Explanation, why is this test is skipped")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Theory_Skipped(int parameter)
        {
        }

        
        
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        public void Theory_MultipleParameters_ExecutedForEachSetOfParameters(int parameter1, int parameter2)
        {
        }
        


        [Theory]
        [MemberData(nameof(StaticParameters))]
        public void Theory_UsesParametersFromStaticProperty(string parameter)
        {
        }

        public static IEnumerable<object[]> StaticParameters { get; } = new List<object[]>
        {
            new object[] {0},
            new object[] {1},
            new object[] {2}
        };


        [Theory]
        [MemberData(nameof(Utils.StaticParameters), MemberType = typeof(Utils))]
        public void Theory_UsesParametersFromAnotherClass(int parameter)
        {
        }


        [Theory]
        [MemberData(nameof(ParametersGenerator), parameters: 3)]
        public void Theory_UsesParametersFromStaticMethod(int parameter)
        {
        }

        public static IEnumerable<object[]> ParametersGenerator(int count)
        {
            var result = new List<object[]>();
            for (var i = 0; i < count; i++)
            {
                result.Add(new object[] { i });
            }

            return result;
        }
    }
}