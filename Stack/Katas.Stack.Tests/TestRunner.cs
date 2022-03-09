using Xunit;

namespace Katas.Stack.Tests;

public class TestRunner
{
    private readonly Stack _stack;
    
    public TestRunner()
    {
        _stack = new Stack();
    }
    
    [Fact]
    public void CreateStack_ShouldBeEmpty()
    {
        // Assertion
        Assert.True(_stack.IsEmpty);
    }

    [Fact]
    public void PushToEmptyStack_SizeMustChangedToOne()
    {
        // Action
        _stack.Push("first");
        
        // Assertion
        Assert.Equal(1, _stack.Size);
    }

    [Fact]
    public void PopFromOneSizeStack_SizeMustChangedToZero()
    {
        // Arrange
        _stack.Push("first");
        
        // Action
        object poppedObject = _stack.Pop();
        
        // Assertion
        Assert.Equal("first", poppedObject);
        Assert.Equal(0, _stack.Size);
    }

    [Fact]
    public void Peek_MustReturnTheLastOneButBNotRemovingIt()
    {
        // Arrange
        _stack.Push("first");
        _stack.Push("second");
        _stack.Push("third");
        
        // Action
        object peekedOne = _stack.Peek();
        
        // Assertion
        Assert.Equal("third", peekedOne);
        Assert.Equal(3, _stack.Size);
    }

    [Fact]
    public void PeekTwice_MustTwoResultsBeTheSame()
    {
        // Arrange
        _stack.Push("first");
        _stack.Push("second");
        _stack.Push("third");
        
        // Action
        object peekedOne = _stack.Peek();
        object peekedTwo = _stack.Peek();
        
        // Assertion
        Assert.Equal(peekedOne, peekedTwo);
    }

    [Fact]
    public void PushOncePopTwice_ExceptionMustBeThrown()
    {
        // Action
        _stack.Push("first");

        Action poppingAction = () =>
        {
            object _ = _stack.Pop();
            object __ = _stack.Pop();
        };

        // Assertion
        Assert.Throws<IndexOutOfRangeException>(poppingAction);
    }
}