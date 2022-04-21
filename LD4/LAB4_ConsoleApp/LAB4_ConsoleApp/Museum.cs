using System;
using System.Linq;
namespace LAB4_ConsoleApp
{
    public class Museum : Location, IParsable, IComparable<Museum>, IEquatable<Museum>
    {
        public string Type { get; set; }
        public int[] WorkingDays { get; set; }
        public bool HasGuide { get; set; }
        public decimal TicketPrice { get; set; }

        public Museum(string name, string address, int year, string type, int[] workingDays, bool guide, decimal ticketPrice)
        {
            Name = name;
            Address = address;
            YearFounded = year;
            Type = type;
            WorkingDays = workingDays;
            HasGuide = guide;
            TicketPrice = ticketPrice;
        }

        public Museum() { }

        public void ParseLine(string[] Parts)
        {
            try
            {
                Name = Parts[0];
                Address = Parts[1];
                YearFounded = int.Parse(Parts[2]);
                Type = Parts[3];
                string[] split = Parts[4].Split(' ');
                WorkingDays = split.Where(s => int.TryParse(s, out int _)).Select(s => int.Parse(s)).ToArray();
                HasGuide = int.Parse(Parts[5]) == 1 ? true : false;
                TicketPrice = decimal.Parse(Parts[6]);
            }

            catch (Exception ex)
            {
                throw new FormatException("Parse error!", ex);
            }
        }

        public int CompareTo(Museum other)
        {
            return TicketPrice.CompareTo(other.TicketPrice);
        }

        public override string ToString()
        {
            string line = "";
            for (int i = 0; i < WorkingDays.Length; i++)
            {
                if (i == WorkingDays.Length - 1) line += (WorkingDays[i].ToString());
                else
                {
                    line += (WorkingDays[i].ToString() + " ");
                }
            }
            return String.Format("|{0, -25}|{1, -20}|{2, 20}|{3, -10}|{4, 20}|{5, 10}|{6, 15}|", Name, Address, YearFounded, Type, line, (HasGuide ? "1" : "0"), TicketPrice);
        }

        public bool Equals(Museum other)
        {
            return Name == other.Name && Address == other.Address && YearFounded == other.YearFounded && TicketPrice == other.TicketPrice && Type == other.Type;
        }
    }
}

