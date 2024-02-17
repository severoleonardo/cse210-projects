using System.IO;

namespace GoalTracker
{
    public class EternalGoal : Goal 
    {
        public EternalGoal() : base()
        {
        }

        public EternalGoal(StreamReader reader) : base(reader)
        {
        }

        public override void Complete()
        {
            // Eternal goals never reach a "completed" state in the traditional sense
            _isCompleted = false; // This line is somewhat redundant given the goal's nature but clarifies intent
            _pointsEarned += _pointsForEachCompletion;
            Console.WriteLine($"{_name} repeated. Points earned: {_pointsForEachCompletion}.");
        }

        protected override string GetFriendlyCompleteActionDescription()
        {
            return "each time this habit is repeated";
        }

        protected override string GetFriendlyGoalTypeName()
        {
            return "eternal habit";
        }
    }
}
