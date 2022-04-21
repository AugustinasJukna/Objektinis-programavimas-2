using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    sealed class CityNode
    {
        public City Value { get; set; }
        public CityNode Link { get; set; }
        public CityNode() { } //empty constructor
        public CityNode(City value, CityNode link) //constructor with two variables
        {
            this.Value = value;
            this.Link = link;
        }

    }
}
