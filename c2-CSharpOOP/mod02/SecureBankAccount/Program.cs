using System.Globalization; 

namespace SecureBankAccount;

public enum TransactionType { Create, Deposit, Withdraw }
public record TransactionRecord(string Account, decimal Amount, TransactionType Type);
class SecureBankAccount
{
    private decimal _balance;
    private string _customerName = string.Empty;
    private string _accountNumber = string.Empty;
    private readonly DateTime _createdDate;
    private readonly List<TransactionRecord> _transactions = []; // transaction history

    public decimal Balance => _balance;

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

    public string AccountNumber
    {
        get => _accountNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Account number is required.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{10}$"))
                throw new ArgumentException("Account number must be exactly 10 digits");

            _accountNumber = value;
        }
    }

    public DateTime CreatedDate => _createdDate;

    public IEnumerable<TransactionRecord> Transactions => _transactions.AsReadOnly();

    public SecureBankAccount(decimal balance, string name, string account)
    {
        _balance = balance > 0m ? balance : 0m;
        CustomerName = name;
        AccountNumber = account;
        _createdDate = DateTime.Now;
        _transactions.Add(new TransactionRecord(AccountNumber, Balance, TransactionType.Create));
    }

    public void Deposit (decimal amount)
    {
        if (amount < 0m)
            throw new ArgumentException("Cannot deposit a negative amount.");

        if (amount > 10_000_000m)
            throw new ArgumentException("Cannot deposit exceeding $10,000,000.");
        
        _balance += amount;

        _transactions.Add(new TransactionRecord(AccountNumber, Balance, TransactionType.Deposit));

        Console.WriteLine($"Deposited: ${amount}, Current Balance: ${Balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount < 0m)
            throw new ArgumentException("Cannot withdraw a negative amount.");

        if (amount > 10_000_000m)
            throw new ArgumentException("Cannot withdraw exceeding $10,000,000.");

        if (amount > Balance)
            throw new ArgumentException($"Cannot withdraw exceeding ${Balance}.");

        _balance -= amount;

        _transactions.Add(new TransactionRecord(AccountNumber, Balance, TransactionType.Withdraw));

        Console.WriteLine($"Withdrew: ${amount}, Current Balance: ${Balance}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        SecureBankAccount scb = new(90_000, "Test Name", "1234567891");
        
        Console.WriteLine("---- Bank Account Details ----");
        Console.WriteLine($"Name: {scb.CustomerName}");
        Console.WriteLine($"Account Number: {scb.AccountNumber}");
        Console.WriteLine($"Balance: {scb.Balance}");
        Console.WriteLine($"Creation Date: {scb.CreatedDate}");

        scb.Deposit(1_000);
        scb.Deposit(500);
        scb.Deposit(5);

        scb.Withdraw(10);


        Console.WriteLine("\n----- Account History -------");
        foreach (var transaction in scb.Transactions)
        {
            Console.WriteLine($"{transaction.Account} ${transaction.Amount} {transaction.Type}");
        }
    }
}
