using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD2
{
    class CityLList
    {
        private CityNode Head;
        private CityNode Tail;

        public CityLList()
        {
            this.Head = null;
            this.Tail = null;
        }

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

        }

        public void StartingPoint()
        {
            this.Tail = this.Head;
        }

        public void Next()
        {
            this.Tail = this.Tail.Link;
        }

        public bool While()
        {
            return this.Tail != null;
        }

        public City ReturnCurrent()
        {
            return this.Tail.Value;
        }

        public long ReturnCitizensByName(string cityName)
        {
            for (CityNode w = this.Tail; w != null; w = w.Link)
            {
                if (w.Value.Name == cityName)
                {
                    return w.Value.Citizens;
                }
            }
            return -1;
        }

    }
}
