public class Category
{
    public string Name { get; private set; }

    public Category(string name)
    {
        Name = name;
    }

    public void Rename(string newName) => Name = newName;
}
