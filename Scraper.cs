using HtmlAgilityPack;


static public class Scraper
{
    static public GameData Start()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("https://www.basketball-reference.com/boxscores/");
        List<Game> games = new List<Game>();

        var title = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/h1").First().InnerText;
        var awayTeams = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[1]/a");
        var homeTeams = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[2]/td[1]/a");
        var homeTeamScores = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[2]/td[2]");
        var awayTeamScores =  document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[2]");

        if (homeTeams != null)
        {             
            for (int i = 0; i < awayTeams.Count; i++)
            {
                Game game = new Game{
                    homeTeam = homeTeams[i].InnerText.Trim(),
                    awayTeam = awayTeams[i].InnerText.Trim(),
                    homeTeamScore = int.Parse(homeTeamScores[i].InnerText.Trim()),
                    awayTeamScore = int.Parse(awayTeamScores[i].InnerText.Trim())};
                
                games.Add(game);
            }
        }
        else
        {
            Console.WriteLine("No teams found.");
        }
        return new GameData { Title = title, Games = games };
    }
}
