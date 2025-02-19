using System;

namespace EpicCsvWriter.Core;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class CsvFieldAttribute : Attribute {
    public string Format;
    public string Name;
    public int Order;
}