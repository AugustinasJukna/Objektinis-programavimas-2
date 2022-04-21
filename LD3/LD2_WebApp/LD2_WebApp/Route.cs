using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    public class Route : IComparable<Route>, IEquatable<Route>, IReturnable
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

        /// <summary>
        /// Compares by distance and first city's name
        /// </summary>
        /// <param name="route">Route object to compare to</param>
        /// <returns></returns>
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

        /// <summary>
        /// Equals method override
        /// </summary>
        /// <param name="other">object to compare to</param>
        /// <returns>a true or false statement</returns>
        public bool Equals(Route other)
        {
            return FirstCity == other.FirstCity && SecondCity == other.SecondCity && Distance == other.Distance;
        }

        //GetHashCode() method override
        public override int GetHashCode()
        {
            return FirstCity.GetHashCode() ^ SecondCity.GetHashCode() ^ Distance.GetHashCode();
        }

        /// <summary>
        /// Equals operator
        /// </summary>
        /// <param name="a">First Route object</param>
        /// <param name="b">Second route object to compare with</param>
        /// <returns>a true or false statement</returns>
        public static bool operator == (Route a, Route b)
        {
            return a.FirstCity == b.FirstCity && a.SecondCity == b.SecondCity && a.Distance == b.Distance;
        }

        /// <summary>
        /// Not equals operator
        /// </summary>
        /// <param name="a">First Route object</param>
        /// <param name="b">Second route object to compare with</param>
        /// <returns>a true or false statement</returns>

        public static bool operator != (Route a, Route b)
        {
            return a.FirstCity != b.FirstCity && a.SecondCity != b.SecondCity && a.Distance != b.Distance;
        }

        //ToString() method override
        public override string ToString()
        {
            string line;
            return line = String.Format("|{0, -20}|{1, -20}|{2, 15}|", FirstCity, SecondCity, Distance);
        }


        public string ReturnDivisibleLine()
        {
            return String.Format($"{FirstCity};{SecondCity};{Distance}");
        }
    }
}
