using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (var entry in _entries)
                {
                    outputFile.WriteLine($"{entry.GetPromptText()},{entry.GetEntryText()},{entry.GetDate()}");
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] parts = line.Split(','); // Adjust the separator based on your chosen symbol
                string promptText = parts[0];
                string entryText = parts[1];
                string date = parts[2];

                Entry newEntry = new Entry();
                newEntry.SetPromptText(promptText);
                newEntry.SetEntryText(entryText);
                newEntry.SetDate(date);

                AddEntry(newEntry);
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        // If the exception is a FileNotFoundException, it displays a message indicating that the file was not found along with the file name.
        catch (Exception ex) 
        {
            Console.WriteLine("An error occurred while loading the journal:");

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

            Console.WriteLine("Please check the file name and try again.");
        }
    }
}
