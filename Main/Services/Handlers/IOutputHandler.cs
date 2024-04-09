using Main.Models;

namespace Main.Services.Handlers
{
    public interface IOutputHandler
    {
        string FormatTeamsRanking(List<Team> teams);
    }
}