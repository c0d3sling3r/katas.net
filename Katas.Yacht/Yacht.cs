namespace Katas.Yacht;

public class Yacht
{
    private HashSet<Player> _players = new();
    public int PlayersCount => _players.Count;

    public Yacht(Player? firstPlayer)
    {
        if (firstPlayer != null)
            _players.Add(firstPlayer);
    }

    public void AddPlayer(Player player)
    {
        if (PlayersCount < 4)
            _players.Add(player);
    }
}