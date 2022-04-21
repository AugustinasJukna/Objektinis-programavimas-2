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
        /// Main method of the whole program. Finds all the route combinations which fit the requirements
        /// </summary>
        /// <param name="startingCity">user's inputed starting city</param>
        /// <param name="maxCitizens">max citizens in a city</param>
        /// <param name="minDistance">minimum distance in a route</param>
        /// <param name="AllRoutes">list of all the routes</param>
        /// <param name="AllCities">list of all the cities</param>
        /// <returns></returns>
        public static RouteLList FindRoutes(string startingCity, long maxCitizens, int minDistance, RouteLList w, CityLList AllCities)
        {
            RouteLList possibleRoutes = new RouteLList();
            for (w.StartingPoint(); w.While(); w.Next())
            {
                if (((w.ReturnCurrent().FirstCity == startingCity && w.ReturnCurrent().Distance >= minDistance) || (w.ReturnCurrent().FirstCity != startingCity && w.Connection(startingCity, w.ReturnCurrent()) && w.ReturnCurrent().Distance >= minDistance && AllCities.ReturnCitizensByName(w.ReturnCurrent().FirstCity) <= maxCitizens
                    && AllCities.ReturnCitizensByName(w.ReturnCurrent().SecondCity) <= maxCitizens)) && !possibleRoutes.FindDuplicates(w.ReturnCurrent()))
                {
                    possibleRoutes.Add(w.ReturnCurrent());
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
