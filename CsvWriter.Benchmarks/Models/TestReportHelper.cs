using System;
using CsvHelper.Configuration.Attributes;

namespace CsvWriter.Benchmarks.Models;

public class TestReportHelper {
    [Index(0)]
    [Name("Date and time")]
    [Format("mm:dd:yyyy")]
    public DateTime date { get; set; }

    [Index(2)]
    public int id { get; set; }

    [Index(1)]
    public string name { get; set; }

    [Index(3)]
    public double load { get; set; }

    [Index(4)]
    public double testDouble { get; set; }
    
}