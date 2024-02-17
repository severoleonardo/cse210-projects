using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    public abstract class Goal
    {
        protected string _name = "";
        protected string _shortDescription = "";
        protected bool _isCompleted = false;
        protected int _pointsForEachCompletion = 0;
        protected int _pointsEarned = 0;

        // Default constructor for creating a goal with user input
        public Goal()
        {
            Console.WriteLine($"What is the name of your {GetFriendlyGoalTypeName()}? ");
            _name = Console.ReadLine();

            Console.WriteLine($"What is a short description of your {GetFriendlyGoalTypeName()}? ");
            _shortDescription = Console.ReadLine();

            Console.WriteLine($"Enter the points awarded for {GetFriendlyCompleteActionDescription()}? ");
            _pointsForEachCompletion = Program.SafeParse(Console.ReadLine(), 0, int.MaxValue);
        }

        // Constructor for loading a goal from a file
        public Goal(StreamReader reader)
        {
            _name = reader.ReadLine();
            _shortDescription = reader.ReadLine();
            _pointsForEachCompletion = int.Parse(reader.ReadLine());
            _isCompleted = bool.Parse(reader.ReadLine());
            _pointsEarned = int.Parse(reader.ReadLine());
        }

        public int GetPointsEarned() => _pointsEarned;

        public string GetName() => _name;

        public bool IsComplete() => _isCompleted;

        protected string CompletedCheckbox() => _isCompleted ? "[X]" : "[ ]";

        public virtual string GetCompleteDisplayString() => $"{CompletedCheckbox()} {_name} ({_shortDescription})";

        public abstract void Complete();

        protected abstract string GetFriendlyGoalTypeName();

        protected abstract string GetFriendlyCompleteActionDescription();

        public virtual void WriteToStreamWriter(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_shortDescription);
            writer.WriteLine(_pointsForEachCompletion);
            writer.WriteLine(_isCompleted);
            writer.WriteLine(_pointsEarned);
        }
    }
}
