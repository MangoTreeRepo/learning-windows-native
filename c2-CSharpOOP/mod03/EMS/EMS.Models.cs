namespace EMS.Models;

// Centralized Data Structures
public record ReportData(string First, string Last, string Dept, decimal Total);

public record ManagerReportData(string First, string Last, string Dept, decimal Total, 
                                int TeamSize, decimal Bonus) 
    : ReportData(First, Last, Dept, Total);

public record DeveloperReportData(string First, string Last, string Dept, decimal Total, 
                                 string PrimaryLanguage, int ProjectsCompleted, Seniority SeniorityLevel) 
    : ReportData(First, Last, Dept, Total);

public enum Seniority
{
    Junior,
    Mid,
    Senior
}