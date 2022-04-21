using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD2_WebApp
{
    class TaskUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Finds all routes that fit the criteria
        /// </summary>
        /// <param name="startingCity">name of the starting city(chosen by user)</param>
        /// <param name="maxCitizens">maximum amount of citizens allowed in a city (chosen by user)</param>
        /// <param name="minDistance">minimum route distance</param>
        /// <param name="AllRoutes">All routes from starting file</param>
        /// <param name="AllCities">All cities from starting file</param>
        /// <returns></returns>
        public static LinkList<Route> FindRoutes(string startingCity, long maxCitizens, int minDistance, LinkList<Route> AllRoutes, LinkList<City> AllCities)
        {
            LinkList<Route> possibleRoutes = new LinkList<Route>();
            foreach (Route route in AllRoutes)
            {
                if (((route.FirstCity == startingCity && route.Distance >= minDistance) || (route.FirstCity != startingCity && AllRoutes.Connection(startingCity, route) && route.Distance >= minDistance && AllCities.ReturnCitizensByName(route.FirstCity) <= maxCitizens
                    && AllCities.ReturnCitizensByName(route.SecondCity) <= maxCitizens)) && !possibleRoutes.Contains(route))
                {
                    possibleRoutes.Add(route);
                }
            }
            return possibleRoutes;
        }

        /// <summary>
        /// Returns a row with specific test
        /// </summary>
        /// <param name="text">text to put in a row</param>
        /// <param name="n">amount of cell's column span</param>
        /// <returns></returns>
        public static TableRow ReturnRowWithText(string text, int n)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell { Text = text, ColumnSpan = n });
            return row;
        }
    }
}
