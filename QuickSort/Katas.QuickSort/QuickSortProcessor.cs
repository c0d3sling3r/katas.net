using Katas.QuickSort.Exceptions;

namespace Katas.QuickSort;
internal class QuickSortProcessor<T> where T : struct, IComparable, IComparable<T>, IEquatable<T>, IConvertible
{
    private readonly T[] _rangeArray;

    internal QuickSortProcessor(IEnumerable<T> range)
    {
        _rangeArray = range.ToArray();
    }
    
    internal IEnumerable<T> Sort()
    {
        if (_rangeArray.Length < 2)
            throw new UnsortableRangeException();
        
        _sort(0, _rangeArray.Length - 1);

        return _rangeArray;
    }

    private void _sort(int partitionStartIndex, int partitionEndIndex)
    {
        if (partitionStartIndex >= partitionEndIndex || partitionStartIndex < 0)
            return;
        
        int pivotIndex = _partition(partitionStartIndex, partitionEndIndex);
        
        // Sort left side of pivot
        if (!pivotIndex.Equals(partitionStartIndex))
            _sort(partitionStartIndex, pivotIndex - 1);
        
        if (!pivotIndex.Equals(partitionEndIndex))
            _sort(pivotIndex + 1, partitionEndIndex);
    }

    private int _partition(int partitionStartIndex, int partitionEndIndex)
    {
        T pivot = _rangeArray.ElementAt(partitionEndIndex);

        int i = partitionStartIndex - 1;
        int j = partitionStartIndex;
        
        while (j < partitionEndIndex)
        {
            if (_rangeArray[j].CompareTo(pivot) <= 0)
            {
                i++;
                _swap(i, j);
            }

            j++;
        }

        i++;
        _swap(i, partitionEndIndex);

        return i;
    }

    private void _swap(int a, int b)
    {
        T aValue = _rangeArray.ElementAt(a);
        T bValue = _rangeArray.ElementAt(b);

        _rangeArray[a] = bValue;
        _rangeArray[b] = aValue;
    }
}
