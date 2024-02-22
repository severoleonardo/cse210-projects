public class Category // Represents a single category for a transaction
{
    public string Name { get; private set; }

    public Category(string name) // Initializes a new instance of the Category class.
    {
        Name = name;
    }

    public void Rename(string newName) => Name = newName;
}
