// For exceeding requirements I found the way the program load scriptures from files in C# quite confusing, so I decided to implement a scripture library that would anable the program to work with mutiple scriptures, rather than a single one. Using my creativity I also added an error handling for invalid user input and improves the user experience by adding a blank line before the prompt. It also fetches and displays the list of scriptures only once, which could improve performance if the list is large.

public class Program
{
    // Functional requirements Main
    // public static void Main()
    // {
    //     // Test the program
    //     Reference reference = new Reference("Matthew", 10, 24, 25);
    //     Scripture scripture = new Scripture(reference, "The disciple is not above his master, nor the servant above his lord.");
        
    //     while (!scripture.IsCompletelyHidden())
    //     {
    //         Console.WriteLine(scripture.GetDisplayText());
    //         Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
    //         string userInput = Console.ReadLine();

    //         if (userInput.ToLower() == "quit")
    //         {
    //             break;
    //         }

    //         scripture.HideRandomWords(2); // You can adjust the number of words to hide
    //         Console.Clear(); // Clear the console before displaying the modified scripture
    //     }

    //     Console.WriteLine("Program ended.");
    // }
        public static void Main()
    {
        // Create a ScriptureLibrary
        ScriptureLibrary library = new ScriptureLibrary();

        
        // Add multiple scriptures to the library
        library.AddScripture(new Scripture(new Reference("Matthew", 10, 24, 25), "The disciple is not above his master, nor the servant above his lord."));
        library.AddScripture(new Scripture(new Reference("John", 1, 1), "In the beginning was the Word, and the Word was with God, and the Word was God."));
        library.AddScripture(new Scripture(new Reference("Romans", 5, 4, 5), "And patience, experience; and experience, hope: And hope maketh not ashamed; because the love of God is shed abroad in our hearts by the Holy Ghost which is given unto us."));
        library.AddScripture(new Scripture(new Reference("Philippians", 2, 11), "And that every tongue should confess that Jesus Christ is Lord, to the glory of God the Father."));
        // Add more scriptures as needed

        // Interactive loop for the library
        Console.WriteLine("Choose a scripture to explore:");
        List<Scripture> scriptures = library.GetScriptures();
        
        while (true)
        {
            // Display available scriptures
            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText()}");
            }

            // Prompt user to select a scripture
            Console.WriteLine("\nWelcome to the Scripture Library!");
            Console.WriteLine("Enter the number of the scripture to explore or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            // Exit the loop and end the program if the user types 'quit'
            if (userInput.ToLower() == "quit")
            {
                break;
            }

            // Validate user input as a valid number
            if (int.TryParse(userInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= scriptures.Count)
            {
                // Get the selected scripture and create a new Scripture object
                Scripture selectedScripture = scriptures[selectedIndex - 1];
                // Continue with the existing loop logic for the selected scripture
                while (!selectedScripture.IsCompletelyHidden())
                {
                    Console.WriteLine(selectedScripture.GetDisplayText());
                    Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                    string interactionInput = Console.ReadLine();
                    
                    if (interactionInput.ToLower() == "quit")
                    {
                        break;
                    }

                    selectedScripture.HideRandomWords(2);
                    Console.Clear();
                }
                    // Show all words in the scripture when the exploration session ends
                    selectedScripture.ShowAllWords();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'quit'.");
            }
        }

        Console.WriteLine("Program ended.");
    }
}