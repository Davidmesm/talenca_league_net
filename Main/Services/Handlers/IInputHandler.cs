using Main.Models;

namespace Main.Services.Handlers
{
    public interface IInputHandler
    {
        List<Game> ReadInputFromFile(string inputFile);
    }
}