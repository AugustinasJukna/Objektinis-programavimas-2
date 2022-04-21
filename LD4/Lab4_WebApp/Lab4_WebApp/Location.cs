using System;
using System.Web.UI.WebControls;
namespace Lab4_WebApp
{
    public abstract class Location : IEquatable<Location>, IComparable<Location>
    {
        //Abstract class
        public string Name { get; set; }
        public string Address { get; set; }
        public int YearFounded { get; set; }

        public int CompareTo(Location other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Location other)
        {
            return Name == other.Name && Address == other.Address && YearFounded == other.YearFounded;
        }

        /// <summary>
        /// Abstract method for printing to CSV file
        /// </summary>
        /// <returns>string line</returns>
        public abstract string ToCSVString();

        /// <summary>
        /// Abstract method for output to table
        /// </summary>
        /// <returns>TableRow object</returns>
        public abstract TableRow ToRow();

        /// <summary>
        /// Abstract method, checks if location is new or not (by a custom criteria)
        /// </summary>
        /// <returns>true or false, depending on the outcome</returns>
        public abstract bool IsNew();
    }
}
