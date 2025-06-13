// Goal.cs
using System;

// Declare a namespace for your project to organize classes
namespace EternalQuestProgram
{
    public abstract class Goal
    {
        // Revert to protected fields. Derived classes can directly access these.
        protected string _shortName;
        protected string _description;
        protected int _points;

        // Add public properties (getters) for external access (like GoalManager).
        // This is the correct way for non-derived classes to read these values.
        public string ShortName { get { return _shortName; } }
        public string Description { get { return _description; } }
        public int Points { get { return _points; } }

        // Constructor for the base Goal class
        protected Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        // Abstract method to be overridden by derived classes for recording an event.
        // It returns the points earned from that specific event.
        public abstract int RecordEvent();

        // Virtual method to check if the goal is complete.
        // Default implementation returns false, as EternalGoals never complete.
        // SimpleGoal and ChecklistGoal will override this.
        public virtual bool IsComplete()
        {
            return false;
        }

        // Virtual method to get a string representation of the goal's details for display in a list.
        // This includes status (e.g., [X] or [ ]).
        // ChecklistGoal will override this to add its specific progress.
        public virtual string GetDetailsString()
        {
            string statusSymbol = IsComplete() ? "[X]" : "[ ]";
            // Derived classes will access _shortName and _description directly,
            // but for the base class, we can use the properties or the fields.
            // Using properties here is fine and consistent with external access.
            return $"{statusSymbol} {ShortName} ({Description})";
        }

        // Abstract method to get a string representation of the goal's data for saving to a file.
        // Each derived class will implement this to provide its specific data format.
        public abstract string GetStringRepresentation();

        // The GetPoints method can remain as an alternative way to get points if preferred.
        // Public property `Points` is also available.
        // public int GetPoints()
        // {
        //     return _points;
        // }
    }
}