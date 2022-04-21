using System;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Lab4_WebApp
{
    public class Statue : Location, IParsable, IComparable<Statue>, IEquatable<Statue>
    {
        public string Author { get; set; }
        public string ForPerson { get; set; }
        //Constructor
        public Statue(string name, string address, int year, string author, string person)
        {
            Name = name;
            Address = address;
            YearFounded= year;
            Author = author;
            ForPerson = person;
        }

        public Statue() { }

        //Parses line into this class object's properties
        public void ParseLine(string[] Parts)
        {
            try
            {
                Name = Parts[0];
                Address = Parts[1];
                YearFounded = int.Parse(Parts[2]);
                Author = Parts[3];
                ForPerson = Parts[4];
            }
            catch (Exception ex)
            {
                throw new ParseException("Klaidingas nuskaitymas!", ex);
            }
        }

        /// <summary>
        /// Returns TableRow object with this object's properties
        /// </summary>
        /// <returns>TableRow object</returns>
        public override TableRow ToRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = Name });
            row.Cells.Add(new TableCell() { Text = Address });
            row.Cells.Add(new TableCell() { Text = YearFounded.ToString() });
            row.Cells.Add(new TableCell() { Text = Author });
            row.Cells.Add(new TableCell() { Text = ForPerson, ColumnSpan = 3 });
            return row;
        }
        //IComparable interface method realisation
        public int CompareTo(Statue other)
        {
            return (Author.CompareTo(other.Author) * -1);
        }
        //ToString method override
        public override string ToString()
        {
            return String.Format("|{0, -25}|{1, -20}|{2, 20}|{3, -25}|{4, -25}|", Name, Address, YearFounded, Author, ForPerson);
        }
        /// <summary>
        /// Outputs class object into string line for CSV file
        /// </summary>
        /// <returns>a string line</returns>
        public override string ToCSVString()
        {
            return String.Format("{0, -25};{1, -20};{2, 20};{3, -25};{4, -25}", Name, Address, YearFounded, Author, ForPerson);
        }

        /// <summary>
        /// Checks if two class objects are the same
        /// </summary>
        /// <param name="other">other object to check</param>
        /// <returns>a true or false statement</returns>
        public bool Equals(Statue other)
        {
            return Name == other.Name && Address == other.Address && YearFounded == other.YearFounded && Author == other.Author && ForPerson == other.ForPerson;
        }

        /// <summary>
        /// Checks if a location is new or old
        /// </summary>
        /// <returns>true or false, depending on if location is new or not</returns>
        public override bool IsNew()
        {
            int currentYear = DateTime.Now.Year;
            return (currentYear - YearFounded < 1 ? true : false);
        }
    }
}
