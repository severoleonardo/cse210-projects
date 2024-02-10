public class ListingActivity : Activity
{
    // Fields to store the count of listed items and a list of prompts
    private int _count;
    private List<string> _prompts;

    // Constructor to initialize ListingActivity with its name and description
    public ListingActivity() : base("Listing Activity","This activity will help you reflect on the good things in your life by listing as many as you can in a certain area." )
    {
        // Initialize the list of prompts with various reflection prompts
        _prompts = new List<string> 
        { 
            "\n--- Who are people that you appreciate? ---", 
            "\n--- What are personal strengths of yours? ---", 
            "\n--- Who are people that you have helped this week? ---", 
            "\n--- When have you felt the Holy Ghost this month? ---", 
            "\n--- Who are some of your personal heroes? ---" 
        };
    }

    // Method to run the ListingActivity
    public void Run()
    {
        DisplayStartingMessage(); // Display starting message
        GetRandomPrompt(); // Display a random reflection prompt
        ShowSpinner(6); // Show a spinner for 6 cycles
        GetListFromUser(); // Prompt the user to list items
        DisplayEndingMessage(); // Display ending message
        ShowSpinner(6); // Show a spinner after completing the activity
    }

    // Method to display a random reflection prompt
    private void GetRandomPrompt()
    {
        Console.WriteLine(_prompts[new Random().Next(0, _prompts.Count)]);
    }

     // Method to get a list of items from the user
    private void GetListFromUser()
    {
        Console.WriteLine("\nList as many items as you can. \n\n    When you are done, press Enter without typing anything.");
        while (true)
        {
            string input = Console.ReadLine(); // Get user input
            if (input == "") // If user presses Enter without typing anything, exit loop
            {
                break;
            }
            _count++; // Increment the count of listed items
        }
        Console.WriteLine($"You listed {_count} items."); // Display the count of listed items
    }
}
