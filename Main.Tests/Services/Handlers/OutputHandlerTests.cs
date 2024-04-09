using Main.Models;
using Main.Services.Handlers.Implementation;

namespace Main.Tests.Services.Handlers
{
    public class OutputHandlerTests
    {
        [Fact]
        public void FormatTeamsRanking_WhenTeamsListIs_ReturnsCorrectFormat()
        {
            var teams = new List<Team>
            {
                new Team("TeamA") { Points = 5 },
                new Team("TeamB") { Points = 3 },
                new Team("TeamC") { Points = 7 },
                new Team("TeamD") { Points = 1 },
            };

            var expectedOutput = "1. TeamA, 5 pts\r\n" +
                                 "2. TeamB, 3 pts\r\n" +
                                 "3. TeamC, 7 pts\r\n" +
                                 "4. TeamD, 1 pt\r\n";

            var outputHandler = new OutputHandler();

            var formattedOutput = outputHandler.FormatTeamsRanking(teams);

            Assert.Equal(expectedOutput, formattedOutput);
        }

        [Fact]
        public void FormatTeamsRanking_WhenTeamsListIsEmpty_ReturnsEmptyString()
        {
            var teams = new List<Team>();

            var outputHandler = new OutputHandler();

            var formattedOutput = outputHandler.FormatTeamsRanking(teams);

            Assert.Equal(string.Empty, formattedOutput);
        }
    }
}