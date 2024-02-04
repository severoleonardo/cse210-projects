public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "Helps you relax by walking you through breathing in and out slowly.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        for (int i = 0; i < _duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in" : "Breathe out");
            PauseForSeconds(2);
        }

        DisplayEndingMessage();
    }
}
