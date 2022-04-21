using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2_WebApp
{
    class CityLList
    {
        private CityNode Head;
        private CityNode Tail;
        public int Count { get; private set; }

        public CityLList()
        {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }

        /// <summary>
        /// Adds a new element (City class object) to the linked list
        /// </summary>
        /// <param name="city">object to add</param>
        public void Add(City city)
        {
            CityNode newNode = new CityNode(city, null);
            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
            }

            else
            {
                this.Tail.Link = newNode;
                this.Tail = newNode;
            }
            Count++;
        }

        /// <summary>
        /// Sets tail to the starting point - head
        /// </summary>
        public void StartingPoint()
        {
            this.Tail = this.Head;
        }

        /// <summary>
        /// Forces nodes to move
        /// </summary>
        public void Next()
        {
            this.Tail = this.Tail.Link;
        }

        /// <summary>
        /// Keeps in check if the tail is equal to null or not
        /// </summary>
        /// <returns></returns>
        public bool While()
        {
            return this.Tail != null;
        }
        /// <summary>
        /// Returns the current tail's value
        /// </summary>
        /// <returns></returns>
        public City ReturnCurrent()
        {
            return this.Tail.Value;
        }

        /// <summary>
        /// Returns the amount of citizens by city name
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>amount of citizens in the city</returns>
        public long ReturnCitizensByName(string cityName)
        {
            for (CityNode w = this.Tail; w != null; w = w.Link)
            {
                if (w.Value.Name == cityName)
                {
                    return w.Value.Citizens;
                }
            }
            return 0;
        }
        /// <summary>
        /// Appends all cities from the linked list to a string array
        /// </summary>
        /// <param name="AllLines">name of the array</param>
        /// <param name="index">index which shows in which array's place to put data in</param>
        public void AppendCities(string[] AllLines, ref int index)
        {
            if (Count == 0)
            {
                AllLines[index++] = "Miestų nėra.";
                return;
            }

            AllLines[index++] = String.Format("|{0, -20}|{1, 20}", "Miesto pavadinimas", "Gyventojų kiekis");
            for (CityNode w = Head; w != null; w = w.Link)
            {
                AllLines[index++] = w.Value.ToString();
            }
            AllLines[index++] = String.Format("");
        }

    }
}
