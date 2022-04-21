using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2
{
    class RouteLList
    {
        private RouteNode head;
        private RouteNode d;

        public RouteLList()
        {
            this.head = null;
        }

        public void Add(Route route)
        {
            head = new RouteNode(route, head);
        }

        public void StartingPoint() => d = head;

        public bool While()
        {
            return d != null;
        }

        public void Next() => d = d.Link;

        public Route ReturnCurrent()
        {
            return this.d.Value;
        }

        public void Sort()
        {
            RouteNode a = this.head;
            while (a != null)
            {
                RouteNode b = a;
                RouteNode min = a;
                while (b != null)
                {
                    if (min.Value.CompareTo(b.Value) > 0)
                    {
                        min = b;
                    }
                    b = b.Link;
                }
                Route temp = a.Value;
                a.Value = min.Value;
                min.Value = temp;
                a = a.Link;
            }
        }
        public void Remove(string cityName)
        {
            RouteNode current = head;
            while (current != null)
            {
                if ((current.Value.FirstCity == cityName || current.Value.SecondCity == cityName) && current == head)
                {
                    head = head.Link;
                }

                else if ((current.Value.FirstCity == cityName || current.Value.SecondCity == cityName))
                {
                    RouteNode j;
                    for (j = head; j.Link != current; j = j.Link) ;
                    j.Link = current.Link;
                }

                current = current.Link;
            }
        }

        public bool FindDuplicates(RouteLList w)
        {
            for (RouteNode temp = this.d; temp != null; temp = temp.Link)
            {
                if (temp.Value == w.ReturnCurrent())
                {
                    return true;
                }
            }
            return false;
        }

        public bool Connection(string startingCity, Route route)
        {
            for (RouteNode w = head; w != null; w = w.Link)
            {
                if (w.Value.FirstCity == startingCity && w.Value.SecondCity == route.FirstCity)
                { 
                    return true;
                }
            }
            return false;
        }

    }
}
