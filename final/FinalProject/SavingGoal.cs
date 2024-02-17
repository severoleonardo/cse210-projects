public class SavingGoal : Goal
{
    private decimal savedAmount; // Amount saved towards the goal
    public SavingGoal(int id, decimal targetAmount, DateTime deadline, string description)
        : base(id, targetAmount, deadline, description) {}

    public void AddSavings(decimal amount)
    {
        savedAmount += amount;
    }
    
    public override bool IsGoalMet()
    {
        return savedAmount >= TargetAmount;
    }

    public override string ProgressReport()
    {
        return $"Saving Goal ('{Description}'): Target = {TargetAmount:C}, Saved = {savedAmount:C}, Remaining = {TargetAmount - savedAmount:C}, Deadline = {Deadline.ToShortDateString()}, Goal Met: {IsGoalMet()}";
    }
}