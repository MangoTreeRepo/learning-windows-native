namespace SmartModels;

public class User
{
    private string _username = string.Empty;
    private int _age;

    // 1. Using => for both Get and Set
    public string Username
    {
        get => _username;
        // Cleanly transform the input before saving it
        set => _username = value.ToLower().Trim();
    }

    // 2. Using => for Validation
    public int Age
    {
        get => _age;
        set => _age = value >= 0 ? value : throw new ArgumentException("Age cannot be negative");
    }

    // 3. Mixing a normal getter with an expression-bodied 'init'
    // This allows setting the ID only during creation.
    public Guid Id { get; init; } = Guid.NewGuid();
}

