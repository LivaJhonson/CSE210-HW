// ListingActivity.cs
using System;
using System.Collections.Generic; // Required for List<string>
using System.Linq; // Not strictly needed for this current implementation, but often useful with Lists

public class ListingActivity : Activity
{
    // Member variables (attributes)
    private int _count; // Number of items listed by the user

    // Constructor
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0)
    {
        _count = 0; // Initialize count
    }

    // Run method with specific listing logic
    public void Run()
    {
        DisplayStartingMessage(); // Call base class method to display start message and set duration

        Console.WriteLine("\nPrepare to list items...");
        
        string prompt = GetRandomPrompt(); // Get a random prompt
        Console.WriteLine($"\n--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5); // Give user 5 seconds to think

        List<string> userItems = GetListFromUser(); // Collect items here
        _count = userItems.Count; // Update the count after collection

        Console.WriteLine($"\nYou listed {_count} items."); // Display the final count
        DisplayEndingMessage(); // Call base class method to display end message
    }

    public string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index]; // Return the selected prompt
    }

    public List<string> GetListFromUser()
    {
        List<string> userList = new List<string>();
        DateTime startTime = DateTime.Now;
        
        // No explicit message like "Start listing items:" here, as the prompt is already given.
        // The user just starts typing.

        // Loop for the duration, collecting input line by line
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> "); // Prompt for each item
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item)) // Add item only if not empty or just whitespace
            {
                userList.Add(item);
            }
            // No need for a sleep here, as ReadLine waits for input, effectively pausing.
            // The loop condition naturally ends when time is up.
        }
        return userList;
    }
}