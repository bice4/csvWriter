using System;
using EpicCsvWriter.Core;

namespace EpicCsvWriter.Benchmarks.Models {
    public class HistoricalReportForCustom {
        [CsvField(Order = 1, Name = "Data and time", PermissionAccess = true)]
        public DateTime date { get; set; }

        [CsvField(Order = 2, Format = "X4", PermissionAccess = true)]
        public int resourceId { get; set; }

        [CsvField(Order = 3, PermissionAccess = true)]
        public string resourceName { get; set; }

        [CsvField(Order = 4, PermissionAccess = true)]
        public double load { get; set; }

        [CsvField(Order = 5, PermissionAccess = true)]
        public double readyToStart { get; set; }

        [CsvField(Order = 6, PermissionAccess = true)]
        public double capacity { get; set; }

        [CsvField(Order = 7, PermissionAccess = true)]
        public double spent { get; set; }

        [CsvField(Order = 8, PermissionAccess = true)]
        public double output { get; set; }

        [CsvField(Order = 9, PermissionAccess = true)]
        public double blackSpent { get; set; }

        [CsvField(Order = 10, PermissionAccess = true)]
        public double redSpent { get; set; }

        [CsvField(Order = 11, PermissionAccess = true)]
        public double yellowSpent { get; set; }

        [CsvField(Order = 12, PermissionAccess = true)]
        public double blackOutput { get; set; }

        [CsvField(Order = 13, PermissionAccess = true)]
        public double redOutput { get; set; }

        [CsvField(Order = 14, PermissionAccess = true)]
        public double yellowOutput { get; set; }

        [CsvField(Order = 15, PermissionAccess = true)]
        public double blackLoad { get; set; }

        [CsvField(Order = 16, PermissionAccess = true)]
        public double redLoad { get; set; }

        [CsvField(Order = 17, PermissionAccess = true)]
        public double yellowLoad { get; set; }
    }
}