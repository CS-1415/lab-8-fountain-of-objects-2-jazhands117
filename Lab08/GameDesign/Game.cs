using System;
using FountainOfObjects.Displays;
using FountainOfObjects.Monsters;
using FountainOfObjects.Interfaces;
using FountainOfObjects.Senses;
using FountainOfObjects.Commands;

namespace FountainOfObjects.GameDesign
{
    public class Game
    {
        public Map Map {get;} 
        public Player Player {get;}
        public Monster[] Monsters {get;}
        public bool FountainOn {get; set;}
        private readonly ISense[] _senses;

        public Game(Map map, Player player, Monster[] monsters)
        {
            Map = map;
            Player = player;
            Monsters = monsters;
            DisplayMap.InitializeMap(map.Height, map.Width);

            _senses = new ISense[]
            {
                new EntranceSense(),
                new FountainSense(),
                new PitSense(),
                new MaelstromSense(),
                new AmarokSense()
            };
        }

        public void Run()
        {
            while (!HasWon && Player.IsAlive)
            {
                DisplayStatus();
                ICommand command = GetUserInput();
                Console.Clear();  //clear screen after command input//
                command.Execute(this);
                DisplayMap.CheckFountainDiscovery(this);  //check if player has found the fountain//

                if (DisplayMap.CheckFountainDiscovery(this) && FountainOn)
                {
                    DisplayStyle.WriteLine("The Fountain glows brightly!", ConsoleColor.Green);
                    DisplayStyle.WriteLine("You have activated the Fountain of Objects! Now return to the entrance to win!", ConsoleColor.Green);
                }
                
                foreach (Monster monster in Monsters)
                {
                    if (monster.Location == Player.Location && monster.IsAlive)
                    {
                        monster.Activate(this);
                    }
                }
                if (CurrentRoom == RoomType.Pit)
                {
                    Player.Kill("You fell into a pit.");
                }
                Console.WriteLine(); //adds a blank line after any command messages//
            }
            if (HasWon)
            {
                DisplayStyle.WriteLine("The Fountain is activated and you escaped with your life. Good job!", ConsoleColor.Green);
                DisplayStyle.WriteLine("YOU WIN! Congratulations!", ConsoleColor.Green);
            }
            else
            {
                DisplayStyle.WriteLine(Player.CauseOfDeath, ConsoleColor.Red);
                DisplayStyle.WriteLine("YOU DIED. Game over.", ConsoleColor.Red);
            }
        }    

        private void DisplayStatus()
        {
            DisplayStyle.WriteLine($"You are in room {Player.Location}.", ConsoleColor.White);
            DisplayStyle.WriteLine($"You have {Player.ArrowsRemaining} arrows remaining.", ConsoleColor.Gray);
            foreach (ISense sense in _senses)
            {
                if (sense.Detect(this))
                {
                    sense.Notify(this);
                }
            }
        }

        private ICommand GetUserInput()
        {
            while (true)
            {
                DisplayStyle.WriteLine("What would you like to do?", ConsoleColor.White);
                Console.ForegroundColor = ConsoleColor.Yellow;
                string? raw = Console.ReadLine();
                string input = (raw ?? string.Empty).Trim().ToLower();

                if (input == "move north") 
                    return new MoveCommand(Direction.North);
                if (input == "move south") 
                    return new MoveCommand(Direction.South);
                if (input == "move east") 
                    return new MoveCommand(Direction.East);
                if (input == "move west") 
                    return new MoveCommand(Direction.West);
                if (input == "shoot north") 
                    return new ShootCommand(Direction.North);
                if (input == "shoot south") 
                    return new ShootCommand(Direction.South);
                if (input == "shoot east") 
                    return new ShootCommand(Direction.East);
                if (input == "shoot west") 
                    return new ShootCommand(Direction.West);
                if (input == "enable fountain") 
                    return new EnableFountainCommand();
                if (input == "help") 
                    return new HelpCommand();
                if (input == "map")
                    return new MapCommand();

                DisplayStyle.WriteLine($"'{input}' is not a valid command. Type 'help' for list of commands.", ConsoleColor.Magenta);
            }
        }

        public bool HasWon => FountainOn && CurrentRoom == RoomType.Entrance;
        public RoomType CurrentRoom => Map.GetRoomTypeAt(Player.Location);
    }
}