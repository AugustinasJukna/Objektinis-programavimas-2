using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    public class City : IComparable<City>, IEquatable<City>, IReturnable
    {
        public string Name { get; set; }
        public long Citizens { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="city">City's name</param>
        /// <param name="citizens">Amount of citizens</param>
        public City(string city, long citizens)
        {
            this.Name = city;
            this.Citizens = citizens;
        }

        // Compares two objects by default 
        public int CompareTo(City other)
        {
            return Citizens.CompareTo(other.Citizens);
        }
        //Equals override
        public bool Equals(City other)
        {
            return Name == other.Name && Citizens == other.Citizens;
        }

        //GetHashCode() override
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Citizens.GetHashCode();
        }

        //ToString() override
        public override string ToString()
        {
            string line = String.Format("|{0, -20}|{1, 20}|", Name, Citizens);
            return line;
        }

        public string ReturnDivisibleLine()
        {
            return String.Format($"{Name};{Citizens}");
        }
    }
}
