using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2
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

    }
}
