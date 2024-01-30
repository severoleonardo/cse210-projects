public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
    }

    public void AddScripture(Scripture scripture)
    {
        _scriptures.Add(scripture);
    }

    public List<Scripture> GetScriptures()
    {
        return _scriptures;
    }
}
