using EMS.Models;

namespace EMS;

class Program
{
    static void Main(string[] args)
    {
        Employee newEmp = new
        (
            1234,
            "John",
            "Smith",
            "Q",
            new DateTime(2026, 01, 30),
            9_000m
        );

        Console.WriteLine("\n--- Base Class Employee ---");
        Console.WriteLine($"EmployeeId: {newEmp.EmployeeId}");
        Console.WriteLine($"FirstName: {newEmp.FirstName}");
        Console.WriteLine($"LastName: {newEmp.LastName}");
        Console.WriteLine($"Department: {newEmp.Department}");
        Console.WriteLine($"HireDate: {newEmp.HireDate}");
        Console.WriteLine($"BaseSalary: {newEmp.BaseSalary}");
        Console.WriteLine($"CalculateAnnualSalary(): {newEmp.CalculateAnnualSalary()}");
        Console.WriteLine($"EvaluatePerformance(): {newEmp.EvaluatePerformance()}");
        var (first, last, dept, salary) = newEmp.GenerateReport();
        Console.WriteLine($"First Name: {first}");
        Console.WriteLine($"Last Name: {last}");
        Console.WriteLine($"Department: {dept}");
        Console.WriteLine($"Annual Salary: {salary}");
        Console.WriteLine("---------------------------");

        Manager newManager = new
        (
            43434,
            "Jane",
            "Doe",
            "X",
            new DateTime(2026, 03, 05),
            12_000m,
            200,
            20
        );

        Console.WriteLine("\n--- Manager Class ---");
        Console.WriteLine($"EmployeeId: {newManager.EmployeeId}");
        Console.WriteLine($"FirstName: {newManager.FirstName}");
        Console.WriteLine($"LastName: {newManager.LastName}");
        Console.WriteLine($"Department: {newManager.Department}");
        Console.WriteLine($"HireDate: {newManager.HireDate}");
        Console.WriteLine($"BaseSalary: {newManager.BaseSalary}");
        Console.WriteLine($"CalculateAnnualSalary(): {newManager.CalculateAnnualSalary()}");
        Console.WriteLine($"EvaluatePerformance(): {newManager.EvaluatePerformance()}");
        // var (f, l, d, s, tz, b) = (ManagerReportData) newManager.GenerateReport(); // Need to cast if not using generics
        var (f, l, d, s, tz, b) = newManager.GenerateReport<ManagerReportData>(); 
        Console.WriteLine($"First Name: {f}");
        Console.WriteLine($"Last Name: {l}");
        Console.WriteLine($"Department: {d}");
        Console.WriteLine($"Annual Salary: {s}");
        Console.WriteLine($"Team Size: {tz}");
        Console.WriteLine($"Bonus Percentage: {b}");
        Console.WriteLine("---------------------------");


        Developer newDeveloper = new
        (
            43434,
            "Jane",
            "Doe",
            "X",
            new DateTime(2026, 03, 05),
            12_000m,
            "C#",
            56,
            Seniority.Senior
        );

        Console.WriteLine("\n--- Developer Class ---");
        Console.WriteLine($"EmployeeId: {newDeveloper.EmployeeId}");
        Console.WriteLine($"FirstName: {newDeveloper.FirstName}");
        Console.WriteLine($"LastName: {newDeveloper.LastName}");
        Console.WriteLine($"Department: {newDeveloper.Department}");
        Console.WriteLine($"HireDate: {newDeveloper.HireDate}");
        Console.WriteLine($"BaseSalary: {newDeveloper.BaseSalary}");
        Console.WriteLine($"CalculateAnnualSalary(): {newDeveloper.CalculateAnnualSalary()}");
        Console.WriteLine($"EvaluatePerformance(): {newDeveloper.EvaluatePerformance()}");
        // var (fd, ld, dd, sd, lang, proj, seniority) = (DeveloperReportData) newDeveloper.GenerateReport(); // Need to cast if not using generics
        var (fd, ld, dd, sd, lang, proj, sen) = newDeveloper.GenerateReport<DeveloperReportData>();
        Console.WriteLine($"First Name: {fd}");
        Console.WriteLine($"Last Name: {ld}");
        Console.WriteLine($"Department: {dd}");
        Console.WriteLine($"Annual Salary: {sd}");
        Console.WriteLine($"Primary Language: {lang}");
        Console.WriteLine($"Projects Completed: {proj}");
        Console.WriteLine($"Seniority Level: {sen}");
        Console.WriteLine("---------------------------");
    }
}
