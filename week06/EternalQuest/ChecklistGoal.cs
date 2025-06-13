// ChecklistGoal.cs
using System;

// Declare the same namespace as Program.cs
namespace EternalQuestProgram
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        // Constructor for creating a NEW Checklist Goal (starts with 0 completed)
        public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        // Constructor for LOADING a Checklist Goal from a file (restores its current completion count)
        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = amountCompleted;
        }

        // Overrides the base method to increment the completion count and potentially award bonus points.
        public override int RecordEvent()
        {
            if (_amountCompleted < _target)
            {
                _amountCompleted++;
                int earnedPoints = _points;

                if (_amountCompleted == _target)
                {
                    earnedPoints += _bonus; // Add bonus if the target count is reached
                    Console.WriteLine($"\nCongratulations! You have completed the goal: '{_shortName}' and earned a bonus of {_bonus} points!");
                }
                Console.WriteLine($"Event recorded for '{_shortName}'. You earned {_points} points.");
                return earnedPoints;
            }
            else
            {
                Console.WriteLine($"\nYou have already fully completed the checklist goal: '{_shortName}'. No additional points awarded.");
                return 0; // Already fully complete, no more points from recording
            }
        }

        // Overrides the base method to determine if the checklist goal is fully complete.
        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        // Overrides the base method to display progress (e.g., "Completed X/Y times") and status.
        public override string GetDetailsString()
        {
            string statusSymbol = IsComplete() ? "[X]" : "[ ]";
            return $"{statusSymbol} {_shortName} ({_description}) -- Currently completed {_amountCompleted}/{_target} times";
        }

        // Overrides the base method to provide a string format for saving.
        // Format: ChecklistGoal:name,description,points,target,bonus,amountCompleted
        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
        }
    }
}