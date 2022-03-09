namespace Katas.Queue;

public class CustomQueue<T>
{
    private T[] _elements;
    public bool IsEmpty => Size == 0;
    public int Size { get; private set; }

    public CustomQueue()
    {
        _elements = Array.Empty<T>();
    }


    public void Enqueue(T element)
    {
        ++Size;

        T[] newElements = new T[Size];

        for (int i = 0; i < Size; i++)
        {
            if (i != Size - 1)
                newElements[i] = _elements[i];
        }

        newElements[Size - 1] = element;

        _elements = newElements;
    }

    public T Dequeue()
    {
        --Size;

        T dequeuedElement = _elements[0];

        T[] newElements = new T[Size];

        for (int i = 1; i < Size; i++)
        {
            newElements[i] = _elements[i];
        }

        _elements = newElements;

        return dequeuedElement;
    }
}