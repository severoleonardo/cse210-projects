public class Transaction
{
    public int Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }

    public Transaction(int id, decimal amount, DateTime date, string description, Category category)
    {
        Id = id;
        Amount = amount;
        Date = date;
        Description = description;
        Category = category;
    }

    public void UpdateAmount(decimal newAmount) => Amount = newAmount;
    public void UpdateDescription(string newDescription) => Description = newDescription;
    public void AssignCategory(Category newCategory) => Category = newCategory;
}
