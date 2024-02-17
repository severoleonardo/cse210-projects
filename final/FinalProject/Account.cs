public class Account
{
    private List<Transaction> transactions = new List<Transaction>();

    public IReadOnlyList<Transaction> Transactions => transactions.AsReadOnly();

    public void AddTransaction(Transaction transaction) => transactions.Add(transaction);
    public void RemoveTransaction(int transactionId) => transactions.RemoveAll(t => t.Id == transactionId);
    public decimal CalculateBalance() => transactions.Sum(t => t.Amount);
}
