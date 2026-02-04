using EMS.Models;

namespace EMS;
public class Developer : Employee
{
    public string PrimaryLanguage { get; set; } = string.Empty;
    public int ProjectsCompleted { get; set; }
    public Seniority SeniorityLevel { get; set; }

    public Developer(int id, string firstName, string lastName, string department,
                    DateTime hireDate, decimal baseSalary, string primaryLanguage,
                    int projectsCompleted, Seniority seniorityLevel)
           : base(id, firstName, lastName, department, hireDate, baseSalary)
    {
        PrimaryLanguage = primaryLanguage;
        ProjectsCompleted = projectsCompleted;
        SeniorityLevel = seniorityLevel;
    }

    public override decimal CalculateAnnualSalary()
    {
        decimal seniorityMultiplier = SeniorityLevel switch
        {
            Seniority.Junior => 1.0m,
            Seniority.Mid    => 1.2m,
            Seniority.Senior => 1.5m,
            _                => 1.0m
        };

        return Math.Round(base.CalculateAnnualSalary() * seniorityMultiplier, 2);
    }

    public override string EvaluatePerformance()
    {
        return $"Projects Completed: {ProjectsCompleted}, Primary Language: {PrimaryLanguage}";
    }

    // Not using Generics:
    // public override ReportData GenerateReport()
    // {
    //     return new DeveloperReportData
    //     (
    //         FirstName, LastName, Department, CalculateAnnualSalary(),
    //         PrimaryLanguage, ProjectsCompleted, SeniorityLevel
    //     );
    // }

    // Using Generics:
    public override T GenerateReport<T>()
    {
        return (T)(object)new DeveloperReportData
        (
            FirstName, LastName, Department, CalculateAnnualSalary(),
            PrimaryLanguage, ProjectsCompleted, SeniorityLevel
        );
    }

}