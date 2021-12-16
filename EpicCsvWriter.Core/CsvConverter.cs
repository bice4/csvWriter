using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using EpicCsvWriter.Core.Models;

namespace EpicCsvWriter.Core {
    public static class CsvConverter {
        public static List<(string, int)>  Convert<T>(T typeObject, Header header) {
            var data = new List<(string, int)>(header.HeaderValues.Count);

            foreach (var headerValue in header.HeaderValues.Values) {
                var value = headerValue.PropertyInfo.GetValue(typeObject);
                
                if (headerValue.PropertyInfo.PropertyType == typeof(int)) {
                    data.Add(String.IsNullOrWhiteSpace(headerValue.Format)
                        ? (((int)value).ToString(CultureInfo.CurrentCulture), headerValue.Order)
                        : (((int)value).ToString(headerValue.Format, CultureInfo.CurrentCulture), headerValue.Order));
                }
                else if (headerValue.PropertyInfo.PropertyType == typeof(double)) {
                    data.Add(String.IsNullOrWhiteSpace(headerValue.Format)
                        ? (((double)value).ToString(CultureInfo.CurrentCulture), headerValue.Order)
                        : (((double)value).ToString(headerValue.Format, CultureInfo.CurrentCulture), headerValue.Order));
                }
                else if (headerValue.PropertyInfo.PropertyType == typeof(DateTime)) {
                    data.Add(String.IsNullOrWhiteSpace(headerValue.Format)
                        ? (((DateTime)value).ToString(CultureInfo.CurrentCulture), headerValue.Order)
                        : (((DateTime)value).ToString(headerValue.Format, CultureInfo.CurrentCulture), headerValue.Order));                }
                else {
                    data.Add(((string)value, headerValue.Order));
                }
            }

            return data;
        }
        
        public static Header CreateHeader(this Type type) {
            var headerValues = new Dictionary<int, HeaderValue>();
            var order = 1;

            foreach (var property in type.GetProperties().Where(prop => prop.IsDefined(typeof(CsvFieldAttribute), true))) {
                var attr = property.GetCustomAttributes(typeof(CsvFieldAttribute), true).First() as CsvFieldAttribute;
                if (!attr!.PermissionAccess) continue;
                var hashCode = property.GetHashCode();
                headerValues.Add(hashCode, new HeaderValue() {
                    Format = attr.Format,
                    Name = String.IsNullOrWhiteSpace(attr.Name) ? property.Name : attr.Name,
                    IsVisible = attr.PermissionAccess,
                    Order = attr.Order == 0 ? order : attr.Order,
                    PropertyInfo = property
                });
                order++;
            }

            return new Header(headerValues);
        }

        public static string DEFAULT_INT_FORMAT = "G";
        public static string DEFAULT_DATETIME_FORMAT = "dd:mm:yyyy";
        
    }
}