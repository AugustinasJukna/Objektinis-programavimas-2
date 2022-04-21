using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    class RouteLList
    {
        private RouteNode head;
        private RouteNode d;
        public int Count { get; private set; } //count to have an easy and accessible way to check the count of list items

        public RouteLList() //constructor
        {
            this.head = null;
            this.Count = 0;
        }

        /// <summary>
        /// Adds a class object to the list (creates a new node)
        /// </summary>
        /// <param name="route">Route class object to add</param>
        public void Add(Route route)
        {
            head = new RouteNode(route, head);
            Count++;
        }

        /// <summary>
        /// Sets pointer d to a starting point
        /// </summary>
        public void StartingPoint() => d = head;

        /// <summary>
        /// Checks if a pointer is equal to null or not
        /// </summary>
        /// <returns>true or false</returns>
        public bool While()
        {
            return d != null;
        }

        /// <summary>
        /// Makes pointer move forward in the list
        /// </summary>
        public void Next() => d = d.Link;

        /// <summary>
        /// Returns the value in which pointer is pointing
        /// </summary>
        /// <returns>value of pointer node</returns>
        public Route ReturnCurrent()
        {
            return this.d.Value;
        }

        /// <summary>
        /// Sorts this linked list
        /// </summary>
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

        /// <summary>
        /// Removes a specific object from the list
        /// </summary>
        /// <param name="cityName">name of the objects first or second city</param>
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
                    for (j = head; j.Link != current; j = j.Link); //finds the previous node
                    j.Link = current.Link;
                }

                current = current.Link;
            }
        }

        /// <summary>
        /// Checks if there are no duplicates in the list
        /// </summary>
        /// <param name="w">Route object to check the list for</param>
        /// <returns>true or false</returns>
        public bool FindDuplicates(Route w)
        {
            for (RouteNode temp = this.d; temp != null; temp = temp.Link)
            {
                if (temp.Value == w)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks a connection between cities (if for example: starting city is Kaunas, 
        /// </summary>                                          //route.FirstCity == "Kaunas"; route.SecondCity == "Vilnius"; There is a connection between them
        /// <param name="startingCity">user's inputed starting city</param>
        /// <param name="route">Route class object </param>
        /// <returns>true or false</returns>
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

        /// <summary>
        /// Appends all the routes from the list
        /// </summary>
        /// <param name="AllLines">string array which holds all the lines to print</param>
        /// <param name="index">array's place to assign variables to</param>
        public void AppendRoutes(string[] AllLines, ref int index)
        {
            if (Count == 0)
            {
                AllLines[index++] = "Tokių maršrutų nėra.";
                return;
            }

            AllLines[index++] = String.Format("|{0, -20}|{1, -20}|{2, 15}", "Pirmas miestas", "Antras miestas", "Atstumas");
            for (RouteNode w = head; w != null; w = w.Link)
            {
                AllLines[index++] = w.Value.ToString();
            }
            AllLines[index++] = String.Format("");
        }

    }
}
