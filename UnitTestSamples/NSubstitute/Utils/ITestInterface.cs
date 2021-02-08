using System;

namespace xUnit.Samples.NSubstitute.Utils
{
    public interface ITestInterface
    {
        int MethodWithReturnValue();
        void ParameterlessMethod();
        void MethodWithParameter(int value);

        int Transform(int x);
        string Append(string a, int b);

        event EventHandler SomethingHappened;
    }
}