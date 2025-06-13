// SimpleGoal.cs
using System;

// Declare the same namespace as Program.cs
namespace EternalQuestProgram
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        // Constructor for creating a NEW Simple Goal (starts incomplete)
        public SimpleGoal(string name, string description, int points) : base(name, description, points)
        {
            _isComplete = false;
        }

        // Constructor for LOADING a Simple Goal from a file (restores its completion status)
        public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        // Overrides the base method to mark the goal as complete and return points.
        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                Console.WriteLine($"\n'{_shortName}' completed! You earned {_points} points.");
                return _points;
            }
            else
            {
                Console.WriteLine($"\nGoal '{_shortName}' has already been completed. No additional points awarded.");
                return 0;
            }
        }

        // Overrides the base method to report its actual completion status.
        public override bool IsComplete()
        {
            return _isComplete;
        }

        // Overrides the base method to display [X] if complete, [ ] if not.
        public override string GetDetailsString()
        {
            string statusSymbol = _isComplete ? "[X]" : "[ ]";
            return $"{statusSymbol} {_shortName} ({_description})";
        }

        // Overrides the base method to provide a string format for saving.
        // Format: SimpleGoal:name,description,points,isComplete
        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }
    }
}