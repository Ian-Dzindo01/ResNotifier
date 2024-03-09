using HtmlAgilityPack;

static public class Scraper
{
    static public void Start()
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("https://www.basketball-reference.com/boxscores/");

        var title = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/h1").First().InnerText;
        var awayTeams = document.DocumentNode.SelectNodes("//*[@id=\"content\"]/div[3]/div/table[1]/tbody/tr[1]/td[1]/a");
        
        Console.WriteLine(title);

        if (awayTeams != null)
        {
            // Print each team name
            foreach (var teamNode in awayTeams)
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

// Away:
//*[@id=\"content\"\]/div[3]/div/table[1]/tbody/tr[1]/td[1]/a
//*[@id=\"content\"]/div[3]/div[2]/table[1]/tbody/tr[1]/td[1]/a  
//*[@id=\"content\"]/div[3]/div[3]/table[1]/tbody/tr[1]/td[1]/a

// Home:
//*[@id=\"content\"]/div[3]/div[1]/table[1]/tbody/tr[2]/td[1]/a 
//*[@id=\"content\"]/div[3]/div[2]/table[1]/tbody/tr[2]/td[1]/a
//*[@id=\"content\"]/div[3]/div[3]/table[1]/tbody/tr[2]/td[1]/a