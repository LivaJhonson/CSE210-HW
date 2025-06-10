// Program.cs
using System;
using System.Threading; // Required for Thread.Sleep

class Program
{
    static void Main(string[] args)
    {
        string choice = "";
        while (choice != "4") // Loop until user chooses to quit
        {
            Console.Clear(); // Clear console for cleaner menu display
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();
            Console.Clear(); // Clear console after choice is made

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    Thread.Sleep(2000); // Pause for 2 seconds before showing menu again
                    break;
            }
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(); // Wait for user to press a key before looping back
        }
    }
}