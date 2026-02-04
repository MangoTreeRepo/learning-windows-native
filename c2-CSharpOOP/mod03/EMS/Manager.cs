using EMS.Models;

namespace EMS;
public class Manager : Employee
{
    public int TeamSize { get; set; }
    public decimal BonusPercentage { get; set; }

    public Manager(int id, string firstName, string lastName, string department,
                   DateTime hireDate, decimal baseSalary, int teamSize, decimal bonusPercentage)
            : base(id, firstName, lastName, department, hireDate, baseSalary)
    {
        TeamSize = teamSize;
        BonusPercentage = bonusPercentage;
    }

    public override decimal CalculateAnnualSalary()
    {
        return Math.Round(base.CalculateAnnualSalary() * (1.0m + BonusPercentage/100m), 2);
    }

    public override string EvaluatePerformance()
    {
        return $"Team Size: {TeamSize}, Leadership Assessment";
    }

    // Not using Generics:
    // public override ReportData GenerateReport()
    // {
    //     return new ManagerReportData
    //     (
    //         FirstName, LastName, Department, CalculateAnnualSalary(),
    //         TeamSize, BonusPercentage
    //     );
    // }

    // Using Generics:

    public override T GenerateReport<T>()
    {
        return (T)(object)new ManagerReportData
        (
            FirstName, LastName, Department, 
            CalculateAnnualSalary(), TeamSize, BonusPercentage
        );
    }

}