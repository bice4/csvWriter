using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EpicCsvWriter.Core {
    public class CsvInfoArray {
        CsvInfo[] m_array;
        int m_count;

        public CsvInfoArray(int? initialCapacity = null) {
            this.m_array = new CsvInfo[initialCapacity ?? 4];
        }
        
        public CsvInfo this[int index] => this.m_array[index];

        public IEnumerable<string> GetNames() => this.m_array.Select(x => x.Name);

        public int Length => this.m_count;

        public void Add(CsvInfo element) {
            if (this.m_count == this.m_array.Length) {
                Array.Resize(ref this.m_array, this.m_array.Length * 2);
            }

            this.m_array[this.m_count++] = element;
        }

        public void Sort(int size) {
            Array.Resize(ref this.m_array, size);
            Array.Sort(this.m_array);
        }
    }
}