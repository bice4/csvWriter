using System;
using System.Diagnostics;
using System.IO;
using EpicCsvWriter.Core;
using EpicCsvWriter.Playground.Models;

namespace EpicCsvWriter.Playground {
    class Program {
        static void Main(string[] args) {
            var N = 5000;
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
            }

            var sw = new Stopwatch();
            sw.Start();
            using var writer = new StreamWriter("t.txt");
            CsvWriter.WriteCsv(writer, reports, ";");
            sw.Stop();
            Console.WriteLine($"Elapsed: {sw.Elapsed.ToString()}");
            Console.ReadLine();
        }
    }
}