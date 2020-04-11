using System;
using System.Collections.Generic;

namespace GreenBook {

    public class Book {

        List<double> grades = new List<double>();
        private string name;

        public Book() {}

        public Book(string name) {
            this.name = name;
        }

        public Book(List<double> grades) {
            this.grades = grades;
        }

        public void AddGrade(double grade) {
            if(grade >= 0.0 && grade <= 100.00) {
            grades.Add(grade);
            } else {
                System.Console.WriteLine("The grade is incorrect!");
            }
        }

        public List<double> getGrades() {
            return this.grades;
        }

        public Statistics GetStatistics() {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            var sum = 0.0;
            System.Console.Write("The grades are: ");

            foreach(double grade in grades) {
                sum += grade;
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                Console.Write(grade + "  ");
            }
            result.Average = sum / grades.Count;
            return result;

        }

    }

}