namespace Main.Models
{
    public class Game
    {

        public Team TeamA { get; set; }
        public int ScoreTeamA { get; set; }
        public Team TeamB { get; set; }
        public int ScoreTeamB { get; set; }

        public Game(string teamAName, int scoreTeamA, string teamBName, int scoreTeamB)
        {
            TeamA = new Team(teamAName);
            ScoreTeamA = scoreTeamA;
            TeamB = new Team(teamBName);
            ScoreTeamB = scoreTeamB;
        }
    }
}