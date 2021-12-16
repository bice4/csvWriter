using System;
using System.IO;
using EpicCsvWriter.Core;
using EpicCsvWriter.Core.Models;
using EpicCsvWriter.Playground.Models;

namespace EpicCsvWriter.Playground {
    class Program {
        static void Main(string[] args) {


            var reports = new HistoricalReport[1000];

            for (int i = 0; i < 1000; i++) {
                reports[i] = new HistoricalReport(){
                    capacity = .5d + i,
                    date = DateTime.Now,
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
            var csvWriter = new CsvWriter();

            var d = CsvWriter.WriteCsv(CsvData.CreateCsvData(reports), ";");

            File.WriteAllText("t.txt", d);
        }
    }
}