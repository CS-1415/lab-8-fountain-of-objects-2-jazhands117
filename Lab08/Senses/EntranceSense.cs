using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Senses
{
    public class EntranceSense : ISense
    {
        public bool Detect(Game game)
        {
            return game.Map.GetRoomTypeAt(game.Player.Location) == RoomType.Entrance;
        }
        public void Notify(Game game)
        {
            DisplayStyle.WriteLine("The light tells you you're at the entrance!", ConsoleColor.Cyan);
        }
    }
}