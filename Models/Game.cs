public class Game
{
    public string homeTeam { get; set; }
    public string awayTeam { get; set; }
    public int homeTeamScore { get; set; }
    public int awayTeamScore { get; set; }
}
public class GameData
{
    public string Title { get; set; }
    public List<Game> Games { get; set; }
}