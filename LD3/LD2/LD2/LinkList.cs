using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3
{
    class LinkList<Type> where Type : IComparable<Type>, IEquatable<Type>
    {
        private Node<Type> Head;
        private Node<Type> Tail;

        public LinkList()
        {
            this.Head = null;
            this.Tail = null;
        }

        public void Add(Type value)
        {
            Node<Type> newNode = new Node<Type>(value, null);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }

            else
            {
                Tail.Link = newNode;
                Tail = newNode;
            }

        }

        public void StartingPoint() => this.Tail = this.Head;

        public void Next()
        {
            this.Tail = this.Tail.Link;
        }

        public bool While()
        {
            return this.Tail != null;
        }

        public Type ReturnCurrent() => Tail.Value;

        public long ReturnCitizensByName(string cityName)
        {
            if (!(this is LinkList<City>))
            {
                return -1;
            }

            for (Node<Type> w = Head; w != null; w = w.Link)
            {
                    var obj = w.Value as City;
                    if (obj.Name == cityName) return obj.Citizens;
            }
            return -1;
        }

        public void Sort()
        {
            if (!(this is LinkList<Route>)) return;
            Node<Type> a = Head;
            while (a != null)
            {
                Node<Type> b = a;
                Node<Type> min = a;
                while (b != null)
                {
                    if (min.Value.CompareTo(b.Value) > 0)
                    {
                        min = b;
                    }
                    b = b.Link;
                }

                var temp= a.Value;
                a.Value = min.Value;
                min.Value = temp;
                a = a.Link;
            }
        }

        public void RemoveRoutes(string cityName)
        {
            if (!(this is LinkList<Route>)) return;
            Node<Type> current = Head;
            while (current != null)
            {
                Node<Route> route = current as Node<Route>;
                if ((route.Value.FirstCity == cityName || route.Value.SecondCity == cityName) && current == Head)
                {
                    Head = Head.Link;
                }

                else if ((route.Value.FirstCity == cityName || route.Value.SecondCity == cityName))
                {
                    Node<Type> j;
                    for (j = Head; j.Link != current; j = j.Link) ;
                    j.Link = current.Link;
                }

                current = current.Link;
            }
        }

        public bool FindDuplicates(LinkList<Type> w, string className)
        {
            for (Node<Type> temp = Head; temp != null; temp = temp.Link)
            {
                if (w is LinkList<Route> && temp.Value as Route == w.ReturnCurrent() as Route)
                {
                    return true;
                }

                if (w is LinkList<City> && temp.Value as City == w.ReturnCurrent() as City)
                {
                    return true;
                }

            }
            return false;
        }

        public bool Connection(string startingCity, Route route)
        {
            if (!(this is LinkList<Route>)) return false;
            for (Node<Type> w = Head; w != null; w = w.Link)
            {
                var temp = w.Value as Route;
                if (temp.FirstCity == startingCity && temp.SecondCity == route.FirstCity)
                {
                    return true;
                }
            }
            return false;
        }

    }

}
