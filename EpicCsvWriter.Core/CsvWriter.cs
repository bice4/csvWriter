using System;
using System.Linq;
using System.Text;
using EpicCsvWriter.Core.Models;

namespace EpicCsvWriter.Core {
    public class CsvWriter {
        public static string WriteCsv(CsvData data, string separator) {
            var sb = new StringBuilder();

            sb.AppendLine(String.Join(separator, data.Header.HeaderValues.Values.OrderBy(x => x.Order).Select(x => x.Name)));

            foreach (var row in data.Data) {
                sb.AppendLine(String.Join(separator, row.OrderBy(x => x.Item2).Select(x => x.Item1)));
            }


            return sb.ToString();
        }
    }
}