using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Commands
{
    public class MapCommand : ICommand
    {
        public void Execute(Game game)
        {
            DisplayMap.ShowMap(game);
        }
    }
}