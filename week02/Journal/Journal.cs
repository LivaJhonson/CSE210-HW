// Journal.cs
using System;
using System.Collections.Generic; // Required for List
using System.IO;                  // Required for File operations (StreamReader, StreamWriter, File)

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
        // EXCEEDING REQUIREMENTS: Provides clear feedback if the journal is empty.
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n--- Journal is currently empty. Write some entries first! ---");
            return;
        }

        Console.WriteLine("\n--- Displaying Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display(); // Call the Display method for each entry
        }
        Console.WriteLine("--- End of Journal ---"); // EXCEEDING REQUIREMENTS: Clear end marker.
    }

    /// <summary>
    /// Saves the current journal entries to a specified file.
    /// Each entry is saved as a single line with a custom separator.
    /// </summary>
    /// <param name="filename">The name of the file to save to.</param>
    public void SaveToFile(string filename)
    {
        Console.WriteLine($"\nAttempting to save to file: {filename}...");
        // EXCEEDING REQUIREMENTS: Using a unique and unlikely separator ("~~~").
        // This simplifies parsing by avoiding common characters like commas,
        // which might appear in the user's response, thus fulfilling the simplification
        // instruction while ensuring reliable data separation.
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
            // EXCEEDING REQUIREMENTS: Provides explicit success message to the user.
            Console.WriteLine($"Journal saved successfully to '{filename}'!");
        }
        // EXCEEDING REQUIREMENTS: Robust error handling for file operations.
        // Catches general exceptions during the save process.
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: An unexpected issue occurred while saving the journal: {ex.Message}");
            Console.WriteLine("Please check file permissions or if the path is valid.");
        }
    }

    /// <summary>
    /// Loads journal entries from a specified file, replacing any existing entries.
    /// </summary>
    /// <param name="filename">The name of the file to load from.</param>
    public void LoadFromFile(string filename)
    {
        Console.WriteLine($"\nAttempting to load from file: {filename}...");
        string separator = "~~~"; // Must match the separator used for saving

        // Clear existing entries before loading new ones, as per requirement
        _entries.Clear();

        try
        {
            // EXCEEDING REQUIREMENTS: Using File.Exists() for a more user-friendly check
            // before attempting to read the file, preventing a harsher error message.
            if (!File.Exists(filename))
            {
                Console.WriteLine($"ERROR: File '{filename}' not found. Please ensure the filename is correct and the file exists.");
                return; // Exit method if file doesn't exist
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                // Split each line by the separator. StringSplitOptions.None is important
                // to handle cases where response might be empty, ensuring all parts are captured.
                string[] parts = line.Split(new string[] { separator }, StringSplitOptions.None);

                // EXCEEDING REQUIREMENTS: Input validation for loaded data.
                // Ensures that only correctly formatted lines (exactly 3 parts) are processed,
                // preventing errors from malformed data in the file.
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
                    // EXCEEDING REQUIREMENTS: Provides feedback for malformed lines in the file.
                    Console.WriteLine($"WARNING: Skipping malformed line in '{filename}': '{line}' (Incorrect number of parts).");
                }
            }
            // EXCEEDING REQUIREMENTS: Provides explicit success message to the user.
            Console.WriteLine($"Journal loaded successfully from '{filename}'! Total entries: {_entries.Count}");
        }
        // EXCEEDING REQUIREMENTS: Catches specific file not found exception for clearer user feedback.
        catch (FileNotFoundException)
        {
            // This specific catch might be redundant due to File.Exists() check,
            // but is good practice for very robust error handling in case of race conditions.
            Console.WriteLine($"ERROR: File '{filename}' not found. Please check the filename.");
        }
        // EXCEEDING REQUIREMENTS: Catches any other unexpected errors during loading.
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: An unexpected issue occurred while loading the journal: {ex.Message}");
            Console.WriteLine("Please ensure the file is not corrupted and is accessible.");
        }
    }
}