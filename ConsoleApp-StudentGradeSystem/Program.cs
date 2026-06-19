using System;
using System.Collections.Generic;
using System.IO;


namespace StudentGradeSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            double[] grades = new double[5];
            int i = 0;
            while (i < grades.Length)
            {
                Console.WriteLine($"Enter Grade number #{i + 1}");
                grades[i] = Convert.ToDouble(Console.ReadLine());
                i++;
            }
            Student std = new Student(grades);
            Console.WriteLine($"Total Grades = {std.CalculateTotalGrades()}");
            Console.WriteLine($"Grades = {std.PrintGrades()}");
            Console.WriteLine($"Minimum Grade = {std.MinimumGrade()}");
            Console.WriteLine($"Maximum Grade = {std.MaximumGrade()}");
            Console.WriteLine($"Average Grade = {std.AverageGrades()}");
        }
    }

    public class Student
    {
        private double[] stdGrades = new double[5];

        public Student(double[] grades)
        {
            this.stdGrades = grades;
        }
        public double CalculateTotalGrades()
        {
            double result = 0;
            for (int i = 0; i < stdGrades.Length; i++)
                result += stdGrades[i];
            return Math.Round(result,2);
        }

        public double AverageGrades()
        {
            double average = CalculateTotalGrades() / stdGrades.Length;
            return Math.Round(average,2);
        }

        public double MinimumGrade()
        {
            double minimum = stdGrades[0];
            for (int i = 0; i < stdGrades.Length; i++)
                if (stdGrades[i] < minimum) minimum = stdGrades[i];
            return Math.Round(minimum, 2);
        }

        public double MaximumGrade()
        {
            double maximum = stdGrades[0];
            for (int i = 0; i < stdGrades.Length; i++)
                if (stdGrades[i] > maximum) maximum = stdGrades[i];
            return Math.Round(maximum, 2);
        }

        public string PrintGrades()
        {
            string results = "";
            for (int i = 0; i < stdGrades.Length; i++)
                switch (stdGrades[i])
                {
                    case < 50:
                        results += "Fail, ";
                        break;
                    case <= 70:
                        results += "C, ";
                        break;
                    case <= 85:
                        results += "B, ";
                        break;
                    case <= 100:
                        results += "A, ";
                        break;
                }
                results = results.TrimEnd(',',' ');
            return results;
        }
    }
}
