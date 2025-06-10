// ReflectingActivity.cs
using System;
using System.Collections.Generic; // Required for List<string>
using System.Threading; // Required for Thread.Sleep

public class ReflectingActivity : Activity
{
    // Member variables (attributes)
    private List<string> _prompts;
    private List<string> _questions;

    // Constructor
    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 0)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were less successful?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you use this experience to your advantage in the future?"
        };
    }

    // Run method with specific reflecting logic
    public void Run()
    {
        DisplayStartingMessage(); // Call base class method to display start message and set duration

        Console.WriteLine("\nConsider the following prompt:");
        string prompt = GetRandomPrompt(); // Get a random prompt
        DisplayPrompt(prompt); // Displays prompt and waits for user to press enter

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5); // Give user 5 seconds to prepare

        DisplayQuestions(); // This method will handle showing questions for the duration

        DisplayEndingMessage(); // Call base class method to display end message
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("When you have thought about the prompt, press enter to continue.");
        Console.ReadLine(); // Waits for user to press Enter
    }

    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        // Loop through questions for the duration of the activity
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"\n> {question} "); // Use WriteLine for each question
            ShowSpinner(7); // Pause for 7 seconds of reflection while showing spinner

            // Check if time is up after the spinner, before potentially trying another question
            if ((DateTime.Now - startTime).TotalSeconds >= _duration)
            {
                break; // Exit the loop if total duration is met
            }
        }
        Console.WriteLine(); // Ensure a new line after questions finish, for cleaner output
    }
}