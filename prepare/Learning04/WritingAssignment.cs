public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic) // Call base constructor
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"Title: {_title} by {_studentName}"; // Access studentName directly
    }
}