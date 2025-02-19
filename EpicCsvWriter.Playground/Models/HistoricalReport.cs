using System;
using EpicCsvWriter.Core;

namespace EpicCsvWriter.Playground.Models;

public class HistoricalReport
{
    [CsvField(Order = 1, Format = "MM:dd:yyyy", Name = "Date")]
    public DateTime date { get; set; }

    [CsvField(Order = 5, Format = "X4")] public int resourceId { get; set; }

    [CsvField(Order = 3)] public string resourceName { get; set; }

    [CsvField(Order = 4)] public double load { get; set; }

    [CsvField(Order = 2)] public double readyToStart { get; set; }

    [CsvField(Order = 6)] public double capacity { get; set; }

    [CsvField(Order = 7)] public double spent { get; set; }

    [CsvField(Order = 8)] public double output { get; set; }

    [CsvField(Order = 9)] public double blackSpent { get; set; }

    [CsvField(Order = 10)] public double redSpent { get; set; }

    [CsvField(Order = 11)] public double yellowSpent { get; set; }

    [CsvField(Order = 12)] public double blackOutput { get; set; }

    [CsvField(Order = 13)] public double redOutput { get; set; }

    [CsvField(Order = 14)] public double yellowOutput { get; set; }

    [CsvField(Order = 15)] public double blackLoad { get; set; }

    [CsvField(Order = 16)] public double redLoad { get; set; }

    [CsvField(Order = 17)] public double yellowLoad { get; set; }
}