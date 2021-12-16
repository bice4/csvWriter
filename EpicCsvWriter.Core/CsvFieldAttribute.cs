using System;

namespace EpicCsvWriter.Core {
    public class CsvFieldAttribute : Attribute {
        public string Format { get; set; }
        public string Name { get; set; }
        public bool PermissionAccess { get; set; }
        public int Order { get; set; }
    }
}