using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Displays;
using FountainOfObjects.Monsters;

namespace FountainOfObjects.Commands
{
    public class ShootCommand : ICommand
    {
        private readonly Direction _direction;

        public ShootCommand(Direction direction)
        {
            _direction = direction;
        }

        public void Execute(Game game)
        {
            //attempt to use an arrow; if none available, inform player and quit shooting//
            if (!game.Player.UseArrow())
            {
                DisplayStyle.WriteLine("You don't have any arrows left!", ConsoleColor.Cyan);
                return;
            }

            Location arrowLocation = game.Player.Location.Move(_direction);
            
            //check if the arrow hits a monster//
            foreach (Monster monster in game.Monsters)
            {
                if (monster.Location == arrowLocation && monster.IsAlive)
                {
                    monster.Kill();
                    DisplayMap.MarkMonsterHit(arrowLocation);
                    DisplayStyle.WriteLine("Your arrow strikes true! You hear a roar of pain.", ConsoleColor.Green);
                    return;
                }
            }

            //check if the arrow goes into a pit! detection method! :D//
            if (game.Map.GetRoomTypeAt(arrowLocation) == RoomType.Pit)
            {
                DisplayMap.MarkTileDiscovered(arrowLocation, RoomType.Pit);
                DisplayStyle.WriteLine("The arrow soars through the air and keeps going. You never hear it hit the floor, the room must contain a pit!", ConsoleColor.Green);
                return;
            }

            DisplayStyle.WriteLine("Your arrow flies through the air but hits nothing. You hear it thunk against the floor.", ConsoleColor.Green);
        }
    }
}