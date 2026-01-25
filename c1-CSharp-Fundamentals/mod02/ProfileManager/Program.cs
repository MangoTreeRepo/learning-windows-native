using System;
using System.Diagnostics;

namespace ProfileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Jhein";
            string lastName = "Siclon";
            int age = 43;
            double heightInFeet = 5.9;
            int employeeId = 1234;
            char departmentCode = 'M';
            bool isActiveEmployee = true;
            bool hasCompletedTraining = true;
            bool wantsEmailNotifications = false;
            bool isRemoteEligible = true;

            int yearsUntilRetirement = 65 - age;
            double heightInInches = heightInFeet * 12.0;
            string displayId = departmentCode + employeeId.ToString();

            string fullName = firstName + " " + lastName;
            string emailAddress = firstName[..1].ToLower() + lastName.ToLower() + "@company.com";
            string formattedHeight = heightInFeet + " feet";
            string trainingStatus = hasCompletedTraining ? "Training Complete" : "Training Required";

            Console.WriteLine("=== EMPLOYEE PROFILE ===");
            Console.WriteLine($"Name: {fullName}");
            Console.WriteLine($"Employee ID: {displayId}");
            Console.WriteLine($"Email: {emailAddress}");
            Console.WriteLine();
            Console.WriteLine("--- Personal Information ---");
            Console.WriteLine($"Age: {age} years old");
            Console.WriteLine($"Height: {formattedHeight} ({heightInInches:F2} inches)");
            Console.WriteLine($"Years until retirement: {yearsUntilRetirement}");
            Console.WriteLine();
            Console.WriteLine("--- Status & Preferences ---");
            Console.WriteLine($"Active Employee: {isActiveEmployee}");
            Console.WriteLine($"Training Status: {trainingStatus}");
            Console.WriteLine($"Email Notifications: {wantsEmailNotifications}");
            Console.WriteLine($"Remote Work Eligible: {isRemoteEligible}");
        }
    }
}