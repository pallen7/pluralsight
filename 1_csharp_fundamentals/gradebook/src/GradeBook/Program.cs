using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Paul's grade book!");

            while(true)
            {  
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Unhandled exception: {e.Message}");
                    throw;
                }
                finally 
                {
                    // finally always executed - even after the throw above for unhandled exception
                    // Useful for tidying up. Closing files or network sockets etc
                    Console.WriteLine("**");
                }
            }

            var stats = book.GetStatistics();

            
            Console.WriteLine($"Average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
