using Main.Services.Handlers.Implementation;

namespace Main.Tests.Services.Handlers
{
    public class InputHandlerTests
    {
        [Fact]
        public void ReadInputFromFile_WhenFileDoesNotExist_ThrowsFileNotFoundException()
        {
            var inputHandler = new InputHandler();

            Assert.Throws<FileNotFoundException>(() => inputHandler.ReadInputFromFile("nonexistentfile.txt"));
        }

        [Fact]
        public void ReadInputFromFile_WhenFileExists_ReturnsCorrectGames()
        {
            var inputFile = "input.txt";
            var fileContent = "TeamA 3, TeamB 2\nTeamC 1, TeamD 4\n";

            // Create a temp file
            File.WriteAllText(inputFile, fileContent);

            try
            {

                var inputHandler = new InputHandler();

                var games = inputHandler.ReadInputFromFile(inputFile);

                // Assert
                Assert.Collection(games,
                    game =>
                    {
                        Assert.Equal("TeamA", game.TeamA.Name);
                        Assert.Equal(3, game.ScoreTeamA);
                        Assert.Equal("TeamB", game.TeamB.Name);
                        Assert.Equal(2, game.ScoreTeamB);
                    },
                    game =>
                    {
                        Assert.Equal("TeamC", game.TeamA.Name);
                        Assert.Equal(1, game.ScoreTeamA);
                        Assert.Equal("TeamD", game.TeamB.Name);
                        Assert.Equal(4, game.ScoreTeamB);
                    });
            }
            finally
            {
                // Delete the temp file
                File.Delete(inputFile);
            }
        }
    }
}