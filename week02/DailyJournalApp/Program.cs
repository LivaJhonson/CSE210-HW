// Program.cs
using System;
// These usings are often included by default and are good practice for general C# projects
// using System.Collections.Generic;
// using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements: Added a comment in Program.cs to describe exceeded requirements.
        // This program demonstrates storing journal entries with custom prompts, dates, and responses.
        // It allows users to write new entries, display all entries, save the journal to a file,
        // and load a journal from a file.
        //
        // Exceeded Requirements for a 100% score:
        // - More than 5 prompts (PromptGenerator contains 8 prompts).
        // - Robust error handling for file operations (FileNotFoundException, general Exception).
        // - Clear user feedback messages for saving/loading success or failure.
        // - Enhanced readability with empty lines in Display method for entries and menu separation.
        // - Input validation for menu choices using int.TryParse().

        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;
        while (choice != 5) // Loop until the user chooses to Quit (option 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string input = Console.ReadLine();

            // TryParse safely converts string to int and checks if it was successful
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1: // Write a new entry
                        string randomPrompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine(randomPrompt);
                        Console.Write("> "); // Indicate user input area for their response
                        string response = Console.ReadLine();

                        // Get current date and format it as a short date string
                        string dateText = DateTime.Now.ToShortDateString();

                        // Create a new Entry object and populate its fields
                        Entry newEntry = new Entry
                        {
                            _date = dateText,
                            _promptText = randomPrompt,
                            _responseText = response
                        };
                        myJournal.AddEntry(newEntry); // Add the new entry to the journal
                        break;

                    case 2: // Display the journal
                        myJournal.DisplayAll();
                        break;

                    case 3: // Load journal from file
                        Console.Write("What is the filename? ");
                        string loadFilename = Console.ReadLine();
                        myJournal.LoadFromFile(loadFilename);
                        break;

                    case 4: // Save journal to file
                        Console.Write("What is the filename? ");
                        string saveFilename = Console.ReadLine();
                        myJournal.SaveToFile(saveFilename);
                        break;

                    case 5: // Quit the program
                        Console.WriteLine("Thank you for journaling. Goodbye!");
                        break;

                    default: // Handles numbers outside the 1-5 range
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else // Handles non-numeric input
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            Console.WriteLine(); // Add an empty line for better menu separation after each action
        }
    }
}
