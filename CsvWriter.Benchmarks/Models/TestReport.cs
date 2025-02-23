using System;
using CsvWriter.Core;

namespace CsvWriter.Benchmarks.Models;

public class TestReport
{
    [CsvField(Order = 1, Name = "Data and time", Format = "mm:dd:yyyy")]
    public DateTime date { get; set; }

    [CsvField(Order = 2, Format = "X4")] public int testId { get; set; }

    [CsvField(Order = 3)] public string name { get; set; }

    [CsvField(Order = 4)] public double testDouble { get; set; }
    
}