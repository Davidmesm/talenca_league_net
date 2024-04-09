using Main.Models;
using Main.Services.Handlers;
using Main.Services.Handlers.Implementation;
using Main.Services.League;
using Main.Services.League.Implementations;

if (args.Length != 1)
{
    Console.WriteLine("Error: Require <input_file> argument.");
    return;
}

// Extract the input file name
string input_file = args[0];

IInputHandler inputHandler = new InputHandler();
ILeagueService leagueService = new LeagueService();
IOutputHandler outputHandler = new OutputHandler();

try
{
    List<Game> inputGames = inputHandler.ReadInputFromFile(input_file);

    if (inputGames.Count == 0)
    {
        Console.WriteLine("The input file has no data.");
        return;
    }

    leagueService.ProcessGames(inputGames);

    var formatResult = outputHandler.FormatTeamsRanking(leagueService.GetTeamsByPoints());

    Console.WriteLine(formatResult);

}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}