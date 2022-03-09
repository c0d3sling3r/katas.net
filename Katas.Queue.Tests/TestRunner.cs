using Xunit;

namespace Katas.Queue.Tests;

public class TestRunner
{
    private CustomQueue<string> _queue;

    public TestRunner()
    {
        _queue = new CustomQueue<string>();
    }

    [Fact]
    public void CreateQueue_MustBeEmpty()
    {
        // Arrange

        // Action
        _queue = new CustomQueue<string>();

        // Assertion
        Assert.True(_queue.IsEmpty);
    }

    [Fact]
    public void Enqueue_SizeMustBeIncrementedByOne()
    {
        // Arrange
        int beforeSize = _queue.Size;

        // Action
        _queue.Enqueue("A");

        // Assertion
        Assert.Equal(beforeSize + 1, _queue.Size);
    }

    [Theory]
    [InlineData("A")]
    [InlineData("B")]
    [InlineData("C")]
    public void Dequeue_DequeuedElementMustBeReturnedAndSizeMustBeDecrementedByOne(string element)
    {
        // Arrange
        _queue.Enqueue(element);
        int beforeSize = _queue.Size;

        // Action
        string dequeuedElement = _queue.Dequeue();

        // Assertion
        Assert.Equal(element, dequeuedElement);
        Assert.Equal(beforeSize - 1, _queue.Size);
    }
}