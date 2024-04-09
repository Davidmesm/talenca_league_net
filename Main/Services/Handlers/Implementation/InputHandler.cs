using Main.Models;

namespace Main.Services.Handlers.Implementation
{
    public class InputHandler : IInputHandler
    {
        public List<Game> ReadInputFromFile(string inputFile)
        {

            if (File.Exists(inputFile))
            {
                var games = new List<Game>();

                try
                {
                    // Read the file line by line
                    using (StreamReader reader = new StreamReader(inputFile))
                    {
                        string? line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            games.Add(MapStringToGame(line));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while reading the file: {ex.Message}");
                }

                return games;
            }
            else
            {
                throw new FileNotFoundException($"File '{inputFile}' not found.");
            }
        }

        private Game MapStringToGame(string gameLine)
        {
            var teamsScores = gameLine.Split(",");

            var teamAInfo = teamsScores[0].Trim().Split(" ");
            var teamBInfo = teamsScores[1].Trim().Split(" ");

            string teamA = string.Join(" ", teamAInfo, 0, teamAInfo.Length - 1);
            int scoreTeamA = int.Parse(teamAInfo[teamAInfo.Length - 1]);

            string teamB = string.Join(" ", teamBInfo, 0, teamBInfo.Length - 1);
            int scoreTeamB = int.Parse(teamBInfo[teamBInfo.Length - 1]);

            return new Game(teamA, scoreTeamA, teamB, scoreTeamB);
        }

    }
}