using Newtonsoft.Json; // Using Newtonsoft.Json for JsonConvert

public class FileManager // Manages saving and loading transactions to and from a file
{
    public void SaveTransactions(IEnumerable<Transaction> transactions, string filePath)
    {
        var json = JsonConvert.SerializeObject(transactions);
        File.WriteAllText(filePath, json);
    }

    public IEnumerable<Transaction> LoadTransactions(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<Transaction>>(json);
    }
}