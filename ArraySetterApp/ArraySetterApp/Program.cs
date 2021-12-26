using BenchmarkDotNet.Running;

namespace ArraySetterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ArraySetter>();
        }
    }
}
