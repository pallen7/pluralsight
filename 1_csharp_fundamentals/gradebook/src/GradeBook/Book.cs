using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {          
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var number in grades)
            {
                highGrade = Math.Max(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }

            result /= grades.Count;

            Console.WriteLine($"Average grade is {result:N1}");
            Console.WriteLine($"Max grade is {highGrade:N1}");
            Console.WriteLine($"Min grade is {lowGrade:N1}");
        }

        // Private members
        List<double> grades;
        string name;
    }
}