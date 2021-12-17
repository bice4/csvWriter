using System;
using System.Collections.Generic;
using System.Reflection;

namespace EpicCsvWriter.Core {
    public readonly struct CsvInfo : IComparable<CsvInfo> {
        public readonly string Name;
        public readonly int _order;
        public readonly PropertyInfo PropertyInfo;
        public readonly string Format;

        public CsvInfo(string name, int order, PropertyInfo propertyInfo, string format) {
            this.Name = name;
            this._order = order;
            this.PropertyInfo = propertyInfo;
            this.Format = format;
        }

        public int CompareTo(CsvInfo other) {
            return this._order.CompareTo(other._order);
        }
    }
}