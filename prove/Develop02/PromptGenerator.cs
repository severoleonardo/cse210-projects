using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // Static list of prompts to be used by all instances of the class
    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    // Method to get a random prompt from the list
    public static string GetRandomPrompt()
    {
        // Create a new Random instance
        Random random = new Random();

         // Generate a random index to select a prompt from the list
        int index = random.Next(_prompts.Count);

        // Return the randomly selected prompt
        return _prompts[index];
    }
}
