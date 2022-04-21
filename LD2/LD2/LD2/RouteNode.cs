using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2
{
    sealed class RouteNode
    {
        public Route Value { get; set; }
        public RouteNode Link { get; set; }
        public RouteNode() { }
        public RouteNode(Route value, RouteNode link)
        {
            this.Value = value;
            this.Link = link;
        }
    }
}
