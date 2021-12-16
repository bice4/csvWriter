using System;
using BenchmarkDotNet.Running;

namespace EpicCsvWriter.Benchmarks {
    class Program {
        static void Main(string[] args) {
            var summary = BenchmarkRunner.Run<CsvHelperVsCustomBenchmark>();

            Console.WriteLine("Benchmark finished. Press <Enter> to exit...");
            Console.ReadLine();
        }
    }
}