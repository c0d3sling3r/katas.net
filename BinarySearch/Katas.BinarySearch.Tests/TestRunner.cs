using System;
using System.Collections.Generic;

using Xunit;

namespace Katas.BinarySearch.Tests;

public class TestRunner
{
    private readonly TreeNode<int> _givenTree;

    public TestRunner()
    {
        _givenTree = new TreeNode<int>
        {
            Value = 10,
            LeftNode = new TreeNode<int>
            {
                Value = 5,
                LeftNode = new TreeNode<int>
                {
                    Value = 4
                },
                RightNode = new TreeNode<int>
                {
                    Value = 6
                }
            },
            RightNode = new TreeNode<int>
            {
                Value = 16,
                LeftNode = new TreeNode<int>
                {
                    Value = 12
                },
                RightNode = new TreeNode<int>
                {
                    Value = 20
                }
            }
        };
    }

    [Fact]
    public void SearchNullIntegerTree_MustThrowNullReferenceException()
    {
        // Arrange
        const int target = 30;

        // Action
        Searching<int> searching = new(null);
        Action action = () => searching.Search(target);

        // Assertion
        Assert.Throws<NullReferenceException>(action);
    }

    [Fact]
    public void IfSearchTargetEqualsToRoot_MustReturnRoot()
    {
        // Arrange
        const int targetValue = 10;
        TreeNode<int> expectedValue = _givenTree;

        // Action
        Searching<int> searching = new(_givenTree);
        TreeNode<int> actualValue = searching.Search(targetValue);

        // Assertion
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void SearchTargetThroughAllNodes_MustReturnFoundNonRootNode()
    {
        // Arrange
        const int targetValue = 12;
        TreeNode<int> expectedValue = _givenTree.RightNode.LeftNode;

        // Action
        Searching<int> searching = new(_givenTree);
        TreeNode<int> actualValue = searching.Search(targetValue);

        // Assertion
        Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void SearchNonExistedTargetValueThroughNodes_MustThrowKeyNotFoundException()
    {
        // Arrange
        const int targetValue = 30;

        // Action
        Searching<int> searching = new(_givenTree);
        Action action = () => searching.Search(targetValue);

        // Assertion
        Assert.Throws<KeyNotFoundException>(action);
    }
}