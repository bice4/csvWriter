using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CsvWriter.Core;

public static class CsvWriter
{
    public static void WriteCsv<T>(StreamWriter writer, T[] records, char separator)
        where T : class, new()
    {
        var order = 1;

        var properties = typeof(T).GetProperties()
            .Where(prop => prop.IsDefined(typeof(CsvFieldAttribute), true))
            .ToArray();
        var list = new CsvInfoArray(properties.Length);

        foreach (var property in properties)
        {
            var attr = property.GetCustomAttribute<CsvFieldAttribute>();
            list.Add(
                new CsvInfo(
                    string.IsNullOrWhiteSpace(attr.Name) ? property.Name : attr.Name,
                    attr.Order == 0 ? order : attr.Order,
                    property,
                    attr.Format));
            order++;
        }

        list.Sort();

        writer.WriteLine(string.Join(separator, list.GetNames()));

        ref var start = ref MemoryMarshal.GetArrayDataReference(records);
        ref var end = ref Unsafe.Add(ref start, records.Length);

        var propCount = list.length;

        while (Unsafe.IsAddressLessThan(ref start, ref end))
        {
            for (var index = 0; index < propCount; index++)
            {
                var headerValue = list[index];
                var value = headerValue.PropertyInfo.GetValue(start);
                if (value == null)
                {
                    writer.Write("NULL");
                    continue;
                }

                if (headerValue.PropertyInfo.PropertyType == CommonTypes.TypeOfInt)
                {
                    writer.Write(string.IsNullOrWhiteSpace(headerValue.Format)
                        ? value.ToString()
                        : ((int)value).ToString(headerValue.Format, CultureInfo.CurrentCulture));
                }
                else if (headerValue.PropertyInfo.PropertyType == CommonTypes.TypeOfDouble)
                {
                    writer.Write(string.IsNullOrWhiteSpace(headerValue.Format)
                        ? value.ToString()
                        : ((double)value).ToString(headerValue.Format, CultureInfo.CurrentCulture));
                }
                else if (headerValue.PropertyInfo.PropertyType == CommonTypes.TypeOfDateTime)
                {
                    writer.Write(string.IsNullOrWhiteSpace(headerValue.Format)
                        ? ((DateTime)value).ToString(CultureInfo.CurrentCulture)
                        : ((DateTime)value).ToString(headerValue.Format, CultureInfo.CurrentCulture));
                }
                else if (headerValue.PropertyInfo.PropertyType == CommonTypes.TypeOfBoolean)
                {
                    writer.Write((bool)value ? "true" : "false");
                }
                else
                {
                    writer.Write((string)value);
                }

                if (index < propCount - 1)
                    writer.Write(separator);
            }

            writer.WriteLine();

            start = ref Unsafe.Add(ref start, 1);
        }

        writer.Flush();
    }
}