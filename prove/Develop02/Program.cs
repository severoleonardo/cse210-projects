class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        int choice;
        do
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Entry newEntry = new Entry();
                        string randomPrompt = PromptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {randomPrompt}");
                        newEntry.SetPromptText(randomPrompt);
                        newEntry.SetEntryText(GetUserResponse());
                        newEntry.SetDate(GetCurrentDate());
                        journal.AddEntry(newEntry);
                        break;
                    case 2:
                        journal.DisplayAll();
                        break;
                    case 3:
                        Console.Write("Enter the file name to save: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        break;
                    case 4:
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
        Console.Write("Enter your response: ");
        return Console.ReadLine();
    }

    static string GetCurrentDate()
    {
        return DateTime.Now.ToShortDateString();
    }
}
