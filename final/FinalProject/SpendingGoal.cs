public class SpendingGoal : Goal // Represents a financial goal to spend no more than a target amount by a deadline.
{
    private decimal _spentAmount; // Amount spent toward the goal
    public SpendingGoal(int id, decimal targetAmount, DateTime deadline, string description)
        : base(id, targetAmount, deadline, description) {}

    public void RecordSpending(decimal amount) // Records spending toward the goal.
    {
        _spentAmount += amount;
    }

    public override bool IsGoalMet() // Determines whether the financial goal has been met.
    {
        return _spentAmount <= TargetAmount;
    }

    public override string ProgressReport() // Generates a progress report for the goal.
    {
        return $"Spending Goal ('{Description}'): Target = {TargetAmount:C}, Spent = {_spentAmount:C}, Remaining = {TargetAmount - _spentAmount:C}, Deadline = {Deadline.ToShortDateString()}, Goal Met: {IsGoalMet()}";
    }
}