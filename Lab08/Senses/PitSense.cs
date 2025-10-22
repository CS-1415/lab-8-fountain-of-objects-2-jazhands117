using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Senses
{
    public class PitSense : ISense
    {
        public bool Detect(Game game)
        {
            foreach (var neighbor in game.Map.GetAdjacentRooms(game.Player.Location))
            {
                if (game.Map.GetRoomTypeAt(neighbor) == RoomType.Pit)
                    return true;
            }
            return false;
        }
        public void Notify(Game game)
        {
            DisplayStyle.WriteLine("You feel a draft. There is a pit nearby. Be cautious.", ConsoleColor.Cyan);
        }
    }
}