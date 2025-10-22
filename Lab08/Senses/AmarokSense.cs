using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;
using FountainOfObjects.Monsters;

namespace FountainOfObjects.Senses
{
    public class AmarokSense : ISense
    {
        public bool Detect(Game game)
        {
            foreach (Monster monster in game.Monsters)
            {
                if (monster is Amarok)
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
            DisplayStyle.WriteLine("You smell a foul stench. There is an amarok nearby. Be cautious.", ConsoleColor.Cyan);
        }
    }
}