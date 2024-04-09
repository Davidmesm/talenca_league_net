using System.Text;
using Main.Models;

namespace Main.Services.Handlers.Implementation
{
    public class OutputHandler : IOutputHandler
    {
        public string FormatTeamsRanking(List<Team> teams)
        {
            StringBuilder result = new StringBuilder();

            int currentRank = 1;
            teams.ForEach(team =>
            {
                result.AppendLine($"{currentRank}. {team.Name}, {team.Points} {(team.Points == 1 ? "pt" : "pts")}");
                currentRank++;
            });

            return result.ToString();
        }

    }
}