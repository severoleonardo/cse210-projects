public class ReflectingActivity : Activity
{
    // Fields to store lists of prompts and reflection questions
    private List<string> _prompts;
    private List<string> _question;

    // Constructor to initialize ReflectingActivity with its name and description
    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times when you have shown strength and resilience.")
    {
        // Initialize the list of prompts with various reflection prompts
        _prompts = new List<string> 
        { 
            "\n--- Think of a time when you stood up for someone else. ---\n", 
            "\n--- Think of a time when you did something really difficult. ---\n",
            "\n--- Think of a time when you helped someone in need. ---\n",
            "\n--- Think of a time when you did something truly selfless. ---\n"
        };

        // Initialize the list of questions to ask after reflecting on a prompt
        _question = new List<string> 
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    // Method to run the ReflectingActivity
    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        ShowSpinner(9);
        DisplayEndingMessage();
    }

    // Method to display a random reflection prompt
    private void DisplayPrompt()
    {
        Console.WriteLine(_prompts[new Random().Next(0, _prompts.Count)]);
        PauseForSeconds(8);
    }

    // Method to display reflection questions
    private void DisplayQuestions()
    {
        foreach (string question in _question)
        {
            Console.WriteLine(question); // Display reflection question
            Console.WriteLine("..."); // Pause for reflection
            PauseForSeconds(9); // Pause for 9 seconds
        }
    }
}
