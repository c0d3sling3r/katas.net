using System.Linq.Expressions;

namespace Katas.Stack;

public class Stack
{
    private object[] _elements;

    public bool IsEmpty => Size == 0;

    public int Size { get; private set; }

    public Stack()
    {
        _elements = new object[0];
    }

    public void Push(object element)
    {
        Array.Resize(ref _elements, ++Size);
        _elements[Size - 1] = element;
    }

    public object Pop()
    {
        int popElementIndex = --Size;
        object element = _elements[popElementIndex];

        object[] newElements = new object[Size];
        
        for (int i = 0; i < Size; i++)
        {
            newElements[i] = _elements[i];
        }

        _elements = newElements;

        return element;
    }

    public object Peek()
    {
        int lastElementIndex = Size - 1;
        object element = _elements[lastElementIndex];

        return element;
    }
}