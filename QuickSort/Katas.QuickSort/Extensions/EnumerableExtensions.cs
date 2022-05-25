namespace Katas.QuickSort.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T>? QuickSort<T>(this IEnumerable<T> range) where T : struct, IEquatable<T>, IComparable, IComparable<T>, IConvertible
    {
        IEnumerable<T>? sortedRange = null;
        
        QuickSortProcessor<T> processor = new(range);

        sortedRange = processor.Sort();

        return sortedRange;
    }
}