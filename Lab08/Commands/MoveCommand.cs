using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Direction _direction;

        public MoveCommand(Direction direction)
        {
            _direction = direction;
        }

        public void Execute(Game game)
        {
            Location newLocation = game.Player.Location.Move(_direction);
            //if the location is off-map, GetRoomTypeAt will return OffMap//
            if (game.Map.GetRoomTypeAt(newLocation) != RoomType.OffMap)
            {
                game.Player.Move(_direction);
                DisplayStyle.WriteLine($"You moved {_direction.ToString().ToLower()}.", ConsoleColor.Red);
            }
            else
            {
                DisplayStyle.WriteLine("There is a wall there.", ConsoleColor.Red);
            }
        }
    }
}