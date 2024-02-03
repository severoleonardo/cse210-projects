public class Assignment
{
    protected string _studentName; // Use protected for access in derived classes
    protected string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} is working on {_topic}";
    }
}