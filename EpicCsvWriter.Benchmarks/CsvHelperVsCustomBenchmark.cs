using System;
using System.Globalization;
using System.IO;
using BenchmarkDotNet.Attributes;
using EpicCsvWriter.Benchmarks.Models;
using EpicCsvWriter.Core;
using CsvWriter = CsvHelper.CsvWriter;

namespace EpicCsvWriter.Benchmarks {
    [MemoryDiagnoser]
    public class CsvHelperVsCustomBenchmark {
        [Params(20, 300, 1000, 10000)] public int N;

        private HistoricalReportForCustom[] _customsReports;
        private HistoricalReportForHelper[] _helperReports;

        [GlobalSetup]
        public void Setup() {
            this._customsReports = new HistoricalReportForCustom[this.N];
            var now = DateTime.Now;

            for (var i = 0; i < this.N; i++) {
                this._customsReports[i] = new HistoricalReportForCustom() {
                    capacity = .5d + i,
                    date = now,
                    load = 1.2d * i,
                    output = 5.3d + i + i,
                    spent = 3.66 + 2 * i,
                    blackLoad = 8.65 + i,
                    blackOutput = 7.14 + i,
                    blackSpent = 99.36 + i,
                    redLoad = 9.52 + i,
                    redOutput = 2.74 + i,
                    redSpent = 5.25 + i,
                    resourceId = 200000001 + i,
                    resourceName = $"Name{i}",
                    yellowLoad = 4.125 + i,
                    yellowOutput = 5.366 + i,
                    yellowSpent = 8.36 + i,
                    readyToStart = 5.55 + i
                };
            }

            this._helperReports = new HistoricalReportForHelper[this.N];
            
            for (var i = 0; i < this.N; i++) {
                this._helperReports[i] = new HistoricalReportForHelper() {
                    capacity = .5d + i,
                    date = now,
                    load = 1.2d * i,
                    output = 5.3d + i + i,
                    spent = 3.66 + 2 * i,
                    blackLoad = 8.65 + i,
                    blackOutput = 7.14 + i,
                    blackSpent = 99.36 + i,
                    redLoad = 9.52 + i,
                    redOutput = 2.74 + i,
                    redSpent = 5.25 + i,
                    resourceId = 200000001 + i,
                    resourceName = $"Name{i}",
                    yellowLoad = 4.125 + i,
                    yellowOutput = 5.366 + i,
                    yellowSpent = 8.36 + i,
                    readyToStart = 5.55 + i
                };
            }
        }

        [Benchmark]
        public void CsvHelper() {
            using var writer = new StreamWriter("csvHelper.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(this._helperReports);
        }

        [Benchmark]
        public void EpicCsvWriter2() {
            using var writer = new StreamWriter("csvCustomWriter2.txt");
            Core.CsvWriter.WriteCsv(writer, this._customsReports, ";");
        }
        
    }
}