using System;

namespace CsvWriter.Core;

[AttributeUsage(AttributeTargets.Property)]
public class CsvFieldAttribute : Attribute {
    public string Format;
    public string Name;
    public int Order;
}