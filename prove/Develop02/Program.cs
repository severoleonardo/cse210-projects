class Program
{
    static void Main(string[] args)
    {
        // Create a new Journal instance to manage entries
        Journal journal = new Journal();
        int choice;

        // Welcome message
        Console.WriteLine("\nWelcome to the journal.app!");

        do
        {
             // Display menu options to the user
            Console.WriteLine("\nPlease select one of the following options: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");

            // Prompt the user for their choice
            Console.Write("\nAll right! What would you like to do? ");
            
            // Validate and process user input
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                         // User chose to write a new entry
                        Entry newEntry = new Entry();

                         // Generate a random prompt for the user
                        string randomPrompt = PromptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nrandomPrompt: {randomPrompt}");
                        
                        // Set the prompt, get user's response, set the date, and add the entry to the journal
                        newEntry.SetPromptText(randomPrompt);
                        newEntry.SetEntryText(GetUserResponse());
                        newEntry.SetDate(GetCurrentDate());
                        journal.AddEntry(newEntry);
                        break;

                    case 2:
                        // User chose to display all entries in the journal
                        journal.DisplayAll();
                        break;

                    case 3:
                        // User chose to save the journal to a file
                        Console.Write("Enter the file name to save: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        break;

                    case 4:
                        // User chose to load the journal from a file
                        Console.Write("Enter the file name to load: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        break;
                }
            }
        } while (choice != 5);
    }

    static string GetUserResponse()
    {
        Console.Write("Write your response: ");
        return Console.ReadLine();
    }

    // Method to get the user's response for a new entry
    static string GetCurrentDate()
    {
        return DateTime.Now.ToShortDateString();
    }
}
