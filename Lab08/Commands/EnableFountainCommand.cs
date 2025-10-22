using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Commands
{
    public class EnableFountainCommand : ICommand
    {
        public void Execute(Game game)
        {
            if (game.Map.GetRoomTypeAt(game.Player.Location) == RoomType.Fountain)
            {
                game.FountainOn = true;
                DisplayStyle.WriteLine("You turn on the fountain. The Code Water starts flowing!", ConsoleColor.Green);
            }
            else
            {
                DisplayStyle.WriteLine("There is no fountain to enable here.", ConsoleColor.Yellow);
            }
        }
    }
}