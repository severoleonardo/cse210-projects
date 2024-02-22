using System;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    private static Account _account = new Account();
    private static List<Category> _categories = new List<Category>();
    private static FileManager _fileManager = new FileManager();
    private static List<Goal> _goals = new List<Goal>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Your Personal Finance Manager!");
        LoadData();
        
        bool exit = false;
        while (!exit) // Main menu loop
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

    private static void AddTransactionUI() // Add a new transaction
    {
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

        //Check if the category already exists, if not, add it
        var category = _categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
        if (category == null)
        {
            category = new Category(categoryName);
            _categories.Add(category); // Add the new category to the list
        }

        // Create a new Transaction object with the collected details
        var transaction = new Transaction(_account.Transactions.Count + 1, amount, date, description, category);
        _account.AddTransaction(transaction); // Add the transaction to the account

        Console.WriteLine("Transaction added successfully!");
    }

    private static void ViewBalanceAndTransactions() // View balance and transactions
    {
        Console.WriteLine("\n--- Your Balance and Transactions ---");
        foreach (var transaction in _account.Transactions.OrderBy(t => t.Date))
        {
              Console.WriteLine($"{transaction.Date.ToShortDateString()}: {transaction.Description} - {transaction.Amount:C} in {transaction.Category.Name}");
        }
        Console.WriteLine($"Current Balance: {_account.CalculateBalance():C}");

    }

    private static void ManageGoalsUI() // Manage financial goals
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- Manage Your Financial Goals ---");
            Console.WriteLine("1. Add a Goal");
            Console.WriteLine("2. View Goals");
            Console.WriteLine("3. Back to Main Menu");
            Console.Write("Select an option (1-3): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGoalUI();
                    break;
                case "2":
                    ViewGoals();
                    break;
                case "3":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }

    private static void AddGoalUI() // Add a new goal
    {
        Console.WriteLine("\nEnter Goal Description:");
        var description = Console.ReadLine();

        Console.WriteLine("Enter Target Amount:");
        var targetAmount = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter Deadline (YYYY-MM-DD):");
        var deadline = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Is this a Saving Goal or a Spending Goal? (Spend/Save)");
        var goalType = Console.ReadLine();

        Goal goal = goalType?.ToLower() == "save"
            ? new SavingGoal(_goals.Count + 1, targetAmount, deadline, description)
            : new SpendingGoal(_goals.Count + 1, targetAmount, deadline, description);
        _goals.Add(goal);
        Console.WriteLine("Goal added successfully!");
    }

    private static void ViewGoals() // View all financial goals
    {
        Console.WriteLine("\n--- Your Goals ---");
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{goal.ProgressReport()}");
        }
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals set yet.");
        }
    }

    private static void LoadData() // Load transactions and goals from files
    {
        // Load transactions
        var transactionsFilePath = "transactions.json";
        if (File.Exists(transactionsFilePath))
        {
            var transactionsJson = File.ReadAllText(transactionsFilePath);
            var loadedTransactions = JsonConvert.DeserializeObject<List<Transaction>>(transactionsJson);
            if (loadedTransactions != null)
            {
                foreach (var transaction in loadedTransactions)
                {
                    _account.AddTransaction(transaction);
                }
            }
        }

        // Load goals
        var goalsFilePath = "goals.json";
        if (File.Exists(goalsFilePath))
        {
            var goalsJson = File.ReadAllText(goalsFilePath);
            var loadedGoals = JsonConvert.DeserializeObject<List<Goal>>(goalsJson, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            _goals = loadedGoals ?? new List<Goal>();    
        }
    }
    private static void SaveData() // Save transactions and goals to files
    {
        // Save transactions
        var transactionsJson = JsonConvert.SerializeObject(_account.Transactions, Formatting.Indented);
        File.WriteAllText("transactions.json", transactionsJson);

        // Save goals with type information to distinguish between SavingGoal and SpendingGoal
        var goalsJson = JsonConvert.SerializeObject(_goals, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto
        });
        File.WriteAllText("goals.json", goalsJson);
    }
}