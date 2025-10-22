using System;
using System.Collections.Generic;
using FountainOfObjects.Displays;

namespace FountainOfObjects.GameDesign
{
    public class Map
    {
        private readonly RoomType[,] rooms;

        public int Width { get; }
        public int Height { get; }

        public Map(int rows, int columns)
        {
            Width = columns;
            Height = rows;
            rooms = new RoomType[rows, columns];
        }

        public void SetRoomType(Location loc, RoomType type)
        {
            if (IsWithinBounds(loc))
            {
                rooms[loc.Row, loc.Column] = type;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Location is out of map bounds.");
            }
        }

        public RoomType GetRoomTypeAt(Location loc)
        {
            if (IsWithinBounds(loc))
            {
                return rooms[loc.Row, loc.Column];
            }
            else
            {
                return RoomType.OffMap;
            }
        }

        public bool IsWithinBounds(Location loc)
        {
            return loc.Row >= 0 && loc.Row < Height && loc.Column >= 0 && loc.Column < Width;
        }

        public Location[] GetAdjacentRooms(Location loc)
        {
            var adjacentRooms = new List<Location>();
            
            //check all 8 surrounding positions (including diagonals)//
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    //skip the center position (the location itself)//
                    if (dx == 0 && dy == 0) continue;
                    
                    Location neighbor = new Location(loc.Row + dx, loc.Column + dy);
                    if (IsWithinBounds(neighbor))
                        adjacentRooms.Add(neighbor);
                }
            }
            return adjacentRooms.ToArray();
        }

        public bool HasNeighborWithType(Location loc, RoomType type)
        {
            foreach (var neighbor in GetAdjacentRooms(loc))
            {
                if (GetRoomTypeAt(neighbor) == type)
                    return true;
            }
            return false;
        }
    }
}