using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;
using FountainOfObjects.Monsters;

namespace FountainOfObjects.Senses
{
    public class MaelstromSense : ISense
    {
        public bool Detect(Game game)
        {
            foreach (Monster monster in game.Monsters)
            {
                if (monster is Maelstrom)
                {
                    if (game.Player.Location.IsAdjacent(monster.Location))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Notify(Game game)
        {
            DisplayStyle.WriteLine("You hear a whipping storm. There is a maelstrom nearby. Be cautious.", ConsoleColor.Cyan);
        }
    }
}