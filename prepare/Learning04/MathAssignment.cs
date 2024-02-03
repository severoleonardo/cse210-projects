public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string[] _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string[] problems ) : base(studentName, topic) // Call base constructor
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetMathHomeworkList()
    {
        return $"Section {_textbookSection} Problems: {string.Join(", ", _problems)}";
    }
}