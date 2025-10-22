using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Monsters
{
    public class Amarok : Monster
    {
        public Amarok(Location position) : base(position) {}

        public override void Act(Player player, Map map)
        {
            if (Location.Equals(player.Location))
            {
                DisplayStyle.WriteLine("An Amarok has caught you! You are torn apart.", ConsoleColor.Cyan);
                player.Kill("Amarok");
            }
        }
    }
}