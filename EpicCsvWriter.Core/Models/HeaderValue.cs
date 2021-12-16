using System.Collections.Generic;
using System.Reflection;

namespace EpicCsvWriter.Core.Models {
    public class HeaderValue {
        public string Name { get; init; }
        public int Order { get; init; }
        public bool IsVisible { get; set; }
        public string Format { get; init; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}