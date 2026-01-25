using System;
/*
* Calculates numeric grade and letter grade based on homeword, midterm, and final exams
*/

namespace GradeCalculator
{
    public class StudentGrade
    {
        public double CalculateFinalGrade(double homework, double midterm, double final)
        {
            /// <summary>
            /// Calculates final grade based on homework (30%), midterm (30%), and final (40%)
            /// </summary>
            /// <param name="homework"> grade of homework </param>
            /// <param name="midterm"> grade of midterm </param>
            /// <param name="final"> grade of final </param>
            double weightedHomework = homework * 0.30;
            double weightedMidterm = midterm * 0.30;
            double weightedFinal = final * 0.40;

            return weightedHomework + weightedMidterm + weightedFinal;
        }

        public string GetLetterGrade(double numericGrade)
        {
            /// <summary>
            /// Calculates letter grade based on numeric grade 0-100.
            /// </summary>
            /// <param name="numericGrade"> Numeric grade 0-100 </param>
            if (numericGrade >= 97) return "A+";
            if (numericGrade >= 93) return "A";
            if (numericGrade >= 90) return "A-";
            if (numericGrade >= 90) return "A-";
            if (numericGrade >= 87) return "B+";
            if (numericGrade >= 83) return "B";
            if (numericGrade >= 80) return "B-";
            if (numericGrade >= 77) return "C+";
            if (numericGrade >= 73) return "C";
            if (numericGrade >= 70) return "C-";
            if (numericGrade >= 67) return "D+";
            if (numericGrade >= 63) return "D";
            if (numericGrade >= 60) return "D-";
            return "F";
        }

        class Program
        {
            static void Main(string[] args)
            {
                StudentGrade studentGrade = new();
                double numericGrade = studentGrade.CalculateFinalGrade(70, 80, 85);
                Console.WriteLine($"Numeric grade: {numericGrade:F2}");
                string letterGrade = studentGrade.GetLetterGrade(numericGrade);
                Console.WriteLine($"Letter grade: {letterGrade}");
            }
        }
    }
}