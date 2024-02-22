public abstract class Goal // Represents a financial goal with a target amount, deadline, and description.
{
    public int Id { get; protected set; }
    public decimal TargetAmount { get; protected set; }
    public DateTime Deadline { get; protected set; }
    public string Description { get; protected set; }

    // Protected constructor initializes a new instance of the Goal class.
    protected Goal(int id, decimal targetAmount, DateTime deadline, string description)
    {
        Id = id;
        TargetAmount = targetAmount;
        Deadline = deadline;
        Description = description;
    }

    public abstract bool IsGoalMet(); // Determines whether the financial goal has been met.
    public abstract string ProgressReport(); // Generates a progress report for the goal.
}
