using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    public class LinkList<Type> : IEnumerable<Type> where Type : IComparable<Type>, IEquatable<Type>
    {
        private Node<Type> Head;
        private Node<Type> Tail;

        /// <summary>
        /// Constructor
        /// </summary>
        public LinkList()
        {
            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// Adds a new object to the link list
        /// </summary>
        /// <param name="value">object to add</param>
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

        /// <summary>
        /// Sets the starting point to link list's head 
        /// </summary>
        public void StartingPoint() => this.Tail = this.Head;

        /// <summary>
        /// Moves the list's tail forward across the references
        /// </summary>
        public void Next()
        {
            this.Tail = this.Tail.Link;
        }

        /// <summary>
        /// Checks if the tail is equal to null
        /// </summary>
        /// <returns>true if tail is not equal to null and vice versa</returns>
        public bool While()
        {
            return this.Tail != null;
        }

        /// <summary>
        /// Returns current tail object (if the tail equals null, returns a null)
        /// </summary>
        /// <returns>object's value or null</returns>
        public Type ReturnCurrent()
        {
            if (Tail == null)
            {
                return default(Type);
            }

            return Tail.Value;
        }

        /// <summary>
        /// Returns the amount of citizens by the city's name
        /// </summary>
        /// <param name="cityName">name of the city</param>
        /// <returns>amount of citizens</returns>
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

        /// <summary>
        /// Sorts the link list by a specific order
        /// </summary>
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

        /// <summary>
        /// Removes Route objects from the list
        /// </summary>
        /// <param name="cityName">name of one of the cities in Route object to be removed </param>
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

        /// <summary>
        /// Checks if the list contains a specific object
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Contains(Type type)
        {
            for (Node<Type> temp = Head; temp != null; temp = temp.Link)
            {
                if (this is LinkList<Route> && temp.Value as Route == (type as Route))
                {
                    return true;
                }

                if (this is LinkList<City> && temp.Value as City == (type as City))
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Finds a connection between Route object and other routes
        /// </summary>
        /// <param name="startingCity">name of the user inputed starting city</param>
        /// <param name="route">Route object to compare with</param>
        /// <returns>if the Route object fits the criteria returns true and vice versa</returns>
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

        /// <summary>
        /// Returns the amount of objects in the list
        /// </summary>
        /// <returns>amount of list's objects</returns>
        public int Count()
        {
            int count = 0;
            for (Node<Type> a = Head; a != null; a = a.Link)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Adds link's objects to the string array
        /// </summary>
        /// <param name="AllLines">name of the string array</param>
        /// <param name="index">index to know which line is not taken</param>
        public void Append(string[] AllLines, ref int index)
        {
            if (Count() == 0 && this is LinkList<Route>)
            {
                AllLines[index++] = "Tokių maršrutų nėra.";
                return;
            }

            else if (Count() == 0 && this is LinkList<City>)
            {
                AllLines[index++] = "Miestų nėra.";
                return;
            }

            if (this is LinkList<Route>)
            {
                AllLines[index++] = String.Format("|{0, -20}|{1, -20}|{2, 15}|", "Pirmas miestas", "Antras miestas", "Atstumas");
            }

            if (this is LinkList<City>)
            {
                AllLines[index++] = String.Format("|{0, -20}|{1, 20}|", "Miesto pavadinimas", "Gyventojų kiekis");
            }

            foreach(Type type in this)
            {
                AllLines[index++] = type.ToString();
            }
        }

        /// <summary>
        /// GetEnumerator() (generic) method fill
        /// </summary>
        /// <returns>value of objects one by one</returns>
        public IEnumerator<Type> GetEnumerator()
        {
            for (Node<Type> w = Head; w != null; w = w.Link)
            {
                yield return w.Value;
            }
        }

        /// <summary>
        /// GetEnumerator() (generic) method fill
        /// </summary>
        /// <returns>value of objects one by one</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (Node<Type> w = Head; w != null; w = w.Link)
            {
                yield return w.Value;
            }
        }
    }

}
