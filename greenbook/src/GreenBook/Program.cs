using System;
using System.Collections.Generic;

namespace GreenBook
{

    class Program
    {
        static void OnGradeAdded(object sender, EventArgs e) {
            System.Console.WriteLine("Grade Added!");
        }
        static void Main(string[] args)
        {

            List<double> gradesList = new List<double>();
            IBook book = new DiskBook(gradesList, "BookName");
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine($"The lowest grade is: {stats.Low}!");
            System.Console.WriteLine($"The highest grade is: {stats.High}!");
            System.Console.WriteLine($"The average is: {stats.Average:N2}!");   
            System.Console.WriteLine($"The letter grade for average is: {stats.Letter}!");
        }

        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade or press Q to exit!");
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
                catch (ArgumentException e)
                {
                    System.Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    System.Console.WriteLine(e.Message);
                }
                finally
                {
                    System.Console.WriteLine("Finally");
                }
            }
        }
    }
}
