using Packt.Shared;
using SmartModels;

Person harry = new()
{
    Name = "Harry",
    Born = new(year: 2001, month: 3, day:25,
        hour: 0, minute: 0, second: 0,
        offset: TimeSpan.Zero)
};

harry.WriteToConsole();

var user = new User { Username = "  Admin_User  ", Age = 25 };
WriteLine(user.Username); // Output: "admin_user"
WriteLine(user.Id);

Person lamech = new() { Name = "Lamech" };
Person adah = new() { Name = "Adah" };
Person zillah = new() { Name = "Zillah" };

lamech.Marry(adah);
// Person.Marry(lamech, zillah);
if (lamech + zillah)
{
    WriteLine($"{lamech.Name} and {zillah.Name} successfully got married.");
}

lamech.OutputSpouses();
adah.OutputSpouses();
zillah.OutputSpouses();

Person baby1 = lamech.ProcreateWith(adah);
baby1.Name = "Jabal";
WriteLine($"{baby1.Name} was born on {baby1.Born}");

Person baby2 = Person.Procreate(zillah, lamech);
baby2.Name = "Tubalcain";

Person baby3 = lamech * adah;
baby3.Name = "Jubal";

Person baby4 = zillah * lamech;
baby4.Name = "Naamah";

adah.WriteChildrenToConsole();
zillah.WriteChildrenToConsole();
lamech.WriteChildrenToConsole();

Dictionary<int, string> lookupIntString = [];
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

int key = 3;
WriteLine($"Key {key} has value: {lookupIntString[key]}");

harry.Shout = Harry_Shout;
harry.Shout += Harry_Shout_2;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

Person?[] people =
[
    null,
    new() { Name = "Simon" },
    new() { Name = "Jenny" },
    new() { Name = "Adam" },
    new() { Name = null },
    new() { Name = "Richard" }
];

OutputPeopleNames(people, "Initial List of people: ");
// Array.Sort(people);
// OutputPeopleNames(people, "After sorting using Person's IComparable implementation: ");

Array.Sort(people, new PersonComparer());
OutputPeopleNames(people, "After sorting using PersonComparer's IComparer implementation:");

Employee john = new()
{
    Name = "John Jones",
    Born = new(year: 1990, month: 7, day: 28,
        hour: 0, minute: 0, second: 0,
        offset: TimeSpan.Zero)
};

john.WriteToConsole();

john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:yyy-MM-dd}.");
WriteLine(john.ToString());

Employee aliceInEmployee = new()
{
    Name = "Alice",
    EmployeeCode = "AA123"
};

Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();

WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());
WriteLine($"{Object.ReferenceEquals(aliceInEmployee, aliceInPerson)}");