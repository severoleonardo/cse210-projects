public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public void SetDate(string date)
    {
        _date = date;
    }

    public void SetPromptText(string promptText)
    {
        _promptText = promptText;
    }

    public void SetEntryText(string entryText)
    {
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}\nPrompt: {_promptText}\nResponse: {_entryText}\n");
    }

    // Getters for each attribute
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
