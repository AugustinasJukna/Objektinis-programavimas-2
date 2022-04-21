using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4_WebApp
{
    public class Museum : Location, IParsable, IComparable<Museum>, IEquatable<Museum>
    {
        public string Type { get; set; }
        private int[] WorkingDays { get; set; }
        public bool HasGuide { get; set; }
        public decimal TicketPrice { get; set; }

        //Public constructor
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
        //Empty constructor
        public Museum() { }

        //Parses line into this class object's properties
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
                throw new ParseException("Klaidingas nuskaitymas!", ex);
            }
        }

        /// <summary>
        /// For convenience, makes int array into a string line
        /// </summary>
        /// <returns></returns>
        private string WorkingDaysIntoString()
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
            return line;
        }

        //IComparable<Museum> realisation
        public int CompareTo(Museum other)
        {
            return TicketPrice.CompareTo(other.TicketPrice);
        }
        //Outputs data into line string
        public override string ToString()
        {
            string line = WorkingDaysIntoString();

            return String.Format("|{0, -25}|{1, -20}|{2, 20}|{3, -10}|{4, 20}|{5, 10}|{6, 15}|", Name, Address, YearFounded, Type, line, (HasGuide ? "1" : "0"), TicketPrice);
        }
        //Outputs data into string made for CSV files
        public override string ToCSVString()
        {
            string line = WorkingDaysIntoString();

            return String.Format("{0, -25};{1, -20};{2, 20};{3, -10};{4, 20};{5, 10};{6, 15}", Name, Address, YearFounded, Type, line, (HasGuide ? "1" : "0"), TicketPrice);
        }

        //Outputs data into TableRow objects
        public override TableRow ToRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = Name });
            row.Cells.Add(new TableCell() { Text = Address });
            row.Cells.Add(new TableCell() { Text = YearFounded.ToString() });
            row.Cells.Add(new TableCell() { Text = Type });
            row.Cells.Add(new TableCell() { Text = WorkingDaysIntoString() });
            row.Cells.Add(new TableCell() { Text = (HasGuide ? "1" : "0") });
            row.Cells.Add(new TableCell() { Text = TicketPrice.ToString() });
            return row;
        }
        /// <summary>
        /// Equals method
        /// </summary>
        /// <param name="other">other class object to compare</param>
        /// <returns></returns>
        public bool Equals(Museum other)
        {
            return Name == other.Name && Address == other.Address && YearFounded == other.YearFounded && TicketPrice == other.TicketPrice && Type == other.Type;
        }

        /// <summary>
        /// Checks if the location is new or not
        /// </summary>
        /// <returns>true or false</returns>
        public override bool IsNew()
        {
            int currentYear = DateTime.Now.Year;
            return (currentYear - YearFounded < 2 ? true : false);
        }
    }
}

