using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_ConsoleApp
{
    public class FileData : IEquatable<FileData>, IComparable<FileData>
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
        public LinkList<Location> Locations { get; set; }
        public string FileName { get; set; }

        public FileData(string firstLine, string secondLine, LinkList<Location> locations, string fileName)
        {
            FirstLine = firstLine;
            SecondLine = secondLine;
            Locations = locations;
            FileName = fileName;
        }

        public bool Equals(FileData other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(FileData other)
        {
            throw new NotImplementedException();
        }
    }
}
