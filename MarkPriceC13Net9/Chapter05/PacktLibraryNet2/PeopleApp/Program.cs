using Packt.Shared;

ConfigureConsole();

Person bob = new();
WriteLine(bob);

bob.Name = "Bob Smith";
bob.Born = new DateTimeOffset(
    year: 1965, month: 12, day: 22,
    hour: 16, minute: 28, second: 0,
    offset: TimeSpan.FromHours(-5)
);
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = 
    WondersOfTheAncientWorld.HangingGardensOfBabylon
    | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

bob.Children.Add(new() { Name = "Bella" });
bob.Children.Add(new() { Name = "Alfred" });
bob.Children.Add(new() { Name = "Zoe" });

WriteLine($"Bob's bucket list: {bob.BucketList.ToString()}");

Person alice = new()
{
    Name = "Alice Jones",
    Born = new(1998, 3, 7, 16, 28, 0, TimeSpan.Zero),
    FavoriteAncientWonder = WondersOfTheAncientWorld.ColossusOfRhodes,
    BucketList = WondersOfTheAncientWorld.None
};

List<Person> employees = [bob, alice];

foreach (var person in employees)
{
    WriteLine($"{person.Name} was born on {person.Born:D}.\n{person.Name}'s favorite ancient wonder is {person.FavoriteAncientWonder}.");
    WriteLine($"BucketList: {(int)person.BucketList}");
}

WriteLine($"{bob.Name}'s {bob.Children.Count} children are:");
foreach (var child in bob.Children)
{
    WriteLine($"> {child.Name}");
}

// Set interest rate
BankAccount.InterestRate = 0.012M;
BankAccount jonesAccount = new()
{
    AccountName = "Mrs. Jones",
    Balance = 2400,
};

WriteLine($"{jonesAccount.AccountName}, {jonesAccount.Balance}, {BankAccount.InterestRate}");

Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 13 and .NET 9 - Modern Cross-Platform Development Fundamentals",
    Author = "Mark J. Price",
    PageCount = 828
};

WriteLine($"{book.Isbn}, {book.Title}, {book.Author}, {book.PageCount:N0}");


// Passenger

Passenger[] passengers =
{
    new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
    new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
    new BusinessClassPassenger { Name = "Janice" },
    new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
    new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};

foreach (Passenger passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
        FirstClassPassenger _                          => 2_000M,
        BusinessClassPassenger _                       => 1_000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0  => 500M,
        CoachClassPassenger _                          => 650M,
        _                                              => 800M
    };

    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}