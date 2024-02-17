public abstract class Goal
{
    public int Id { get; protected set; }
    public decimal TargetAmount { get; protected set; }
    public DateTime Deadline { get; protected set; }
    public string Description { get; protected set; }

    protected Goal(int id, decimal targetAmount, DateTime deadline, string description)
    {
        Id = id;
        TargetAmount = targetAmount;
        Deadline = deadline;
        Description = description;
    }

    public abstract bool IsGoalMet();
    public abstract string ProgressReport();
}
