namespace Katas.BreadthFirstSearch;

public class TreeNode<T> where T : IComparable, IComparable<T>, IEquatable<T>, IConvertible
{
    public TreeNode<T>[] Adjancents { get; private set; } = Array.Empty<TreeNode<T>>();
    public T Value { get; set; }
    public Queue<TreeNode<T>> Queue { get; } = new();
    public bool IsExplored { get; set; }

    public TreeNode<T> AddAdjacent(TreeNode<T> adjacentNode)
    {
        Adjancents = Adjancents.Append(adjacentNode).ToArray();
        return this;
    }

    public TreeNode<T>? Search(T searchValue)
    {
        TreeNode<T>? result = null;
        TreeNode<T> root = this;
        
        root.IsExplored = true;
        Queue.Enqueue(root);

        while (Queue.Any())
        {
            TreeNode<T> node = Queue.Dequeue();

            if (node.Value.Equals(searchValue))
                result = node;
            
            if (node.Adjancents.Any())
                foreach (TreeNode<T> adjacentNode in node.Adjancents)
                {
                    if (adjacentNode.IsExplored == false)
                    {
                        adjacentNode.IsExplored = true;
                        Queue.Enqueue(adjacentNode);
                    }
                }
        }

        if (result == null)
            throw new KeyNotFoundException("The desired value was not found in the given tree.");

        return result;
    }
}