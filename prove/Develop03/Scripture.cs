using System.Text;
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor that accepts a reference and the text of the scripture
    public Scripture(Reference reference, string scriptureText)
    {
        _reference = reference;
        _words = CreateWordList(scriptureText);
    }

    // Constructor that accepts only the text of the scripture
    public Scripture(string scriptureText)
    {
        _reference = new Reference("Unknown", 1, 1);
        _words = CreateWordList(scriptureText);
    }

    // Helper method to create a list of Word objects from the scripture text
    private List<Word> CreateWordList(string scriptureText)
    {
        string[] words = scriptureText.Split(' ');
        return words.Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        // Get a list of all the words that are not already hidden
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        // If there are fewer than 'numberToHid' visible words, hide all of them
        if (visibleWords.Count <= numberToHide)
        {
            foreach (Word word in visibleWords)
            {
                word.Hide();
            }
            return;
        }
        else
        {
            // Randomly select 'numberToHide' distinct words and hide them
            Random random = new Random();
            for (int i = 0; i < numberToHide; i++)
            {
                var index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }

    public void ShowAllWords()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

    public string GetDisplayText()
    {
        StringBuilder displayText = new StringBuilder($"{_reference.GetDisplayText()}: ");
        foreach (Word word in _words)
        {
            displayText.Append(word.GetDisplayText() + " ");
        }
        return displayText.ToString().Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}