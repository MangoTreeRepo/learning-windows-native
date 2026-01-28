using System.Globalization; 

namespace BankAccount;

class BankAccount
{
    private decimal _balance = 0m;
    private string _customerName = string.Empty;
    private readonly string _accountNumber;

    public decimal Balance => _balance;
    public string AccountNumber => _accountNumber;

    public string CustomerName
    {
        get => _customerName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name is required.");
            
            // Using InvariantCulture for consistent behavior across all systems
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            _customerName = textInfo.ToTitleCase(value.Trim().ToLower());
        }
    }

    public BankAccount(string name, decimal amount, string accountNumber)
    {
        CustomerName = name;
        _balance = amount > 0m ? amount : 0m;
        
        if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number is required.");
                
        if (!System.Text.RegularExpressions.Regex.IsMatch(accountNumber, @"^\d{10}$"))
            throw new ArgumentException("Account number must be exactly 10 digits");
        _accountNumber = accountNumber;
    }
    
    public void Deposit(decimal amount)
    {
        if (amount < 0m || amount > 10_000_000m)
            throw new ArgumentException("Please enter a valid amount (0 up to 10,000,000).");
        decimal oldBalance = Balance;
        _balance += amount;
        Console.WriteLine($"Deposited ${amount}, changed balance from ${oldBalance} to ${Balance}.");
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0m)
            throw new ArgumentException("Cannot withdraw a negative amount.");
        
        if (amount > Balance)
            throw new ArgumentException($"Cannot withdraw greater than ${Balance}.");
        
        _balance -= amount;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("-------- Testing BankAccount class --------");

        var rawData = new[]
        {
            (n: "Luke",  m: 10_000,      c: "1234567890"),
            (n: "",      m: 10_000,      c: "1236567990"), // Invalid Name
            (n: "Peter", m: -1,          c: "1434567790"), // Invalid Amount     
            (n: "Mike",  m: 9_000_000,   c: "82349678"),   // Invalid Account Number
        };
        
        List<BankAccount> validAccounts = [];

        foreach (var (n, m, c) in rawData)
        {
            try
            {
                validAccounts.Add(new BankAccount(n, m, c));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Skipping record for '{n}': {ex.Message}");
            }
        }

        Console.WriteLine($"Successfully loaded {validAccounts.Count} accounts.");

        Console.WriteLine("\n-------- Printing Valid Accounts ---------");

        foreach (var account in validAccounts)
        {
            Console.WriteLine($"Name:           {account.CustomerName}");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance:        {account.Balance}");
            Console.WriteLine("-----------------------------------------");
        }

        BankAccount testAccount = new("Test Name", 90_000, "1234567891");
        try
        {
            testAccount.Deposit(-1);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Deposited negative amount. Message: {ex.Message}");
        }

        try
        {
            testAccount.Withdraw(100_000);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Withdrew greater than balance. Message: {ex.Message}");
        }

        try
        {
            testAccount.Withdraw(-10_000);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Withdrew negative amount. Message: {ex.Message}");
        }

        Console.WriteLine("\n-------- Printing Correct Behavior -----------");
        Console.WriteLine($"Name: {testAccount.CustomerName}");
        Console.WriteLine($"Account Number: {testAccount.AccountNumber}");
        Console.WriteLine($"Initial Balance: {testAccount.Balance}");
        decimal amount = 5_000;
        testAccount.Deposit(amount);
        Console.WriteLine($"Deposited ${amount}. Balance is now ${testAccount.Balance}.");
        testAccount.Withdraw(amount - 1_000);
        Console.WriteLine($"Withdrawn ${amount - 1_000}. Balance is now ${testAccount.Balance}.");
    }
}
