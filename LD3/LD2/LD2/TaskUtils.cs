using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3
{
    class TaskUtils
    {
        public static LinkList<Route> FindRoutes(string startingCity, long maxCitizens, int minDistance, LinkList<Route> AllRoutes, LinkList<City> AllCities)
        {
            LinkList<Route> possibleRoutes = new LinkList<Route>();
            LinkList<Route> w = AllRoutes;
            for (w.StartingPoint(); w.While(); w.Next())
            {
                if ((w.ReturnCurrent().FirstCity == startingCity && w.ReturnCurrent().Distance >= minDistance) || (w.ReturnCurrent().FirstCity != startingCity && AllRoutes.Connection(startingCity, w.ReturnCurrent()) && w.ReturnCurrent().Distance >= minDistance && AllCities.ReturnCitizensByName(w.ReturnCurrent().FirstCity) <= maxCitizens
                    && AllCities.ReturnCitizensByName(w.ReturnCurrent().SecondCity) <= maxCitizens))
                {
                    possibleRoutes.Add(w.ReturnCurrent());
                }
            }
            return possibleRoutes;
        }


    }
}
