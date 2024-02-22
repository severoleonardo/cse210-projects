public class SavingGoal : Goal // Represents a financial goal to save a target amount by a deadline.
{
    private decimal _savedAmount; // Amount saved towards the goal
    public SavingGoal(int id, decimal targetAmount, DateTime deadline, string description)
        : base(id, targetAmount, deadline, description) {}

    public void AddSavings(decimal amount)
    {
        _savedAmount += amount;
    }
    
    public override bool IsGoalMet()
    {
        return _savedAmount >= TargetAmount;
    }

    public override string ProgressReport()
    {
        return $"Saving Goal ('{Description}'): Target = {TargetAmount:C}, Saved = {_savedAmount:C}, Remaining = {TargetAmount - _savedAmount:C}, Deadline = {Deadline.ToShortDateString()}, Goal Met: {IsGoalMet()}";
    }
}