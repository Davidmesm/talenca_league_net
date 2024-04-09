using Main.Models;

namespace Main.Services.League
{
    public interface ILeagueService
    {
        Models.League League { get; set; }
        void ProcessGames(List<Game> games);

        List<Team> GetTeamsByPoints();
    }
}