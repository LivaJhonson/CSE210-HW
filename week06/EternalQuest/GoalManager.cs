// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO; // Required for file operations

// Declare the same namespace as Program.cs
namespace EternalQuestProgram
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        // Constructor: Initializes the list of goals and sets the initial score to 0.
        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        // The main method that runs the program's menu loop.
        public void StartProgram()
        {
            int choice = 0;
            // Loop until the user chooses to quit (option 6)
            while (choice != 6)
            {
                DisplayPlayerInfo(); // Always display the current score
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Record Event");
                Console.WriteLine("  4. Save Goals");
                Console.WriteLine("  5. Load Goals");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");

                // Basic input validation for menu choice
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateGoal();
                            break;
                        case 2:
                            ListGoals();
                            break;
                        case 3:
                            RecordEvent();
                            break;
                        case 4:
                            SaveGoals();
                            break;
                        case 5:
                            LoadGoals();
                            break;
                        case 6:
                            Console.WriteLine("\nThank you for using the Eternal Quest Program. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                // Pause and clear console for better user flow, unless quitting
                if (choice != 6)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey(true); // 'true' prevents the key from being displayed
                    Console.Clear();
                }
            }
        }

        // Displays the player's current total score.
        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nYou currently have {_score} points.");
        }

        // Lists all goals, showing their status and progress.
        public void ListGoals()
        {
            Console.WriteLine("\n--- Your Goals ---");
            if (_goals.Count == 0)
            {
                Console.WriteLine("  No goals currently. Create some to start your quest!");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
            }
            Console.WriteLine("------------------");
        }

        // Prompts the user for details and creates a new goal of the chosen type.
        public void CreateGoal()
        {
            Console.WriteLine("\n--- Create New Goal ---");
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string goalTypeChoice = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            int points;
            Console.Write("What is the amount of points associated with this goal? ");
            while (!int.TryParse(Console.ReadLine(), out points) || points < 0)
            {
                Console.Write("Invalid input. Please enter a non-negative whole number for points: ");
            }

            Goal newGoal = null;
            switch (goalTypeChoice)
            {
                case "1": // Simple Goal
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2": // Eternal Goal
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3": // Checklist Goal
                    int target;
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
                    {
                        Console.Write("Invalid input. Please enter a positive whole number for target count: ");
                    }

                    int bonus;
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
                    {
                        Console.Write("Invalid input. Please enter a non-negative whole number for bonus points: ");
                    }
                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid goal type selected. No goal was created.");
                    break;
            }

            if (newGoal != null)
            {
                _goals.Add(newGoal);
                Console.WriteLine("\nGoal created successfully!");
            }
        }

        // Allows the user to select a goal and record an event for it, updating their score.
        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("\nNo goals available to record an event for. Please create some first!");
                return;
            }

            Console.WriteLine("\n--- Record an Event ---");
            Console.WriteLine("Which goal did you accomplish?");
            for (int i = 0; i < _goals.Count; i++)
            {
                // Access the name using the public property 'ShortName'
                Console.WriteLine($"  {i + 1}. {_goals[i].ShortName}");
            }
            Console.Write("Enter the number of the goal you accomplished: ");

            if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
            {
                int pointsEarned = _goals[goalIndex - 1].RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"\nYou gained a total of {pointsEarned} points from this event!");
                DisplayPlayerInfo(); // Show updated score immediately
            }
            else
            {
                Console.WriteLine("Invalid goal number. Please select a valid number from the list.");
            }
        }

        // Saves the current score and all goals to a text file.
        public void SaveGoals()
        {
            Console.Write("What is the filename for saving your goals (e.g., mygoals.txt)? ");
            string filename = Console.ReadLine();

            try
            {
                // Using a 'using' block ensures the StreamWriter is properly closed.
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    outputFile.WriteLine(_score); // Save the current score on the first line

                    // Iterate through each goal and save its string representation
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine($"\nGoals and score saved successfully to '{filename}'!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred while saving goals: {ex.Message}");
                Console.WriteLine("Please check file permissions or provide a valid filename.");
            }
        }

        // Loads goals and the score from a specified text file.
        public void LoadGoals()
        {
            Console.Write("What is the filename for loading your goals (e.g., mygoals.txt)? ");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                try
                {
                    _goals.Clear(); // Clear existing goals before loading new ones
                    string[] lines = File.ReadAllLines(filename); // Read all lines into an array

                    // The first line is always the score
                    _score = int.Parse(lines[0]);
                    Console.WriteLine($"\nLoaded score: {_score} points.");

                    // Process subsequent lines to reconstruct goal objects
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(':'); // Split by the goal type separator (e.g., "SimpleGoal:...")
                        string goalType = parts[0];
                        string[] goalData = parts[1].Split(','); // Split by comma for individual attributes

                        string name = goalData[0];
                        string description = goalData[1];
                        int points = int.Parse(goalData[2]);

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                bool isComplete = bool.Parse(goalData[3]);
                                _goals.Add(new SimpleGoal(name, description, points, isComplete));
                                break;
                            case "EternalGoal":
                                _goals.Add(new EternalGoal(name, description, points));
                                break;
                            case "ChecklistGoal":
                                int target = int.Parse(goalData[3]);
                                int bonus = int.Parse(goalData[4]);
                                int amountCompleted = int.Parse(goalData[5]);
                                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                                break;
                            default:
                                Console.WriteLine($"\nWarning: Unknown goal type '{goalType}' found in file. Skipping this goal.");
                                break;
                        }
                    }
                    Console.WriteLine($"Goals loaded successfully from '{filename}'!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: The file content is in an unexpected format. Could not parse data.");
                    Console.WriteLine("Please ensure the file is not corrupted and matches the expected save format.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("\nError: The file content is incomplete or malformed. Could not parse data.");
                    Console.WriteLine("This might happen if the file was not saved correctly or was manually altered.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn unexpected error occurred while loading goals: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"\nFile '{filename}' not found. Please ensure the filename is correct and the file exists.");
            }
        }
    }
}