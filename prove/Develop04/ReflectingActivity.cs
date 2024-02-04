public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _question;

    public ReflectingActivity() : base("Reflecting Activity", "Helps you reflect on times when you have shown strength and resilience.")
    {
        _prompts = new List<string> { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult."};
        _question = new List<string> 
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you feel when it was complete?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(_prompts[new Random().Next(0, _prompts.Count)]);
        PauseForSeconds(3);
    }

    private void DisplayQuestions()
    {
        foreach (string question in _question)
        {
            Console.WriteLine(question);
            PauseForSeconds(3);
        }
    }
}
