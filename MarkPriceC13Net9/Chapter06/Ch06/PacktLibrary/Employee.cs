namespace Packt.Shared;

public class Employee : Person
{
    public string? EmployeeCode { get; set; }
    public DateOnly HireDate { get; set; }

    public override string ToString()
    {
        return $"{Name}'s code is {EmployeeCode}";
    }
}