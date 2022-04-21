using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3
{
    class City : IComparable<City>, IEquatable<City>
    {
        public string Name { get; set; }
        public long Citizens { get; set; }

        public City(string city, long citizens)
        {
            this.Name = city;
            this.Citizens = citizens;
        }

        public int CompareTo(City other)
        {
            return Citizens.CompareTo(other.Citizens);
        }

        public bool Equals(City other)
        {
            return Name == other.Name && Citizens == other.Citizens;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Citizens.GetHashCode();
        }

    }
}
