public class Account // Represents a single account with a list of transactions
{
    private List<Transaction> _transactions = new List<Transaction>();

    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    public void AddTransaction(Transaction transaction) => _transactions.Add(transaction);
    public void RemoveTransaction(int transactionId) => _transactions.RemoveAll(t => t.Id == transactionId);
    public decimal CalculateBalance() => _transactions.Sum(t => t.Amount);
}
