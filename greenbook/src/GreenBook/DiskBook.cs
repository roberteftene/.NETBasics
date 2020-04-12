using System;
using System.Collections.Generic;
using System.IO;

namespace GreenBook
{
    internal class DiskBook : Book
    {
        private List<double> gradesList;


        public DiskBook(List<double> gradesList, string name) : base(name)
        {
            this.gradesList = gradesList;
        }


        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
          using(var writter =  File.AppendText($"{Name}.txt")) {
          
          writter.WriteLine(grade);
          if(GradeAdded != null) {
              GradeAdded(this, new EventArgs());
          }
          }
          
        }

        public override Statistics GetStatistics()
        {
           var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt")) {
                string line = reader.ReadLine();
                while(line != null) {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}