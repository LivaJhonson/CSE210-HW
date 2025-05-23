// Entry.cs
using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _responseText;

    /// <summary>
    /// Displays the journal entry to the console.
    /// </summary>
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_responseText}");
        Console.WriteLine(); // Add an empty line for better readability between entries
    }
}