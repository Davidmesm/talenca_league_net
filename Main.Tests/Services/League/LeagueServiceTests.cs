using Main.Models;
using Main.Services.League.Implementations;

namespace Main.Tests.Services.League
{
    public class LeagueServiceTests
    {
        [Fact]
        public void GetTeamsByPoints_ReturnsTeamsOrderedByPoints()
        {
            var teamA = new Team("TeamA") { Points = 5 };
            var teamB = new Team("TeamB") { Points = 3 };
            var teamC = new Team("TeamC") { Points = 7 };
            var teams = new Dictionary<string, Team>
            {
                { "TeamA", teamA },
                { "TeamB", teamB },
                { "TeamC", teamC }
            };

            var league = new Models.League { Teams = teams };

            var leagueService = new LeagueService { League = league };

            var expectedOrder = new List<Team> { teamC, teamA, teamB };

            var teamsByPoints = leagueService.GetTeamsByPoints();

            Assert.Equal(expectedOrder, teamsByPoints);
        }

        [Fact]
        public void GetTeamsByPoints_WhenSamePoints_ReturnByName()
        {
            var teamA = new Team("TeamA") { Points = 5 };
            var teamB = new Team("TeamB") { Points = 5 };
            var teamC = new Team("TeamC") { Points = 5 };
            var teams = new Dictionary<string, Team>
            {
                { "TeamB", teamB },
                { "TeamA", teamA },
                { "TeamC", teamC }
            };

            var league = new Models.League { Teams = teams };

            var leagueService = new LeagueService { League = league };

            var expectedOrder = new List<Team> { teamA, teamB, teamC };

            var teamsByPoints = leagueService.GetTeamsByPoints();

            Assert.Equal(expectedOrder, teamsByPoints);
        }


        [Fact]
        public void ProcessGames_WhenWin_AddsThreePointsOnGameResults()
        {
            var game1 = new Game("TeamA", 2, "TeamB", 1);

            var games = new List<Game> { game1 };

            var leagueService = new LeagueService();

            leagueService.ProcessGames(games);

            var teams = leagueService.League.Teams;

            teams.Values.ToList().ForEach(team =>
            {
                Console.WriteLine($"{team.Name} {team.Points}");
            });

            Assert.Equal(3, teams["TeamA"].Points); // 3 points for winning
            Assert.Equal(0, teams["TeamB"].Points); // 0 point for losing
        }

        [Fact]
        public void ProcessGames_WhenDraw_AddsOnePointsOnGameResults()
        {
            var game1 = new Game("TeamA", 1, "TeamB", 1);

            var games = new List<Game> { game1 };

            var leagueService = new LeagueService();

            leagueService.ProcessGames(games);

            var teams = leagueService.League.Teams;

            Assert.Equal(1, teams["TeamA"].Points); // 1 point for draw
            Assert.Equal(1, teams["TeamB"].Points); // 1 point for draw
        }

        [Fact]
        public void ProcessGames_WhenMultipleWinsOrDraws_AccumulatePointsOnGameResults()
        {
            var game1 = new Game("TeamA", 1, "TeamB", 1);
            var game2 = new Game("TeamA", 2, "TeamB", 1);
            var game3 = new Game("TeamA", 2, "TeamB", 1);

            var games = new List<Game> { game1, game2, game3 };

            var leagueService = new LeagueService();

            leagueService.ProcessGames(games);

            var teams = leagueService.League.Teams;

            Assert.Equal(7, teams["TeamA"].Points); // 7 point for 2 wins(3) + 1 draw(1)
            Assert.Equal(1, teams["TeamB"].Points); // 1 point for draw(1) + 0 points lose (0)
        }

    }
}