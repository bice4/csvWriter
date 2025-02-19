using EpicCsvWriter.Core;

namespace EpicCsvWriter.Playground.Models;

public class ReportModel {
    [CsvField(Order = 1, Name = "Name")]
    public string Name { get; set; }
    [CsvField(Order = 2, Name = "Type")]
    public int Type { get; set; }
}