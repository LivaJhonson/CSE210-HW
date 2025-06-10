// Program.cs
using System;
using System.Threading; // Required for Thread.Sleep
using System.Collections.Generic; // Required for Dictionary

class Program
{
    // --- Exceeding Requirements: Keeping a log of how many times activities were performed ---
    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>
    {
        { "Breathing Activity", 0 },
        { "Reflecting Activity", 0 },
        { "Listing Activity", 0 }
    };
    private static int _totalActivitiesCompleted = 0;

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
            Console.WriteLine("\n--- Activity Log ---");
            foreach (var entry in _activityCounts)
            {
                Console.WriteLine($"  {entry.Key}: {entry.Value} times");
            }
            Console.WriteLine($"  Total Activities Completed: {_totalActivitiesCompleted} times");
            Console.WriteLine("--------------------");
            
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();
            Console.Clear(); // Clear console after choice is made

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    _activityCounts["Breathing Activity"]++; // Increment count for this activity
                    _totalActivitiesCompleted++; // Increment total count
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    _activityCounts["Reflecting Activity"]++; // Increment count for this activity
                    _totalActivitiesCompleted++; // Increment total count
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    _activityCounts["Listing Activity"]++; // Increment count for this activity
                    _totalActivitiesCompleted++; // Increment total count
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    Thread.Sleep(2000); // Pause for 2 seconds before showing menu again
                    break;
            }
            // Only prompt to return to menu if not quitting
            if (choice != "4")
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(); // Wait for user to press a key before looping back
            }
        }
    }
}