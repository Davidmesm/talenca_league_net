namespace Main.Models
{
    public class League
    {
        public Dictionary<string, Team> Teams { get; set; }

        public League()
        {
            Teams = new Dictionary<string, Team>();
        }
    }
}