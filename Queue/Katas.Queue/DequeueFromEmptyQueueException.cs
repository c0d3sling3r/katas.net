namespace Katas.Queue;

public class DequeueFromEmptyQueueException : Exception
{
    public DequeueFromEmptyQueueException() : base("Cannot dequeue from an empty queue.")
    {
    }
}