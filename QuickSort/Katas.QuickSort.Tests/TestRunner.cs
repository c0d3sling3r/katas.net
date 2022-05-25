using System;
using System.Collections.Generic;
using System.Linq;

using Katas.QuickSort.Exceptions;
using Katas.QuickSort.Extensions;

using Xunit;

namespace Katas.QuickSort.Tests;

public class TestRunner
{
    [Fact]
    public void PassLessThanTwoSizedRange_UnsortableRangeExceptionMustBeThrown()
    {
        // Arrange
        int[] expectedRange = {1};

        // Action
        Action action = () => expectedRange.QuickSort();

        // Assertion
        Assert.Throws<UnsortableRangeException>(action);
    }

    [Fact]
    public void SortRange_ResultMustBeSorted()
    {
        // Arrange
        int[] targetRange = _getRandomValues();
        List<int> targetList = targetRange.ToList();
        targetList.Sort();
        int[] expectedResult = targetList.ToArray();

        // Action
        int[] actualResult = targetRange.QuickSort()?.ToArray()!;

        // Assertion
        Assert.Equal(expectedResult, actualResult);
    }

    private int[] _getRandomValues()
    {
        Random random = new(DateTime.UnixEpoch.Millisecond);

        int rangeSize = random.Next(2, 1000);
        int[] values = new int[rangeSize];

        for (int i = 0; i < rangeSize; i++)
            values[i] = random.Next(-1000, 1000);

        return values;
    }
}