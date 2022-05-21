using Xunit;

namespace Katas.Parity.Tests;

public class TestRunner
{
    [Theory]
    [InlineData("even", 0)]
    [InlineData("even", 0, -1, -5)]
    [InlineData("odd", 2, 5, 34, 6)]
    [InlineData("odd", 3, 2, 8)]
    public void PassMultipleNumbers_ParityMustBeCalculatedCorrectly(string expectedParity, params int[] numbers)
    {
        // Arrange

        // Action
        string actualParity = ParityHelper.DetermineArraySum(numbers);

        // Assertion
        Assert.Equal(expectedParity, actualParity);
    }
}