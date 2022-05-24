using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace Katas.BreadthFirstSearch.Tests;

public class TestRunner
{
    private readonly TreeNode<string> _givenTree;

    public TestRunner()
    {
        _givenTree = new TreeNode<string> {Value = "Frankfurt"};
        TreeNode<string> mannheimNode = new() {Value = "Mannheim"};
        TreeNode<string> karlsruheNode = new() {Value = "Karlsruhe"};
        TreeNode<string> augsburgNode = new() {Value = "Augsburg"};
        TreeNode<string> munchenNode = new() {Value = "Munchen"};
        TreeNode<string> wurzburgNode = new() {Value = "Wurzburg"};
        TreeNode<string> erfurtNode = new() {Value = "Erfurt"};
        TreeNode<string> nurenbergNode = new() {Value = "Nurenberg"};
        TreeNode<string> stuttgartNode = new() {Value = "Stuttgart"};
        TreeNode<string> kasselNode = new() {Value = "Kassel"};

        karlsruheNode.AddAdjacent(augsburgNode);
        nurenbergNode.AddAdjacent(stuttgartNode);
        kasselNode.AddAdjacent(munchenNode);
        mannheimNode.AddAdjacent(karlsruheNode);

        wurzburgNode
            .AddAdjacent(nurenbergNode)
            .AddAdjacent(erfurtNode);

        _givenTree.AddAdjacent(mannheimNode)
            .AddAdjacent(wurzburgNode)
            .AddAdjacent(kasselNode);
    }

    [Fact]
    public void TraverseTreeAndEnqueue_MustNotEnqueueDuplicateValue()
    {
        // Arrange


        // Action
        _givenTree.Search("Kassel");

        // Assertion
        Assert.True(_givenTree.Queue.GroupBy(q => q)
            .Select(q => q.Count())
            .All(c => c.Equals(1)));
    }

    [Fact]
    public void TraverseTreeToFind_MustReturnDesiredNode()
    {
        // Arrange
        string expectedValue = "Nurenberg";
        TreeNode<string> expectedNode = _givenTree.Adjancents[1].Adjancents[0];

        // Action
        TreeNode<string> actualNode = _givenTree.Search(expectedValue);

        // Assertion
        Assert.Equal(expectedNode, actualNode);
    }

    [Fact]
    public void SearchNonExistenceValue_KeyNotFoundExceptionMustBeThrown()
    {
        // Arrange
        string expectedValue = "Tehran";

        // Action
        Action action = () => _givenTree.Search(expectedValue);

        // Assertion
        Assert.Throws<KeyNotFoundException>(action);
    }

    [Fact]
    public void SearchNullTree_NullReferenceExceptionMustBeThrown()
    {
        // Arrange
        TreeNode<string> nullExpectedTree = null;

        // Action
        Action action = () => nullExpectedTree.Search("SomeValue");

        // Assertion
        Assert.Throws<NullReferenceException>(action);
    }
}