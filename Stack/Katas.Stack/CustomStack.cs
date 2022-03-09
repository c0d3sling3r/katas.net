namespace Katas.Stack;

public class CustomStack<T>
{
    private T[] _elements;

    public bool IsEmpty => Size == 0;

    public int Size { get; private set; }

    public CustomStack()
    {
        _elements = new T[0];
    }

    public void Push(T element)
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

    public T Pop()
    {
        int popElementIndex = --Size;
        T element = _elements[popElementIndex];

        T[] newElements = new T[Size];
        
        for (int i = 0; i < Size; i++)
        {
            newElements[i] = _elements[i];
        }

        _elements = newElements;

        return element;
    }

    public T Peek()
    {
        int lastElementIndex = Size - 1;
        T element = _elements[lastElementIndex];

        return element;
    }
}