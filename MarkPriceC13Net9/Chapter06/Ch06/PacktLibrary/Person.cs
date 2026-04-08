namespace Packt.Shared;

public class Person : IComparable<Person?>
{
    public string? Name { get; set; }
    public DateTimeOffset Born { get; set; }
    public List<Person> Children { get; set; } = [];
    public List<Person> Spouses { get; set; } = [];
    public bool Married => Spouses.Count > 0;

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {Born:dddd}.");
    }

    public void WriteToChildrenConsole()
    {
        string term = Children.Count == 1 ? "child" : "childdren";
        WriteLine($"{Name} has {Children.Count} {term}.");
    }

    public static void Marry(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if (p1.Spouses.Contains(p2) || p2.Spouses.Contains(p1))
        {
            throw new ArgumentException($"{p1.Name} is already married to {p2.Name}.");
        }

        p1.Spouses.Add(p2);
        p2.Spouses.Add(p1);
    }

    public void Marry(Person partner)
    {
        Marry(this, partner);
    }

    public void OutputSpouses()
    {
        if (Married)
        {
            string term = Spouses.Count == 1 ? "person" : "people";
            WriteLine($"{Name} is married to {Spouses.Count} {term}:");

            foreach (Person spouse in Spouses)
            {
                WriteLine($" {spouse.Name}");
            }
        }
        else
        {
            WriteLine($"{Name} is a singleton.");
        }
    }

    /// <summary>
    /// Static method to "multiply" aka procreate and have a child together.
    /// </summary>
    /// <param name="p1">Parent 1</param>
    /// <param name="p2">Parent 2</param>
    /// <returns>A Person object that is the child of Parent 1 and Parent 2.</returns>
    /// <exception cref="ArgumentNullException">If p1 or p2 are null.</exception>
    /// <exception cref="ArgumentException">If p1 and p2 are not married.</4exception>
    public static Person Procreate(Person p1, Person p2)
    {
        ArgumentNullException.ThrowIfNull(p1);
        ArgumentNullException.ThrowIfNull(p2);

        if (!p1.Spouses.Contains(p2) && !p2.Spouses.Contains(p1))
        {
            throw new ArgumentException($"{p1.Name} must be married to {p2.Name} to procreate with them.");
        }

        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}",
            Born = DateTimeOffset.Now
        };

        p1.Children.Add(baby);
        p2.Children.Add(baby);

        return baby;
    }

    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    public void WriteChildrenToConsole()
    {
        string term = this.Children.Count > 1 ? "children" : "child";
        WriteLine($"{this.Name} has {this.Children.Count} {term}.");
        
        foreach (var child in Children)
        {
            WriteLine(child.Name);
        }
    }

    public static bool operator + (Person p1, Person p2)
    {
        Marry(p1, p2);
        return p1.Married && p2.Married;
    }

    public static Person operator * (Person p1, Person p2)
    {
        return Procreate(p1, p2);
    }

    public EventHandler? Shout;
    public int AngerLevel;
    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel < 3) return;
        if (Shout is not null)
        {
            Shout(this, EventArgs.Empty);
        }
    }

    public int CompareTo(Person? other)
    {
        int position;

        if (other is not null)
        {
            if ((Name is not null) && (other.Name is not null))
            {
                position = Name.CompareTo(other.Name);
            }
            else if ((Name is not null) && (other.Name is null))
            {
                position = -1;
            }
            else if ((Name is null) && (other.Name is not null))
            {
                position = 1;
            }
            else
            {
                position = 0;
            }
        }
        else if (other is null)
        {
            position = -1;
        }
        else
        {
            position = 0;
        }

        return position;
    }

    public override string ToString()
    {
        return $"{Name} is a {base.ToString()}.";
    }
}
