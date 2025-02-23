using System;
using System.Globalization;
using System.IO;
using BenchmarkDotNet.Attributes;
using CsvWriter.Benchmarks.Models;

namespace CsvWriter.Benchmarks;

[MemoryDiagnoser]
public class CsvHelperVsCustomBenchmark
{
    [Params(20, 300, 1000, 10_000)] public int N;

    private TestReport[] _customsReports;
    private TestReportHelper[] _helperReports;

    [GlobalSetup]
    public void Setup()
    {
        _customsReports = new TestReport[N];
        var now = DateTime.Now;

        for (var i = 0; i < N; i++)
        {
            _customsReports[i] = new TestReport()
            {
                date = now,
                testDouble = 1.2d * i,
                testId = 200000001 + i,
                name = $"Name{i}"
            };
        }

        _helperReports = new TestReportHelper[N];

        for (var i = 0; i < N; i++)
        {
            _helperReports[i] = new TestReportHelper()
            {
                date = now,
                load = 1.2d * i,
                id = 200000001 + i,
                name = $"Name{i}",
                testDouble = 5.55 + i
            };
        }
    }

    [Benchmark(Baseline = true)]
    public void CsvHelper()
    {
        using var writer = new StreamWriter("csvHelper.csv");
        using var csv = new CsvHelper.CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(_helperReports);
    }

    [Benchmark]
    public void MyCustomCsvWriter()
    {
        using var writer = new StreamWriter("csvCustomWriter2.txt");
        Core.CsvWriter.WriteCsv(writer, _customsReports, ';');
    }
}