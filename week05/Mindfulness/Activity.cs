// Activity.cs
using System;
using System.Threading; // Required for Thread.Sleep

public class Activity
{
    // Member variables (attributes)
    protected string _name;
    protected string _description;
    protected int _duration; // Duration in seconds

    // Default Constructor (though derived classes will likely use the parameterized one)
    public Activity()
    {
        _name = "Generic Activity";
        _description = "This is a generic mindfulness activity.";
        _duration = 0;
    }

    // Parameterized Constructor
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    // Methods
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\n{_description}");
        Console.Write("\nHow long, in seconds, would you like for this activity? ");

        // Loop to ensure valid integer input for duration
        bool isValidInput = false;
        while (!isValidInput)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int parsedDuration) && parsedDuration > 0)
            {
                _duration = parsedDuration;
                isValidInput = true;
            }
            else
            {
                Console.Write("Invalid input. Please enter a positive whole number for seconds: ");
            }
        }
        
        Console.Clear(); // Clear console before activity begins
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3); // Pause for 3 seconds while showing spinner
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3); // Pause for 3 seconds while showing spinner

        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3); // Pause for 3 seconds while showing spinner
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        DateTime startTime = DateTime.Now;
        int i = 0;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250); // Pause for 250 milliseconds
            Console.Write("\b \b"); // Erase the character: \b is backspace
            i = (i + 1) % spinner.Length; // Cycle through spinner characters
        }
        Console.WriteLine(); // New line after spinner completes
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second
            Console.Write("\b \b"); // Erase the character: \b is backspace
        }
        // Console.WriteLine(); // Optionally add a new line after countdown if not followed by other output
    }
}