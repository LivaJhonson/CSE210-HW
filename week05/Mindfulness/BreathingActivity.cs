// BreathingActivity.cs
using System;
using System.Threading; // Required for Thread.Sleep

public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0)
    {
        // No unique member variables to initialize here beyond base class
    }

    // Run method with specific breathing logic
    public void Run()
    {
        DisplayStartingMessage(); // Call base class method to display start message and set duration

        Console.WriteLine("\nBegin breathing cycle...");
        ShowSpinner(3); // Small pause before actual breathing starts

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4); // Breathe in for 4 seconds

            if ((DateTime.Now - startTime).TotalSeconds >= _duration) // Check if time is up after first part
                break;

            Console.Write("Now breathe out...");
            ShowCountDown(6); // Breathe out for 6 seconds
            
            if ((DateTime.Now - startTime).TotalSeconds < _duration)
            {
                 Console.WriteLine();
                 ShowSpinner(2); // Pause for 2 seconds between cycles
            }
        }

        DisplayEndingMessage(); // Call base class method to display end message
    }
}