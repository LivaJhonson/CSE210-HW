// EternalGoal.cs
using System;

// Declare the same namespace as Program.cs
namespace EternalQuestProgram
{
    public class EternalGoal : Goal
    {
        // Constructor (no unique member variables for eternal goals, inherits from base Goal)
        public EternalGoal(string name, string description, int points) : base(name, description, points)
        {
            // No specific initialization needed for EternalGoal beyond the base class constructor
        }

        // Overrides the base method to always award points when recorded, as it's never truly "complete".
        public override int RecordEvent()
        {
            Console.WriteLine($"\nEvent recorded for '{_shortName}'. You earned {_points} points.");
            return _points;
        }

        // Overrides the base method to always return false, as eternal goals are never complete by definition.
        public override bool IsComplete()
        {
            return false;
        }

        // Overrides the base method to display '--' indicating it's an ongoing goal.
        public override string GetDetailsString()
        {
            return $"-- {_shortName} ({_description})";
        }

        // Overrides the base method to provide a string format for saving.
        // Format: EternalGoal:name,description,points
        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_shortName},{_description},{_points}";
        }
    }
}