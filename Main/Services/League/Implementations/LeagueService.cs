using Main.Models;
using Main.Models.Enum;

namespace Main.Services.League.Implementations
{
    public class LeagueService : ILeagueService
    {
        private const int WIN_POINTS = 3;
        private const int DRAW_POINTS = 1;
        private const int LOSE_POINTS = 0;


        public Models.League League { get; set; }

        public LeagueService()
        {
            League = new Models.League();
        }

        public List<Team> GetTeamsByPoints()
        {
            return League.Teams.Values.OrderByDescending(t => t.Points).ThenBy(t => t.Name).ToList();
        }

        public void ProcessGames(List<Game> games)
        {
            games.ForEach(game =>
            {
                if (game.ScoreTeamA > game.ScoreTeamB)
                {
                    AddGameResultToTeam(game.TeamA, GameResult.Win);
                    AddGameResultToTeam(game.TeamB, GameResult.Lose);
                }
                else if (game.ScoreTeamA < game.ScoreTeamB)
                {
                    AddGameResultToTeam(game.TeamB, GameResult.Win);
                    AddGameResultToTeam(game.TeamA, GameResult.Lose);
                }
                else
                {
                    AddGameResultToTeam(game.TeamB, GameResult.Draw);
                    AddGameResultToTeam(game.TeamA, GameResult.Draw);
                }

            });
        }


        private void AddGameResultToTeam(Team team, GameResult result)
        {
            if (League.Teams.ContainsKey(team.Name))
            {
                team = League.Teams[team.Name];
            }

            if (result == GameResult.Win)
            {
                team.Points += WIN_POINTS;
            }
            else if (result == GameResult.Draw)
            {
                team.Points += DRAW_POINTS;
            }

            League.Teams[team.Name] = team;
        }
    }
}