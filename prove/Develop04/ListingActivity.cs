public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity","Helps you reflect on the good things in your life by listing as many as you can in a certain area." )
    {
        _prompts = new List<string> { "Who are people that you appreciate?", "What are personal strengths of yours?" };
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();
        GetListFromUser();
        DisplayEndingMessage();
    }

    private void GetRandomPrompt()
    {
        Console.WriteLine(_prompts[new Random().Next(0, _prompts.Count)]);
    }

    private void GetListFromUser()
    {
        Console.WriteLine("Enter as many items as you can. When you are done, press Enter without typing anything.");
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "")
            {
                break;
            }
            _count++;
        }
        Console.WriteLine($"You listed {_duration} items.");
    }
}
