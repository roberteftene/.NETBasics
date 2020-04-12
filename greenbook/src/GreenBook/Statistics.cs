using System;

namespace GreenBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {

                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';

                }
            }
        }
        public double sum;
        public int Count;

        public Statistics()
        {
            this.Count = 0;
            this.sum = 0.0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }



        public void Add(double number)
        {
            sum += number;
            Count += 1;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }
    }
}