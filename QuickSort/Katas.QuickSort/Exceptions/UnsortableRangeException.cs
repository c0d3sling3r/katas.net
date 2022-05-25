namespace Katas.QuickSort.Exceptions;

public class UnsortableRangeException : Exception
{
    public UnsortableRangeException() : base("The target range's length must be 2 or more.")
    {
    }
}