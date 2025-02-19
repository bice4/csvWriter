using System;
using System.Collections.Generic;
using System.Linq;

namespace EpicCsvWriter.Core;

public sealed class CsvInfoArray(int? initialCapacity = null)
{
    private CsvInfo[] _mArray = new CsvInfo[initialCapacity ?? 4];
    private int _mCount;

    public CsvInfo this[int index] => _mArray[index];

    public IEnumerable<string> GetNames() => _mArray.Select(x => x.Name);

    public int length => _mCount;

    public void Add(CsvInfo element)
    {
        if (_mCount == _mArray.Length)
        {
            Array.Resize(ref _mArray, _mArray.Length * 2);
        }

        _mArray[_mCount++] = element;
    }

    public void Sort()
    {
        Array.Sort(_mArray);
    }
}