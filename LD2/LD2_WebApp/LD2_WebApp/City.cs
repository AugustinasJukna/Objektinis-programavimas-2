using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    class City
    {
        public string Name { get; set; }
        public long Citizens { get; set; }

        public City(string city, long citizens)
        {
            this.Name = city;
            this.Citizens = citizens;
        }
        /// <summary>
        /// ToString method override
        /// </summary>
        public override string ToString()
        {
            string line = String.Format("|{0, -20}|{1, 20}", Name, Citizens);
            return line;
        }

    }
}
