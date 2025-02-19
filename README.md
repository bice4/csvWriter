# Simple and fast csv writer

| Method         | N     | Mean        | Error     | StdDev    | Ratio | Gen0     | Gen1    | Allocated   | Alloc Ratio |
|--------------- |------ |------------:|----------:|----------:|------:|---------:|--------:|------------:|------------:|
| CsvHelper      | 20    |  3,749.3 us |  43.71 us |  40.89 us |  1.00 |   7.8125 |       - |   227.25 KB |        1.00 |
| EpicCsvWriter2 | 20    |    139.7 us |   2.60 us |   2.43 us |  0.04 |   1.9531 |       - |    33.33 KB |        0.15 |
|                |       |             |           |           |       |          |         |             |             |
| CsvHelper      | 300   |  4,218.0 us |  38.66 us |  34.27 us |  1.00 |  31.2500 | 23.4375 |   505.15 KB |        1.00 |
| EpicCsvWriter2 | 300   |    555.6 us |   6.21 us |   5.50 us |  0.13 |  19.5313 |       - |   311.09 KB |        0.62 |
|                |       |             |           |           |       |          |         |             |             |
| CsvHelper      | 1000  |  5,334.7 us |  40.25 us |  35.68 us |  1.00 |  78.1250 | 62.5000 |  1203.63 KB |        1.00 |
| EpicCsvWriter2 | 1000  |  1,468.5 us |  17.37 us |  15.40 us |  0.28 |  62.5000 |       - |  1009.41 KB |        0.84 |
|                |       |             |           |           |       |          |         |             |             |
| CsvHelper      | 10000 | 21,052.6 us | 191.31 us | 178.95 us |  1.00 | 656.2500 | 31.2500 | 10300.39 KB |        1.00 |
| EpicCsvWriter2 | 10000 | 13,978.4 us | 100.92 us |  94.40 us |  0.66 | 656.2500 |       - | 10106.64 KB |        0.98 |
