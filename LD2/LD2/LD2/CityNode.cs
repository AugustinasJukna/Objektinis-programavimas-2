using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2
{
    class CityNode
    {
        public City Value { get; set; }
        public CityNode Link { get; set; }
        public CityNode() { }
        public CityNode(City value, CityNode link)
        {
            this.Value = value;
            this.Link = link;
        }

    }
}
