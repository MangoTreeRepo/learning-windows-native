using System;
using System.Runtime.CompilerServices;

namespace PersonalInfoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Display header
            Console.WriteLine("=================================");
            Console.WriteLine("       PERSONAL INFORMATION.     ");
            Console.WriteLine("=================================");
        
            // Add your information here
            Console.WriteLine("Name: [Your Full Name]");
            Console.WriteLine("Age: [Your Age]");
            Console.WriteLine("Hometown: [Your Hometown]");

            // Programming goals section
            Console.WriteLine();
            Console.WriteLine("Programming Goals:");
            Console.WriteLine("- [Goal 1]");
            Console.WriteLine("- [Goal 2]");
            Console.WriteLine("- [Goal 3]");

            int age = 25;
            string name = "Alex";
            double height = 5.9;
            bool isStudent = true;
            char grade = 'A';

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height: " + height + " feet");
            Console.WriteLine("Is Student: " + isStudent);
            Console.WriteLine("Grade: " + grade);
        }
    }
}