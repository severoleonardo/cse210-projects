using System;
using System.IO;

namespace GoalTracker
{
    public class ChecklistGoal : Goal
    {
        private int _numberOfTimesToComplete = 0;
        private int _numberOfTimesCheckedOff = 0;
        private int _completionBonus = 0;

        public ChecklistGoal() : base()
        {
            Console.WriteLine("Enter how many times must the checklist goal be completed for a bonus? ");
            _numberOfTimesToComplete = Program.SafeParse(Console.ReadLine(), 0, int.MaxValue);
            Console.WriteLine($"What is the bonus point reward once it is completed {_numberOfTimesToComplete} times? ");
            _completionBonus = Program.SafeParse(Console.ReadLine(), 0, int.MaxValue);
        }

        public ChecklistGoal(StreamReader reader) : base(reader)
        {
            _numberOfTimesToComplete = int.Parse(reader.ReadLine());
            _numberOfTimesCheckedOff = int.Parse(reader.ReadLine());
            _completionBonus = int.Parse(reader.ReadLine());
        }        

        public override void Complete()
        {
            if (!_isCompleted)
            {
                _numberOfTimesCheckedOff++;
                _pointsEarned += _pointsForEachCompletion;

                if (_numberOfTimesCheckedOff >= _numberOfTimesToComplete)
                {
                    _isCompleted = true;
                    _pointsEarned += _completionBonus;
                    Console.WriteLine($"Checklist goal completed {_numberOfTimesToComplete} times. Bonus earned: {_completionBonus}.");
                }
            }
        }

        protected override string GetFriendlyCompleteActionDescription() => "each time you accomplish this goal";

        protected override string GetFriendlyGoalTypeName() => "checklist goal";

        public override string GetCompleteDisplayString() => $"{base.GetCompleteDisplayString()} {GetProgressStatus()}";

        private string GetProgressStatus() => $"Completed {_numberOfTimesCheckedOff}/{_numberOfTimesToComplete} times.";

        public override void WriteToStreamWriter(StreamWriter writer)
        {
            base.WriteToStreamWriter(writer);
            writer.WriteLine(_numberOfTimesToComplete);
            writer.WriteLine(_numberOfTimesCheckedOff);
            writer.WriteLine(_completionBonus);
        }   
    }
}
