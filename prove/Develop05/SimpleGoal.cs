using System.IO;

namespace GoalTracker
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal() : base() { }

        public SimpleGoal(StreamReader reader) : base(reader) { }

        public override void Complete()
        {
            if (!_isCompleted)
            {
                _isCompleted = true;
                _pointsEarned += _pointsForEachCompletion;
                Console.WriteLine($"{_name} completed. Points earned: {_pointsForEachCompletion}.");
            }
        }

        protected override string GetFriendlyCompleteActionDescription() => "completion";

        protected override string GetFriendlyGoalTypeName() => "one-time goal";
    }
}
