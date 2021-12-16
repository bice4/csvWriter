using System.Collections.Generic;
using System.Linq;

namespace EpicCsvWriter.Core.Models {
    public class CsvData {
        public Header Header { get; private init; }
        public IEnumerable<List<(string, int)>> Data { get; init; }

        public static CsvData CreateCsvData<T>(IEnumerable<T> typeObject) {
            var header = typeof(T).CreateHeader();
            
            return new CsvData() {
                Header = header,
                Data = typeObject.Select(x => CsvConverter.Convert(x, header: header))
            };
        }
    }
}