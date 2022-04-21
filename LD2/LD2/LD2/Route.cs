using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2
{
    class Route
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
