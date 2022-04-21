using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3
{
    class Route : IComparable<Route>, IEquatable<Route>
    {
        public string FirstCity { get; set; }
        public string SecondCity { get; set; }
        public int Distance { get; set; }

        public Route(string firstCity, string secondCity, int distance)
        {
            this.FirstCity = firstCity;
            this.SecondCity = secondCity;
            this.Distance = distance;
        }

        public int CompareTo(Route route)
        {
            if (this.Distance == route.Distance)
            {
                return this.FirstCity.CompareTo(route.FirstCity);
            }

            else
            {
                return this.Distance.CompareTo(route.Distance);
            }
        }

        public bool Equals(Route other)
        {
            return FirstCity == other.FirstCity && SecondCity == other.SecondCity && Distance == other.Distance;
        }

        public override int GetHashCode()
        {
            return FirstCity.GetHashCode() ^ SecondCity.GetHashCode() ^ Distance.GetHashCode();
        }

        public static bool operator == (Route a, Route b)
        {
            return a.FirstCity == b.FirstCity && a.SecondCity == b.SecondCity && a.Distance == b.Distance;
        }

        public static bool operator != (Route a, Route b)
        {
            return a.FirstCity != b.FirstCity && a.SecondCity != b.SecondCity && a.Distance != b.Distance;
        }
    }
}
