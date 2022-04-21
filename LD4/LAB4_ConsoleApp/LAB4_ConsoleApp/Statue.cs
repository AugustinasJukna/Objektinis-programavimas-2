using System;
namespace LAB4_ConsoleApp
{
    public class Statue : Location, IParsable, IComparable<Statue>, IEquatable<Statue>
    {
        public string Author { get; set; }
        public string ForPerson { get; set; }

        public Statue(string name, string address, int year, string author, string person)
        {
            Name = name;
            Address = address;
            YearFounded= year;
            Author = author;
            ForPerson = person;
        }

        public Statue() { }

        public void ParseLine(string[] Parts)
        {
            Name = Parts[0];
            Address = Parts[1];
            YearFounded = int.Parse(Parts[2]);
            Author = Parts[3];
            ForPerson = Parts[4];
        }

        public int CompareTo(Statue other)
        {
            return Author.CompareTo(other.Author) * -1;
        }

        public override string ToString()
        {
            return String.Format("|{0, -25}|{1, -20}|{2, 20}|{3, -25}|{4, -25}|", Name, Address, YearFounded, Author, ForPerson);
        }

        public bool Equals(Statue other)
        {
            return Name == other.Name && Address == other.Address && YearFounded == other.YearFounded && Author == other.Author && ForPerson == other.ForPerson;
        }
    }
}
