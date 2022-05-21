namespace Katas.BinarySearch;

public class Searching<T> where T : IComparable, IComparable<T>, IEquatable<T>, IConvertible
{
    private readonly TreeNode<T> _givenTree;

    public Searching(TreeNode<T> givenTree)
    {
        _givenTree = givenTree;
    }

    public TreeNode<T> Search(T targetValue)
    {
        if (_givenTree == null)
            throw new NullReferenceException("The given tree is null; So the search operation would not be done.");

        TreeNode<T> result = _seekAndFindTargetNode(_givenTree, targetValue);

        if (result == null)
            throw new KeyNotFoundException("The desired key was not found in the given tree.");

        return result;
    }

    private TreeNode<T> _matchTargetNodeValue(TreeNode<T> targetNode, T targetValue)
    {
        TreeNode<T> foundNode = null;
        
        if (targetNode.Value.Equals(targetValue))
        {
            foundNode = targetNode;
        }

        return foundNode;
    }

    private TreeNode<T> _seekAndFindTargetNode(TreeNode<T> searchNode, T targetValue)
    {
        TreeNode<T> result = _matchTargetNodeValue(searchNode, targetValue);

        if (result != null)
            return result;

        if (searchNode.HasRightNode() && targetValue.CompareTo(searchNode.Value) > 0)
        {
            result = _seekAndFindTargetNode(searchNode.RightNode, targetValue);
        }

        if (searchNode.HasLeftNode() && targetValue.CompareTo(searchNode.Value) <= 0)
        {
            result = _seekAndFindTargetNode(searchNode.LeftNode, targetValue);
        }

        return result;
    }
}