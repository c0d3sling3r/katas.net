using Xunit;

namespace Katas.Stack.Tests;

public class TestRunner
{
    private readonly CustomStack<string> _stack;
    
    public TestRunner()
    {
        _stack = new CustomStack<string>();
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

    [Theory]
    [InlineData("C", 3, "A", "B", "C" )]
    [InlineData("B", 2, "A", "B" )]
    [InlineData("D", 4, "A", "B", "C", "D" )]
    public void Peek_MustReturnTheLastOneButBNotRemovingIt(string expectedPeekedOne, int expectedSize, params string[] elements)
    {
        // Arrange
        foreach (string element in elements)
            _stack.Push(element);

        // Action
        object peekedOne = _stack.Peek();
        
        // Assertion
        Assert.Equal(expectedPeekedOne, peekedOne);
        Assert.Equal(expectedSize, _stack.Size);
    }

    [Theory]
    [InlineData("A", "B", "C")]
    [InlineData("A", "B")]
    [InlineData("A", "B", "C", "D")]
    public void PeekTwice_MustTwoResultsBeTheSame(params string[] elements)
    {
        // Arrange
        foreach (string element in elements)
            _stack.Push(element);
        
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