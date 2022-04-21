using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    public class User : IParsable
    {
        public DateTime Date { get; set; }
        public string Surname {get; set;}
        public string Address { get; set; }
        public int Start { get; set; }
        public int Duration { get; set; }
        public int Number { get; set; }
        public int AmountOfPublications { get; set; }

        public decimal FullPrice { get; set; }

        public User(string surname, string address, int start, int duration, int number, int amount)
        {
            Surname = surname;
            Address = address;
            Start = start;
            Duration = duration;
            Number = number;
            AmountOfPublications = amount;
        }

        public User() { }

        public bool CheckIfFits(int month, DateTime startDate, DateTime endDate)
        {
            int endMonth;
            if (this.Start + this.Duration > 12)
            {
                endMonth = this.Start + this.Duration - 12;
            }

            else
            {
                endMonth = this.Start + this.Duration;
            }

            if ((month >= this.Start && endMonth >= month) && (this.Date >= startDate && this.Date <= endDate))
            {
                return true;
            }

            else return false;
        }

        public void ParseLine(string[] lineParts)
        {
            Surname = lineParts[0];
            Address = lineParts[1];
            Start = int.Parse(lineParts[2]);
            Duration = int.Parse(lineParts[3]);
            Number = int.Parse(lineParts[4]);
            AmountOfPublications = int.Parse(lineParts[5]);
        }

        public void AddDate(DateTime date)
        {
            Date = date;
        }
    }
}
