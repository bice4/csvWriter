using System.Collections.Generic;

namespace EpicCsvWriter.Core.Models {
    public class Header {
        public Dictionary<int, HeaderValue> HeaderValues { get; }

        public Header(Dictionary<int, HeaderValue> headerValues) {
            this.HeaderValues = headerValues;
        }
    }
}