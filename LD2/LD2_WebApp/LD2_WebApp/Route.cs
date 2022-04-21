using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    class Route
    {
        public string FirstCity { get; set; }
        public string SecondCity { get; set; }
        public int Distance { get; set; }

        public Route(string firstCity, string secondCity, int distance)//constructor
        {
            this.FirstCity = firstCity;
            this.SecondCity = secondCity;
            this.Distance = distance;
        }

        /// <summary>
        /// CompareTo method override
        /// </summary>
        /// <param name="route">another Route object to compare</param>
        /// <returns>CompareTo result (-1, 0 or 1)</returns>
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
        /// Override for == operator
        /// </summary>
        /// <param name="a">One class object</param>
        /// <param name="b">Another class object</param>
        /// <returns>a true or false statement</returns>
        public static bool operator == (Route a, Route b)
        {
            return a.FirstCity == b.FirstCity && a.SecondCity == b.SecondCity && a.Distance == b.Distance;
        }

        /// <summary>
        /// Override for != operator
        /// </summary>
        /// <param name="a">One class object</param>
        /// <param name="b">Another class object</param>
        /// <returns>a true or false statement</returns>
        public static bool operator != (Route a, Route b)
        {
            return a.FirstCity != b.FirstCity && a.SecondCity != b.SecondCity && a.Distance != b.Distance;
        }

        /// <summary>
        /// Override for Equals() method
        /// </summary>
        /// <param name="obj">Another class object</param>
        /// <returns>a true or false statement</returns>
        public override bool Equals(object obj)
        {
            Route route = obj as Route;
            return FirstCity.Equals(route.FirstCity) && SecondCity.Equals(route.SecondCity) && Distance.Equals(route.Distance);
        }
        /// <summary>
        /// GetHashCode() method override
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return FirstCity.GetHashCode() ^ SecondCity.GetHashCode() ^ Distance.GetHashCode();
        }

        /// <summary>
        /// ToString() method override
        /// </summary>
        /// <returns>a line of string</returns>
        public override string ToString()
        {
            string line = String.Format("|{0, -20}|{1, -20}|{2, 15}", FirstCity, SecondCity, Distance);
            return line;
        }
    }
}
