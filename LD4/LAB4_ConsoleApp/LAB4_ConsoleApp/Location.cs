using System;
namespace LAB4_ConsoleApp
{
    public abstract class Location : IEquatable<Location>, IComparable<Location>
    {
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

        public override string ToString()
        {
            return String.Format($"{Name};{Address};{YearFounded}");
        }
    }
}
