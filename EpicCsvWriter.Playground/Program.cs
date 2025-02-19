using System;
using System.Diagnostics;
using System.IO;
using EpicCsvWriter.Core;
using EpicCsvWriter.Playground.Models;

namespace EpicCsvWriter.Playground;

class Program {
    static void Main(string[] args) {
        var N = 100;
        var reports = new HistoricalReport[N];
        var now = DateTime.Now;
        for (int i = 0; i < N; i++) {
            reports[i] = new HistoricalReport() {
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
            // reports[i] = new ReportModel() {
            //     Name = $"Name{i.ToString()}",
            //     Type = i
            // };
        }

        var sw = new Stopwatch();
        sw.Start();
        using var writer = new StreamWriter("t.txt");
        CsvWriter.WriteCsv(writer, reports, ';');
        sw.Stop();
        Console.WriteLine($"Elapsed: {sw.Elapsed.ToString()}");
        Console.ReadLine();
    }
}

/* Original
 *| Method         | N     | Mean        | Error     | StdDev    | Gen0     | Gen1    | Allocated   |
|--------------- |------ |------------:|----------:|----------:|---------:|--------:|------------:|
| CsvHelper      | 20    |  4,124.9 us |  81.09 us | 146.23 us |   7.8125 |       - |   227.31 KB |
| EpicCsvWriter2 | 20    |    155.1 us |   3.06 us |   4.29 us |   1.9531 |       - |    36.39 KB |
| CsvHelper      | 300   |  4,379.0 us |  86.21 us | 126.37 us |  31.2500 | 23.4375 |   505.15 KB |
| EpicCsvWriter2 | 300   |    612.5 us |  12.19 us |  15.42 us |  19.5313 |       - |   318.53 KB |
| CsvHelper      | 1000  |  5,536.6 us | 110.21 us | 135.34 us |  78.1250 | 62.5000 |  1203.46 KB |
| EpicCsvWriter2 | 1000  |  1,600.5 us |  31.17 us |  50.34 us |  66.4063 |       - |  1027.81 KB |
| CsvHelper      | 10000 | 21,407.7 us | 397.98 us | 717.64 us | 656.2500 | 31.2500 | 10300.31 KB |
| EpicCsvWriter2 | 10000 | 15,082.1 us | 301.42 us | 309.54 us | 656.2500 |       - | 10265.92 KB |

 * 
 */