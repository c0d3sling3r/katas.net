using Xunit;

namespace Katas.Yacht.Tests;

public class TestRunner
{
    private readonly Yacht _yacht;
    
    public TestRunner()
    {
        _yacht = new Yacht(new Player());
    }
    
    [Fact]
    public void CreateAGame_MustHaveAtLeastOnePlayer()
    {
        // Arrange
        int playersCount = _yacht.PlayersCount;
        
        // Assertion
        Assert.Equal(1, playersCount);
    }

    [Fact]
    public void AddMoreThanFourPlayers_ExceptionMustBeThrown()
    {
        // Arrange
        Player secondPlayer = new();
        Player thirdPlayer = new();
        Player fourthPlayer = new();
        
        // Action
        _yacht.AddPlayer(secondPlayer);
        _yacht.AddPlayer(thirdPlayer);
        _yacht.AddPlayer(fourthPlayer);
    }
}