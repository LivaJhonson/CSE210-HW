// Journal.cs
using System;
using System.Collections.Generic; // Required for List
using System.IO;                  // Required for File operations (StreamReader, StreamWriter)

public class Journal
{
    public List<Entry> _entries; // A list to hold all the journal entries

    /// <summary>
    /// Initializes a new instance of the Journal class.
    /// </summary>
    public Journal()
    {
        _entries = new List<Entry>(); // Initialize the list in the constructor
    }

    /// <summary>
    /// Adds a new journal entry to the list of entries.
    /// </summary>
    /// <param name="newEntry">The Entry object to add.</param>
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry); // Simply adds a new entry to the list
    }

    /// <summary>
    /// Displays all existing journal entries to the console.
    /// </summary>
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty. No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display(); // Call the Display method for each entry
        }
    }

    /// <summary>
    /// Saves the current journal entries to a specified file.
    /// Each entry is saved as a single line with a custom separator.
    /// </summary>
    /// <param name="filename">The name of the file to save to.</param>
    public void SaveToFile(string filename)
    {
        Console.WriteLine($"Saving to file: {filename}...");
        // Use a simple separator as per simplification.
        // A unique character sequence is chosen to avoid conflicts with common text.
        string separator = "~~~";

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    // Write each entry as a single line, separated by our chosen separator
                    outputFile.WriteLine($"{entry._date}{separator}{entry._promptText}{separator}{entry._responseText}");
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads journal entries from a specified file, replacing any existing entries.
    /// </summary>
    /// <param name="filename">The name of the file to load from.</param>
    public void LoadFromFile(string filename)
    {
        Console.WriteLine($"Loading from file: {filename}...");
        string separator = "~~~"; // Must match the separator used for saving

        // Clear existing entries before loading new ones, as per requirement
        _entries.Clear();

        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                // Split each line by the separator. StringSplitOptions.None is important
                // to handle cases where response might be empty.
                string[] parts = line.Split(new string[] { separator }, StringSplitOptions.None);

                // Ensure we have exactly 3 parts (date, prompt, response)
                if (parts.Length == 3)
                {
                    Entry newEntry = new Entry
                    {
                        _date = parts[0],
                        _promptText = parts[1],
                        _responseText = parts[2]
                    };
                    _entries.Add(newEntry);
                }
                else
                {
                    Console.WriteLine($"Skipping malformed line: {line}");
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File '{filename}' not found. Please check the filename.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }
}