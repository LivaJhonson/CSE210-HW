// PromptGenerator.cs
using System;
using System.Collections.Generic; // Required for List

public class PromptGenerator
{
    public List<string> _prompts; // A list to hold our prompts

    /// <summary>
    /// Initializes a new instance of the PromptGenerator class,
    /// populating the list of prompts.
    /// </summary>
    public PromptGenerator()
    {
        // EXCEEDING REQUIREMENTS: More than 5 prompts are included here.
        // This provides more variety for the user, enhancing the journaling experience.
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was something new you learned today?",
            "What is one thing you are grateful for today?",
            "Describe a challenge you faced today and how you overcame it.",
            "What is a goal you have for tomorrow?"
        };
    }

    /// <summary>
    /// Retrieves a random prompt from the list of available prompts.
    /// </summary>
    /// <returns>A randomly selected prompt string.</returns>
    public string GetRandomPrompt()
    {
        Random random = new Random(); // Create a new Random object
        int index = random.Next(0, _prompts.Count); // Get a random index within the bounds of the list
        return _prompts[index]; // Return the prompt at the random index
    }
}