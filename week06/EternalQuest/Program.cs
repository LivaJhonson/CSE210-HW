// Program.cs
using System;

// Declare a namespace for your project to organize classes
namespace EternalQuestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear(); // Clears the console for a cleaner start
            Console.WriteLine("Welcome to the Eternal Quest Program!\n");

            // Instantiate GoalManager and start the main program loop
            GoalManager goalManager = new GoalManager();
            goalManager.StartProgram();
            /*
             * Exceeding Requirements:
             *
             * 1. Clearer Console Output and User Experience:
             * - Implemented `Console.Clear()` before displaying the main menu and after each action to ensure a clean interface.
             * - Added "Press any key to continue..." prompts after most actions to give the user time to read output before the screen clears, improving flow.
             * - Provided more descriptive messages to guide the user (e.g., "Goals and score saved successfully to 'filename'!", "No goals currently. Create some to start your quest!").
             *
             * 2. Robust Input Validation:
             * - Added `int.TryParse()` for all numeric inputs (menu choices, points, target, bonus, goal selection) to prevent crashes from non-numeric input.
             * - Included `while` loops for re-prompting on invalid numeric inputs (e.g., ensuring points, target, and bonus are non-negative or positive as required).
             * - Validated user's goal selection in `RecordEvent` to ensure it's within the valid range of available goals.
             *
             * 3. Enhanced Goal Listing and Feedback:
             * - The `ListGoals` method now explicitly informs the user with a friendly message if there are no goals currently created.
             * - Specific feedback is given when a SimpleGoal is already complete (`"Goal 'X' has already been completed."`).
             * - Specific feedback for ChecklistGoal when it's fully completed (`"You have already fully completed the checklist goal: 'X'."`).
             *
             * 4. Comprehensive File Handling with Error Handling:
             * - Implemented `try-catch` blocks around file saving (`SaveGoals`) and loading (`LoadGoals`) operations.
             * - Catches general `Exception` for saving to provide a generic error message if writing fails (e.g., permissions issues).
             * - Catches specific `FormatException` and `IndexOutOfRangeException` during loading to provide more precise error messages if the file content is corrupted or malformed.
             * - Included a check `File.Exists(filename)` before attempting to load a file, giving a user-friendly message if the file doesn't exist.
             * - Added a warning for `LoadGoals` if an unknown goal type is encountered in the saved file, gracefully skipping that line instead of crashing.
             *
             * 5. User-Friendly Prompts:
             * - Improved the clarity and directness of prompts for goal creation (e.g., "What is the name of your goal?") and event recording (e.g., "Which goal did you accomplish?").
             */
        }
    }
}