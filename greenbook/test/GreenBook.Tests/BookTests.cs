using System;
using Xunit;

namespace GreenBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.05);
            book.AddGrade(77.3);

            

            //Act
            var stats = book.GetStatistics();
            System.Console.WriteLine($"The highest grade is: {stats.High}!");
            System.Console.WriteLine($"The smallest grade is: {stats.Low}!");
            System.Console.WriteLine($"The average is: {stats.Average:N2}!");

            // Assert
            Assert.Equal(85.5, stats.Average, 1);
            Assert.Equal(90.05, stats.High,1);
            Assert.Equal(77.3,stats.Low,1);

        }
    }
}
