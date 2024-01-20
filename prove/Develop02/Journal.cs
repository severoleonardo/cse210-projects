using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    private List<Entry> _entries;

    // Constructor initializes the list of entries
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // Method to add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Method to display all entries in the journal
    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save the journal entries to a file
    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                // Iterate through entries and write each to the file
                foreach (var entry in _entries)
                {
                    outputFile.WriteLine($"{entry.GetPromptText()},{entry.GetEntryText()},{entry.GetDate()}");
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            // Handle exceptions related to file operations
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
        }
    }

    // Method to load journal entries from a file
    public void LoadFromFile(string fileName)
    {
        try
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(fileName);

            // Iterate through lines and create entries
            foreach (string line in lines)
            {
                string[] parts = line.Split(','); // Adjusts the separator based on the chosen symbol
                string promptText = parts[0];
                string entryText = parts[1];
                string date = parts[2];

                // Create a new entry and add it to the journal
                Entry newEntry = new Entry();
                newEntry.SetPromptText(promptText);
                newEntry.SetEntryText(entryText);
                newEntry.SetDate(date);

                AddEntry(newEntry);
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        // Handle file-related exceptions
        catch (Exception ex) 
        {
            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Oops! An error occurred while loading the journal:");

            if (ex is FileNotFoundException fileNotFoundException)
            {
                // Handle specific exception: file not found
                Console.WriteLine($"File not found: {Path.GetFileName(fileNotFoundException.FileName)}");
            }
            else
            {
                // Handle general exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Check the file name and try again.\n-------------------------");
        }
    }
}
