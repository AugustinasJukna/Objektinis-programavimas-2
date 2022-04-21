using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_WebApp
{
    public class FileData : IEquatable<FileData>, IComparable<FileData>
    {
        //Properties
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        private LinkList<Location> Locations { get; set; }
        public string FileName { get; set; }

        //Constructor
        public FileData(string firstLine, string secondLine, LinkList<Location> locations, string fileName)
        {
            FirstLine = firstLine;
            SecondLine = secondLine;
            Locations = locations;
            FileName = fileName;
        }

        public LinkList<Location> GetLocationsList()
        {
            return Locations;
        }
        
        //Equals interface method
        public bool Equals(FileData other)
        {
            throw new NotImplementedException();
        }

        //CompareTo interface method
        public int CompareTo(FileData other)
        {
            throw new NotImplementedException();
        }
    }
}
