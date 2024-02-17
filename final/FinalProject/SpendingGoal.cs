public class SpendingGoal : Goal
{
    private decimal spentAmount; // Amount spent toward the goal
    public SpendingGoal(int id, decimal targetAmount, DateTime deadline, string description)
        : base(id, targetAmount, deadline, description) {}

    public void RecordSpending(decimal amount)
    {
        spentAmount += amount;
    }

    public override bool IsGoalMet()
    {
        // Implementation specific to SpendingGoal
        return spentAmount <= TargetAmount;
    }

    public override string ProgressReport()
    {
        return $"Spending Goal ('{Description}'): Target = {TargetAmount:C}, Spent = {spentAmount:C}, Remaining = {TargetAmount - spentAmount:C}, Deadline = {Deadline.ToShortDateString()}, Goal Met: {IsGoalMet()}";
    }
}