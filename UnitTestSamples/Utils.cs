using System.Collections.Generic;

namespace xUnit.Samples
{
    public static class Utils
    {
        public static IEnumerable<object[]> StaticParameters
        {
            get
            {
                yield return new object[] {0};
                yield return new object[] {1};
                yield return new object[] {2};
            }
        }
    }
}