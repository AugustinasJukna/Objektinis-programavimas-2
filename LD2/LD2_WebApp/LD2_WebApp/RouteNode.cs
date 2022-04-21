using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    sealed class RouteNode
    {
        public Route Value { get; set; }
        public RouteNode Link { get; set; }
        public RouteNode() { } //empty constructor
        public RouteNode(Route value, RouteNode link) //cosntructor with two variables
        {
            this.Value = value;
            this.Link = link;
        }
    }
}
