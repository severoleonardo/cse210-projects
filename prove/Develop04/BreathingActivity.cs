public class BreathingActivity : Activity
{
    // Constructor to initialize BreathingActivity with its name and description
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breath.")
    {
    }

    // Method to run the BreathingActivity
    public void Run()
    {
        DisplayStartingMessage(); // Display starting message
        // Loop to guide the user through breathing in and out
        for (int i = 0; i < _duration / 2; i++)
        {
            Console.WriteLine("\n\nTake a deep breath in..."); // Prompt the user to breathe in
            ShowCountDown(5); // Show countdown for 5 seconds
            Console.WriteLine("\nNow slowly exhale..."); // Prompt the user to breathe out
            ShowCountDown(5); // Show countdown for 5 seconds
        }

        DisplayEndingMessage(); // Display ending message
    }
}
