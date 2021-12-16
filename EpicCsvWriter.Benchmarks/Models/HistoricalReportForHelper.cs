using System;
using CsvHelper.Configuration.Attributes;
using EpicCsvWriter.Core;

namespace EpicCsvWriter.Benchmarks.Models {
    public class HistoricalReportForHelper {
        [Index(0)]
        [Name("Date and time")]
        [Format("mm:dd:yyyy")]
        public DateTime date { get; set; }

        [Index(2)]
        public int resourceId { get; set; }

        [Index(1)]
        public string resourceName { get; set; }

        [Index(3)]
        public double load { get; set; }

        [Index(4)]
        public double readyToStart { get; set; }

        [Index(5)]
        public double capacity { get; set; }

        [Index(6)]
        public double spent { get; set; }

        [Index(7)]
        public double output { get; set; }

        [Index(8)]
        public double blackSpent { get; set; }

        [Index(9)]
        public double redSpent { get; set; }

        [Index(10)]
        public double yellowSpent { get; set; }

        [Index(11)]
        public double blackOutput { get; set; }

        [Index(12)]
        public double redOutput { get; set; }

        [Index(13)]
        public double yellowOutput { get; set; }

        [Index(14)]
        public double blackLoad { get; set; }

        [Index(15)]
        public double redLoad { get; set; }

        [Index(16)]
        public double yellowLoad { get; set; }
    }
}