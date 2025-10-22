using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Senses
{
    public class FountainSense : ISense
    {
        public bool Detect(Game game)
        {
            if (game.Map.GetRoomTypeAt(game.Player.Location) == RoomType.Fountain)
                return true;
                
            return game.Map.HasNeighborWithType(game.Player.Location, RoomType.Fountain);
        }
        public void Notify(Game game)
        {
            //check if player is actually IN the fountain room//
            if (game.Map.GetRoomTypeAt(game.Player.Location) == RoomType.Fountain)
            {
                if (game.FountainOn)
                {
                    DisplayStyle.WriteLine("You are in the Fountain Room. The fountain is on, and it gushes brightly with Code Water!", ConsoleColor.Cyan);
                }
                else
                {
                    DisplayStyle.WriteLine("You are in the Fountain Room. The fountain is here — currently off and silent.", ConsoleColor.Cyan);
                }
            }
            else
            {
                //player is near the fountain (adjacent tile)//
                if (game.FountainOn)
                {
                    DisplayStyle.WriteLine("You hear a steady rush of Code Water nearby — the fountain is flowing!", ConsoleColor.Cyan);
                }
                else
                {
                    DisplayStyle.WriteLine("You hear water dripping from nearby — the fountain is close.", ConsoleColor.Cyan);
                }
            }
        }
    }
}