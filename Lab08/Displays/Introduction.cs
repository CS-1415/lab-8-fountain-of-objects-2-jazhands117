using System;
namespace FountainOfObjects.Displays
{
    public static class Introduction
    {
        public static void DisplayIntro()
        {
            //title screen!//
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("         The Fountain of Objects       ");
            Console.WriteLine("=======================================");
            Console.WriteLine();
            Console.WriteLine("Press ENTER to continue...");
            Console.ResetColor();
            Console.ReadLine();

            //exact text described by the book//
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You enter the Cavern of Objects, a maze filled with dangerous pits, in search of the Fountain of Objects.");
            Console.WriteLine("Light is visible only in the entrance, and no other light is seen anywhere in the caverns.");
            Console.WriteLine("You must navigate the Caverns with your other senses.");
            Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
            Console.WriteLine("Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.");
            Console.WriteLine("Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns.");
            Console.WriteLine("You will be able to hear their whipping wind in nearby rooms.");
            Console.WriteLine("Amaroks roam the caverns. Encountering one is certain death, but they stink and can be smelled in nearby rooms.");
            Console.WriteLine("You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns or check for pits.");
            Console.WriteLine("Be warned: you have a limited supply of arrows.");
            Console.WriteLine("Good luck, traveller.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("Press ENTER to begin your journey...");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
    }
}