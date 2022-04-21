using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_ConsoleApp
{
    public class Publication : IParsable
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal MonthlyPrice { get; set; }

        public Publication(int number, string name, decimal monthlyPrice)
        {
            Number = number;
            Name = name;
            MonthlyPrice = monthlyPrice;
        }

        public Publication() { }

        public void ParseLine(string[] lineParts)
        {
            Number = int.Parse(lineParts[0]);
            Name = lineParts[1];
            MonthlyPrice = decimal.Parse(lineParts[2]);
        }

        public void AddDate(DateTime date)
        {
            return;
        }
    }
}
