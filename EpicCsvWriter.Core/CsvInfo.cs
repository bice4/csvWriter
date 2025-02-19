using System;
using System.Reflection;

namespace EpicCsvWriter.Core;

public readonly struct CsvInfo(string name, int order, PropertyInfo propertyInfo, string format)
    : IComparable<CsvInfo>
{
    public readonly string Name = name;
    private readonly int _order = order;
    public readonly PropertyInfo PropertyInfo = propertyInfo;
    public readonly string Format = format;

    public int CompareTo(CsvInfo other) => _order.CompareTo(other._order);
}