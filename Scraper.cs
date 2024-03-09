using HtmlAgilityPack;

static public class Scraper
{
    static public void Start()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("https://www.basketball-reference.com/boxscores/");

        var title = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/h1").First().InnerText;
        var awayTeams = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[1]/a");
        var homeTeams = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[2]/td[1]/a");
        var homeTeamScores = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[2]");
        var awayTeamScores =  document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[2]/td[2]");

        Console.WriteLine(title);
        if (awayTeamScores != null)
        {
            foreach (var teamNode in homeTeamScores)
            {
                Console.WriteLine(teamNode.InnerText.Trim());
            }
        }
        else
        {
            Console.WriteLine("No away teams found.");
        }

        if (homeTeamScores != null)
        {
            foreach (var teamNode in homeTeamScores)
            {
                Console.WriteLine(teamNode.InnerText.Trim());
            }
        }
        else
        {
            Console.WriteLine("No away teams found.");
        }
    }
}

// Away teams:
//*[@id=\"content\"\]/div[3]/div/table[1]/tbody/tr[1]/td[1]/a
//*[@id=\"content\"]/div[3]/div[2]/table[1]/tbody/tr[1]/td[1]/a  
//*[@id=\"content\"]/div[3]/div[3]/table[1]/tbody/tr[1]/td[1]/a

// Home teams:
//*[@id=\"content\"]/div[3]/div[1]/table[1]/tbody/tr[2]/td[1]/a 
//*[@id=\"content\"]/div[3]/div[2]/table[1]/tbody/tr[2]/td[1]/a
//*[@id=\"content\"]/div[3]/div[3]/table[1]/tbody/tr[2]/td[1]/a

// Away scores:
// *[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[2]
//*[@id=\"content\"]/div[3]/div[2]/table[1]/tbody/tr[1]/td[2]
//*[@id="content"]/div[3]/div[4]/table[1]/tbody/tr[1]/td[2]

//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[2]

// Home scores:
//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[2]/td[2]
//*[@id="content"]/div[3]/div[2]/table[1]/tbody/tr[2]/td[2]