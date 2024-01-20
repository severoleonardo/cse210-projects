public class Entry
{
    // Private member variables to store entry information
    private string _date;
    private string _promptText;
    private string _entryText;

    // Method to set the date of the entry
    public void SetDate(string date)
    {
        _date = date;
    }

     // Method to set the prompt text for the entry
    public void SetPromptText(string promptText)
    {
        _promptText = promptText;
    }

    // Method to set the user's response text for the entry
    public void SetEntryText(string entryText)
    {
        _entryText = entryText;
    }

    // Method to display the entry details
    public void Display()
    {
        Console.WriteLine($"\nDate: {_date}\nPrompt: {_promptText}\nYour Response: {_entryText}\n");
    }

    // Getters for each attribute to retrieve entry information
    public string GetDate()
    {
        return _date;
    }

    public string GetPromptText()
    {
        return _promptText;
    }

    public string GetEntryText()
    {
        return _entryText;
    }
}
