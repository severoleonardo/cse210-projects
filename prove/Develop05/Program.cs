using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    public class Program
    {
        private static List<Goal> _goals = new List<Goal>();

        public static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                DisplayGoalsAndScore();

                Console.WriteLine(
@"Menu Options:
1. Create New Goal
2. List Goals
3. Save Goals
4. Load Goals
5. Record Event
6. Quit
Select a choice from the menu: ");

                int choice = SafeParse(Console.ReadLine(), 0, 6);

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        DisplayGoalsAndScore();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void CreateGoal()
        {
            Console.WriteLine(
@"The types of goals are:
1. Simple Goal
2. Eternal Goal
3. Checklist Goal
Enter your choice: ");
            int choice = SafeParse(Console.ReadLine(), 1, 3);

            switch (choice)
            {
                case 1:
                    _goals.Add(new SimpleGoal());
                    break;
                case 2:
                    _goals.Add(new EternalGoal());
                    break;
                case 3:
                    _goals.Add(new ChecklistGoal());
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal creation cancelled.");
                    return;
            }
            Console.WriteLine("Goal created successfully.");
        }

        private static void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals to record events for.");
                return;
            }

            Console.WriteLine("Select a goal to record an event for:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetCompleteDisplayString()}");
            }
            int selectedGoal = SafeParse(Console.ReadLine(), 1, _goals.Count) - 1;
            _goals[selectedGoal].Complete();
        }

        private static void DisplayGoalsAndScore()
        {
            Console.Clear();
            int totalScore = 0;
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetCompleteDisplayString());
                totalScore += goal.GetPointsEarned();
            }
            Console.WriteLine($"Total Score: {totalScore}\n");
        }

        private static void SaveGoals()
        {
            Console.WriteLine("Enter filename to save goals:");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetType().Name);
                    goal.WriteToStreamWriter(writer);
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }

        private static void LoadGoals()
        {
            Console.WriteLine("Enter filename to load goals from:");
            string filename = Console.ReadLine();
            _goals.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string goalType = reader.ReadLine();
                    switch (goalType)
                    {
                        case "SimpleGoal":
                            _goals.Add(new SimpleGoal(reader));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(reader));
                            break;
                        case "ChecklistGoal":
                            _goals.Add(new ChecklistGoal(reader));
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }

        public static int SafeParse(string input, int min, int max)
        {
            bool success = int.TryParse(input, out int result);
            return success && result >= min && result <= max ? result : 0;
        }
    }
}
