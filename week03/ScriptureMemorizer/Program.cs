// Program.cs
using System;
using System.Collections.Generic; // Although not directly used in Program.cs, good to keep if any logic moves here
using System.Linq; // For methods like All() if you move logic
using System.Threading; // For Thread.Sleep

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- Example Usage of Classes ---

            // 1. Create a Reference object
            Reference reference1 = new Reference("John", 3, 16);
            string verseText1 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
            Scripture scripture1 = new Scripture(reference1, verseText1);

            // You can uncomment and use a different scripture if you like
            // Reference reference2 = new Reference("Proverbs", 3, 5, 6);
            // string verseText2 = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
            // Scripture scripture2 = new Scripture(reference2, verseText2);

            Scripture currentScripture = scripture1; // Set which scripture to use

            string userInput = "";

            // Main program loop
            while (userInput.ToLower() != "quit" && !currentScripture.IsCompletelyHidden())
            {
                Console.Clear(); // Clear the console before each display
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

                userInput = Console.ReadLine();

                if (userInput.ToLower() == "quit")
                {
                    break; // Exit the loop if user types 'quit'
                }
                else if (!currentScripture.IsCompletelyHidden())
                {
                    // Hide 3 random words (you can adjust this number)
                    currentScripture.HideRandomWords(3);
                }
            }

            // Final display after loop ends
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());

            if (currentScripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden! You've memorized the scripture!");
            }
            else
            {
                Console.WriteLine("\nProgram ended. Good luck with your scripture memorization!");
            }

            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();
        }
    }
}