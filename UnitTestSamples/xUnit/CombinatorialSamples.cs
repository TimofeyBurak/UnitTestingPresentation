using Xunit;

namespace xUnit.Samples.xUnit
{
    public class CombinatorialSamples
    {
        [Theory]
        [CombinatorialData]
        public void CombinatorialData_WithProvidedValues_ExecutedForEachCombination(
            [CombinatorialValues(1, 2, 3)] int p1,
            [CombinatorialValues(99, 100)] int p2)
        {
        }

        [Theory]
        [CombinatorialData]
        public void CombinatorialData_WithProvidedRanges_ExecutedForEachCombination(
            [CombinatorialRange(1, 2)] int p1,
            [CombinatorialRange(0, 100, 50)] int p2)
        {
        }

        [Theory]
        [PairwiseData]
        public void PairwiseData_WithProvidedValues_ExecutedForEachPairwiseCombination(
            [CombinatorialValues(1, 2, 3)] int p1,
            [CombinatorialValues(99, 100)] int p2,
            [CombinatorialValues(-1, 0, 1)] int p3)
        {
        }

        [Theory]
        [PairwiseData]
        public void PairwiseData_WithProvidedRanges_ExecutedForEachPairwiseCombination(
            [CombinatorialRange(1, 3)] int p1,
            [CombinatorialRange(0, 100, 50)] int p2,
            [CombinatorialRange(-1, 1, 1)] int p3)
        {
        }
    }
}