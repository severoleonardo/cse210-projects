using System;
using System.Collections.Generic;

class Program
{
    private static Account account = new Account();
    private static List<Category> categories = new List<Category>();
    private static FileManager fileManager = new FileManager();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Your Personal Finance Manager!");
        LoadData();
        
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add a Transaction");
            Console.WriteLine("2. View Balance and Transactions");
            Console.WriteLine("3. Manage Goals");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option (1-4): ");
            
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTransactionUI();
                    break;
                case "2":
                    ViewBalanceAndTransactions();
                    break;
                case "3":
                    ManageGoalsUI();
                    break;
                case "4":
                    exit = true;
                    SaveData();
                    Console.WriteLine("Thanks for using Personal Finance Manager. Have a great day!");
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }

    private static void AddTransactionUI()
    {
        // Placeholder for adding a transaction
        Console.WriteLine("\n--- Add a New Transaction ---");
        // Implementation details for adding a transaction
        Console.Write("Enter the amount: ");
        var amount = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter date (YYYY-MM-DD): ");
        var date = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Enter description: ");
        var description = Console.ReadLine();

        Console.Write("Enter category name: ");
        var categoryName = Console.ReadLine();
        var category = categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase)) ?? new Category(categoryName);
        if (!categories.Contains(category)) categories.Add(category);

        Console.WriteLine("Transaction added successfully!");
    }

    private static void ViewBalanceAndTransactions()
    {
        Console.WriteLine("\n--- Your Balance and Transactions ---");
        foreach (var transaction in account.Transactions)
        {
              Console.WriteLine($"{transaction.Date.ToShortDateString()}: {transaction.Description} - {transaction.Amount:C} in {transaction.Category.Name}");
        }
        Console.WriteLine($"Current Balance: {account.CalculateBalance():C}");

    }

    private static void ManageGoalsUI()
    {
        // Placeholder for managing financial goals
        Console.WriteLine("\n--- Manage Your Financial Goals ---");
        // Implementation details for managing goals
    }

    private static void LoadData()
    {
        // Placeholder for loading data from a file
        // Use fileManager to load transactions and goals
        try
        {
            account = fileManager.LoadTransactions("transactions.json") ?? new Account();
            Console.WriteLine("Data loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }

    private static void SaveData()
    {
        // Placeholder for saving data to a file
        // Use fileManager to save transactions and goals
    }
}
