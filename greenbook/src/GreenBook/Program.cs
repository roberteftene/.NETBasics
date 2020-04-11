using System;
using System.Collections.Generic;

namespace GreenBook
{

    class Program
    {
        static void Main(string[] args)
        {

            List<double> gradesList = new List<double>();
            var book = new Book(gradesList);
            book.AddGrade(89.1);
            book.AddGrade(12.3);
            // book.ShowStatistics(gradesList);
            // book.ShowStatistics(gradesList);
        }
    }
}
