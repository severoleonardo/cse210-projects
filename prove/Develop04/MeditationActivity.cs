public class MeditationActivity : Activity
{
    // Constructor for MeditationActivity class
    public MeditationActivity() : base("Meditation Activity", "This activity will guide you through a calming meditation experience.")
    {
    }

    // Method to run the meditation activity
    public void Run()
    {
        DisplayStartingMessage(); // Display starting message
        Console.WriteLine("\nSit comfortably and close your eyes..."); // Prompt the user to get ready
        ShowCountDown(10); // Show countdown before starting meditation
        SilentMeditation(_duration); // Start silent meditation
        ShowSpinner(6); // Show a spinner after meditation ends for 6 cycles
        DisplayEndingMessage(); // Display ending message
    }

    // Method to perform silent meditation
    private void SilentMeditation(int duration)
    {
        Console.WriteLine("\nStarting silent meditation..."); // Display starting message for meditation
        ShowSpinner(duration); // Show a spinner for the meditation duration
        Console.WriteLine("\nYour meditation session is coming to an end. Thank you for taking this time for yourself."); // Show a message when the session is about to end
    }
}