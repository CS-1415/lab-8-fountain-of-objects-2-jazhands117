using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Commands
{
    public class HelpCommand : ICommand
    {
        public void Execute(Game game)
        {
            DisplayStyle.WriteLine("Available commands:", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'move north' - Move to the north", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'move south' - Move to the south", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'move east'  - Move to the east", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'move west'  - Move to the west", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'shoot north' - Shoot an arrow to the north", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'shoot south' - Shoot an arrow to the south", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'shoot east'  - Shoot an arrow to the east", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'shoot west'  - Shoot an arrow to the west", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'enable fountain' - Turn on the fountain", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'map' - Display the map of known locations", ConsoleColor.Gray);
            DisplayStyle.WriteLine("  'help' - Show this help message", ConsoleColor.Gray);
        }
    }
}