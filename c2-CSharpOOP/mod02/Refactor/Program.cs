using System.ComponentModel.DataAnnotations;
using System.Globalization; 

namespace Refactor;

public class Person
{
    private string _name = string.Empty;
    private int _age;
    private string _email = string.Empty;
    private static readonly EmailAddressAttribute EmailValidator = new();

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name is required.");
            
            // Using InvariantCulture for consistent behavior across all systems
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            _name = textInfo.ToTitleCase(value.Trim().ToLower());
        }
    }

    public int Age
    {
        get => _age; 
        set => _age = (value is < 0 or > 150)
            ? throw new ArgumentException("Please enter a valid age.")
            : value;
    }

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email is required.");
            
            if (!EmailValidator.IsValid(value))
                throw new ArgumentException($"'{value}' is not a valid email format.");

            _email = value.Trim().ToLower();
        }
    }

    public Person(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }

}
class Program
{
    static void Main(string[] args)
    {
        // A list of "dirty" data from an external source (like your Python scraper)
        var rawData = new[] {
            (n: "Alice Smith", a: 25,  e: "alice@test.com"  ),
            (n: "",            a: 40,  e: "bob@test.com"    ),  // Missing Name
            (n: "Charlie",     a: 200, e: "charlie@test.com"), // Invalid Age
            (n: "Luke",        a: 20,  e: "Luke@test.com"   ), 
            (n: "John",        a: 2,   e: "johntest.com"    )  // Invalid Email
        };

        List<Person> validPeople = new();

        foreach (var data in rawData)
        {
            try
            {
                validPeople.Add(new Person(data.n, data.a, data.e));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Skipping record for '{data.n}': {ex.Message}");
            }
        }

        Console.WriteLine($"Successfully loaded {validPeople.Count} people.");

        // print valid data
        Console.WriteLine("--- Print Valid People ---");
        foreach (var person in validPeople)
        {
            Console.WriteLine($"Name:  {person.Name}");
            Console.WriteLine($"Age:   {person.Age}");
            Console.WriteLine($"Email: {person.Email}");
            Console.WriteLine("--------------------------");
        }
    }
}


