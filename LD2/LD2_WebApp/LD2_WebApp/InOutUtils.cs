using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LD2_WebApp
{
    class InOutUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Reads the input file's data (U8a.txt)
        /// </summary>
        /// <param name="AllLines">string array which holds file's data</param>
        /// <returns>a made list of RouteLList </returns>
        public static RouteLList ReadFileA(string[] AllLines)
        {
            RouteLList routeList = new RouteLList();
            foreach (string line in AllLines)
            {
                string[] AllParts = line.Split(';');
                string cityA = AllParts[0];
                string cityB = AllParts[1];
                int distance = int.Parse(AllParts[2]);
                Route route = new Route(cityA, cityB, distance);
                routeList.Add(route);
            }
            return routeList;
        }

        /// <summary>
        /// Reads the input file's data (U8b.txt)
        /// </summary>
        /// <param name="AllLines">string array which holds all the data from the file</param>
        /// <returns>returns CityLList object</returns>
        public static CityLList ReadFileB(string[] AllLines)
        {
            CityLList cityList = new CityLList();
            foreach (string line in AllLines)
            {
                string[] AllParts = line.Split(';');
                string name = AllParts[0];
                long citizens = long.Parse(AllParts[1]);
                City city = new City(name, citizens);
                cityList.Add(city);
            }
            return cityList;
        }

        /// <summary>
        /// Fills RouteLList table on screen
        /// </summary>
        /// <param name="table">table to modify</param>
        /// <param name="filler">list to take data from</param>
        public static void FillRoutesTableOnScreen(Table table, RouteLList filler)
        {
            if (filler == null || filler.Count == 0)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { ColumnSpan = 3, Text = "Maršrutų nėra." });
                table.Rows.Add(row);
                return;
            }
            table.Rows.Add(HeaderRowA());
            for (filler.StartingPoint(); filler.While(); filler.Next())
            {
                TableRow row = new TableRow();
                Route temp = filler.ReturnCurrent();
                row.Cells.Add(new TableCell { Text = temp.FirstCity });
                row.Cells.Add(new TableCell { Text = temp.SecondCity });
                row.Cells.Add(new TableCell { Text = (temp.Distance).ToString() });
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Fills CityLList table on screen
        /// </summary>
        /// <param name="table">table to modify</param>
        /// <param name="filler">CityLList object to take data from</param>
        public static void FillCitiesTableOnScreen(Table table, CityLList filler)
        {
            if (filler.Count == 0)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { ColumnSpan = 3, Text = "Miestų nėra." });
                table.Rows.Add(row);
                return;
            }
            table.Rows.Add(HeaderRowB());
            for (filler.StartingPoint(); filler.While(); filler.Next())
            {
                TableRow row = new TableRow();
                City temp = filler.ReturnCurrent();
                row.Cells.Add(new TableCell { Text = temp.Name });
                row.Cells.Add(new TableCell { Text = (temp.Citizens).ToString() });
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Header row for Route class objects
        /// </summary>
        /// <returns>a header row for the table</returns>
        public static TableRow HeaderRowA()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell { Text = "Pirmas miestas" });
            row.Cells.Add(new TableCell { Text = "Antras miestas" });
            row.Cells.Add(new TableCell { Text = "Atstumas tarp miestų" });
            return row;
        }

        /// <summary>
        /// Header row for City class objects
        /// </summary>
        /// <returns>a header row for the table</returns>
        public static TableRow HeaderRowB()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell { Text = "Miesto pavadinimas" });
            row.Cells.Add(new TableCell { Text = "Gyventojų kiekis" });
            return row;
        }

        /// <summary>
        /// Combines all the data and "prints" it into a string array
        /// </summary>
        /// <param name="start1">list of all the starting data (Route objects)</param>
        /// <param name="start2">list of all the starting data (City objects)</param>
        /// <param name="end">list of filtered Route class objects</param>
        /// <returns>a string array</returns>
        public static string[] PrintData(RouteLList start1, CityLList start2, RouteLList end)
        {
            string[] AllLines = new string[start1.Count + start2.Count + end.Count + 8];
            int index = 0;
            AllLines[index++] = String.Format("Pradiniai duomenys");
            start1.AppendRoutes(AllLines, ref index);
            start2.AppendCities(AllLines, ref index);
            AllLines[index++] = String.Format("Rezultatai");
            end.AppendRoutes(AllLines, ref index);

            return AllLines;
        }
    }
}
