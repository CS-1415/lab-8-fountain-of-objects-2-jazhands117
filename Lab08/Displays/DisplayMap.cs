using System;
using FountainOfObjects.GameDesign;
using FountainOfObjects.Monsters;

namespace FountainOfObjects.Displays
{
    public static class DisplayMap
    {
        private static bool[,]? discoveredTiles;
        private static RoomType[,]? knownRoomTypes;
        private static bool[,]? knownMonsterLocations;
        private static bool fountainDiscovered = false;

        public static void InitializeMap(int rows, int columns)
        {
            discoveredTiles = new bool[rows, columns];
            knownRoomTypes = new RoomType[rows, columns];
            knownMonsterLocations = new bool[rows, columns];
        }

        public static void MarkTileDiscovered(Location location, RoomType roomType)
        {
            discoveredTiles![location.Row, location.Column] = true;
            knownRoomTypes![location.Row, location.Column] = roomType;
        }

        public static void MarkMonsterHit(Location location)
        {
            knownMonsterLocations![location.Row, location.Column] = true;
        }

        public static bool CheckFountainDiscovery(Game game)
        {
            if (game.Map.GetRoomTypeAt(game.Player.Location) == RoomType.Fountain)
            {
                fountainDiscovered = true;
            }
            else
            {
                fountainDiscovered = false;
            }
            return fountainDiscovered;
        }

        public static void ShowMap(Game game)
        {
            Location playerLoc = game.Player.Location;
            int rows = game.Map.Height;
            int cols = game.Map.Width;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;

            //top border//
            Console.Write("  "); //left margin//
            for (int c = 0; c < cols; c++)
                Console.Write("====");
            Console.WriteLine("=");

            for (int row = 0; row < rows; row++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|"); //left wall//

                for (int col = 0; col < cols; col++)
                {
                    Location currentLoc = new Location(row, col);
                    RoomType roomType = game.Map.GetRoomTypeAt(currentLoc);

                    //pick color//
                    if (row == playerLoc.Row && col == playerLoc.Column)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (roomType == RoomType.Entrance)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (fountainDiscovered && roomType == RoomType.Fountain)
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    else if (knownMonsterLocations![row, col])
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (knownRoomTypes![row, col] == RoomType.Pit)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else if (!discoveredTiles![row, col])
                        Console.ForegroundColor = ConsoleColor.Gray;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" ██ "); //filled tile, stolen from the interwebs//
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|"); //right wall//
            }

            //bottom border//
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  ");
            for (int c = 0; c < cols; c++)
                Console.Write("====");
            Console.WriteLine("=");

            Console.ResetColor();

            //legend//
            Console.WriteLine("\n=== Legend ===");
            Console.ForegroundColor = ConsoleColor.Gray; 
            Console.WriteLine("██  Unknown");
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine("██  Safe (Monster defeated)");
            Console.ForegroundColor = ConsoleColor.Yellow; 
            Console.WriteLine("██  Pit");
            Console.ForegroundColor = ConsoleColor.Blue; 
            Console.WriteLine("██  Entrance");
            Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            Console.WriteLine("██  Fountain");
            Console.ForegroundColor = ConsoleColor.Magenta; 
            Console.WriteLine("██  Player");
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("====  Walls");
            Console.ResetColor();
        }
    }
}
