using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EpicCsvWriter.Core {
    public static class CsvWriter {
        [SuppressMessage("ReSharper.DPA", "DPA0001: Memory allocation issues")]
        public static void WriteCsv<T>(StreamWriter writer, T[] records, string separator)
            where T : class, new() {
            var order = 1;
            var list = new CsvInfoArray();
            var d = 0;
            foreach (var property in typeof(T).GetProperties()
                         .Where(prop => prop.IsDefined(typeof(CsvFieldAttribute), true))) {
                var attr = property.GetCustomAttribute<CsvFieldAttribute>();
                if (!attr.PermissionAccess) continue;

                list.Add(
                    new CsvInfo(
                        String.IsNullOrWhiteSpace(attr.Name) ? property.Name : attr.Name,
                        attr.Order == 0 ? order : attr.Order,
                        property,
                        attr.Format));
                order++;
                d++;
            }

            list.Sort(d);
            writer.WriteLine(String.Join(separator, list.GetNames()));

            for (var i = 0; i < records.Length; i++) {
                for (var index = 0; index < list.Length; index++) {
                    var headerValue = list[index];
                    var value = headerValue.PropertyInfo.GetValue(records[i]);
                    if (value == null) {
                        writer.Write("NULL");
                        continue;
                    }

                    if (headerValue.PropertyInfo.PropertyType == CommonTypes.TypeOfInt) {
                        writer.Write(String.IsNullOrWhiteSpace(headerValue.Format)
                            ? value.ToString()
                            : ((int)value).ToString(headerValue.Format, CultureInfo.CurrentCulture));
                    }
                    else if (headerValue.PropertyInfo.PropertyType == CommonTypes.TypeOfDouble) {
                        writer.Write(String.IsNullOrWhiteSpace(headerValue.Format)
                            ? value.ToString()
                            : ((double)value).ToString(headerValue.Format, CultureInfo.CurrentCulture));
                    }
                    else if (headerValue.PropertyInfo.PropertyType == CommonTypes.TypeOfDateTime) {
                        writer.Write(String.IsNullOrWhiteSpace(headerValue.Format)
                            ? ((DateTime)value).ToString()
                            : ((DateTime)value).ToString(headerValue.Format, CultureInfo.CurrentCulture));
                    }
                    else {
                        writer.Write((string)value);
                    }

                    if (index < list.Length - 1)
                        writer.Write(separator);
                }

                writer.WriteLine();
            }
            //
            // foreach (var @record in records) {
            //   
            // }

            writer.Flush();
        }
    }
}