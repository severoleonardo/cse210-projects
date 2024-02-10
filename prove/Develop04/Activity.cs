public class Activity
{
     // Fields to store activity name, description, and duration
    protected string _name;
    protected string _description;
    protected int _duration;

    // Constructor to initialize activity name and description
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }   

    // Method to display starting message and prompt user to begin
    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"\nWelcome to {_name}."); // Display activity name
        Console.WriteLine($"\n{_description}"); // Display activity description
        SetDuration(); // Prompt user to set the duration

        Console.WriteLine("\nAre you ready to begin? (y/n)");
        string confirmation = Console.ReadLine().ToLower();
        
         if (confirmation == "y")
        {
            Console.WriteLine("\nGreat! Let's get started...");
            PrepareToBegin();  
            ShowSpinner(6); // Show spinner while preparing to begin
        }
        else
        {
            Console.WriteLine("\nOkay, no worries. Come back when you're ready.");
        }
    }

    // Method to prompt user to set duration of the activity
    protected virtual void SetDuration()
    {
        Console.Write("\nEnter the duration in seconds: ");
        int.TryParse(Console.ReadLine(), out _duration);
    }

    // Method to perform additional preparation logic before beginning the activity
    protected void PrepareToBegin()
    {
    }

    // Method to display ending message after completing the activity
    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"\n\nGood job! You have completed {_name} in {_duration} seconds.");
        ShowSpinner(6); // Show spinner after completing the activity
        // PauseForSeconds(5);
    }

    // Method to display a spinner while waiting or performing a task
    protected virtual void ShowSpinner(int cicles)
    {
        string[] spinner = { "/", "-", "\\", "|" }; // Spinner characters
        int currentSpinner = 0; // Index of the current spinner character
        
        for (int i = 0; i < cicles; i++)
        {
            Console.Write(spinner[currentSpinner]); // Display the current spinner character
            Thread.Sleep(500);
            Console.Write("\b \b"); // Erase the + character
            currentSpinner = (currentSpinner + 1) % spinner.Length; // Move to the next spinner character
        }
    }

    // Method to display a countdown timer
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the + character
        }
    }

    // Method to pause execution for a specified number of seconds
    protected void PauseForSeconds(int seconds)
    {
        Thread.Sleep(seconds * 1000);
    }    
}