namespace Katas.BinarySearch;

public class TreeNode<T> where T : IComparable, IComparable<T>, IEquatable<T>, IConvertible
{
    public T Value { get; set; }
    public TreeNode<T> LeftNode { get; set; }
    public TreeNode<T> RightNode { get; set; }

    public bool HasRightNode() => RightNode != null;
    public bool HasLeftNode() => LeftNode != null;
}