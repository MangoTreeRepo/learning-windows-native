using EMS.Models;

namespace EMS;
public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public decimal BaseSalary { get; set; }

    public Employee(int id, string firstName, string lastName,
                    string department, DateTime hireDate, decimal baseSalary)
    {
        EmployeeId = id;
        FirstName = firstName;
        LastName = lastName;
        Department = department;
        HireDate = hireDate;
        BaseSalary = baseSalary;
    }

    public virtual decimal CalculateAnnualSalary()
    {
        return Math.Round(BaseSalary * 12.0m, 2);
    }

    public virtual string EvaluatePerformance()
    {
        return "Standard performance evaluation";
    }

    // Not using Generics:
    // public virtual ReportData GenerateReport()
    // {
    //     return new ReportData(FirstName, LastName, Department, CalculateAnnualSalary());
    // }

    // Using Generics:
    public virtual T GenerateReport<T>() where T : ReportData
    {
        return (T)new ReportData(FirstName, LastName, Department, CalculateAnnualSalary());
    }
    public virtual ReportData GenerateReport() => GenerateReport<ReportData>();

}