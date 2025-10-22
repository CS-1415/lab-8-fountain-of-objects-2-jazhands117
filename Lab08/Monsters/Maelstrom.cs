using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Displays;

namespace FountainOfObjects.Monsters
{
    public class Maelstrom : Monster
    {
        public Maelstrom(Location position) : base(position) { }

        //override Activate so we have access to the full Game object (monsters, fountain state, etc.)//
        public override void Activate(Game game)
        {
            if (!Location.Equals(game.Player.Location))
                return;

            PerformTransport(game, game.Player, game.Map, allowMonsters: true);
        }

        public override void Act(Player player, Map map)
        {
            if (!Location.Equals(player.Location))
                return;

            PerformTransport(null, player, map, allowMonsters: false);
        }

        private void PerformTransport(Game? game, Player player, Map map, bool allowMonsters)
        {
            //compute wrapped player destination: 1 north, 2 east//
            int newPlayerRow = (player.Location.Row - 1) % map.Height;
            if (newPlayerRow < 0) newPlayerRow += map.Height;
            int newPlayerCol = (player.Location.Column + 2) % map.Width;
            Location newPlayerLocation = new Location(newPlayerRow, newPlayerCol);

            //compute wrapped maelstrom destination: 1 south, 2 west//
            int newMaelRow = (Location.Row + 1) % map.Height;
            int newMaelCol = (Location.Column - 2) % map.Width;
            if (newMaelCol < 0) newMaelCol += map.Width;
            Location newMaelLocation = new Location(newMaelRow, newMaelCol);

            //apply moves//
            player.Location = newPlayerLocation;
            this.Location = newMaelLocation;

            DisplayStyle.WriteLine("You have been swallowed by the Maelstrom! You are moved 1 north and 2 east.", ConsoleColor.Cyan);

            //after moving player, check the room type and trigger effects//
            RoomType rt = map.GetRoomTypeAt(player.Location);
            switch (rt)
            {
                case RoomType.Pit:
                    DisplayStyle.WriteLine("You fall into a pit after being transported!", ConsoleColor.Red);
                    player.Kill("Fell into a pit after Maelstrom transport");
                    return;
                case RoomType.Fountain:
                    DisplayStyle.WriteLine("You land in the fountain room.", ConsoleColor.Green);
                    break;
                case RoomType.Entrance:
                    DisplayStyle.WriteLine("You are transported to the entrance.", ConsoleColor.Green);
                    break;
                default:
                    break;
            }

            //activates monsters if landed on their tile//
            if (allowMonsters && game != null)
            {
                foreach (var monster in game.Monsters)
                {
                    if (monster.Location.Equals(player.Location) && monster.IsAlive)
                    {
                        monster.Activate(game);
                        if (!player.IsAlive)
                            return;
                    }
                }
            }
        }
    }
}