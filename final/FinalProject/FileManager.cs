using Newtonsoft.Json; // Using Newtonsoft.Json for JsonConvert

public class FileManager
{
    // Example methods for saving and loading transactions using JSON for simplicity
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
