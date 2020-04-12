using System;
using System.Collections.Generic;

namespace GreenBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name) { }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class InMemoryBook : Book, IBook
    {

        List<double> grades = new List<double>();
        public const string CATEGORY = "Science";
        public override event GradeAddedDelegate GradeAdded;


        public InMemoryBook() : base("") { }

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public InMemoryBook(List<double> grades, string name) : base(name)
        {

            this.grades = grades;
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0.0 && grade <= 100.00)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public List<double> getGrades()
        {
            return this.grades;
        }

        public void AddGrade(char letter)
        {

            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;

            }

        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            System.Console.Write("The grades are: ");

            foreach (double grade in grades)
            {
                result.Add(grade);
                Console.Write(grade + "  ");
            }
            return result;

        }

    }

}