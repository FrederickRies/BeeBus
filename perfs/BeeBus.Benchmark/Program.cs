using BenchmarkDotNet.Running;

namespace BeeBus.Benchmark
{
    public class Program
    {
        public static void Main(string[] args) => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}