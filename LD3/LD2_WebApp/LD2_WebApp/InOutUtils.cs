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
        public static LinkList<Route> ReadFileA(StreamReader wholeFile)
        {
            LinkList<Route> AllRoutes = new LinkList<Route>();
            using (wholeFile)
            {
                for (string line = wholeFile.ReadLine(); line != null; line = wholeFile.ReadLine())
                {
                    string[] AllParts = line.Split(';');
                    string cityA = AllParts[0];
                    string cityB = AllParts[1];
                    int distance = int.Parse(AllParts[2]);
                    Route route = new Route(cityA, cityB, distance);
                    AllRoutes.Add(route);
                }
            }
            return AllRoutes;
        }

        public static LinkList<City> ReadFileB(StreamReader wholeFile)
        {
            LinkList<City> AllCities = new LinkList<City>();
            string line;
            using (wholeFile)
            {
                while ((line = wholeFile.ReadLine()) != null)
                {
                    string[] AllParts = line.Split(';');
                    string name = AllParts[0];
                    long citizens = long.Parse(AllParts[1]);
                    City city = new City(name, citizens);
                    AllCities.Add(city);
                }
            }
            return AllCities;
        }

        /// <summary>
        /// Fills RouteLList table on screen
        /// </summary>
        /// <param name="table">table to modify</param>
        /// <param name="filler">list to take data from</param>
        public static void FillRoutesTableOnScreen(Table table, LinkList<Route> filler)
        {
            if (filler == null || filler.Count() == 0)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { ColumnSpan = 3, Text = "Maršrutų nėra." });
                table.Rows.Add(row);
                return;
            }
            table.Rows.Add(HeaderRowA());
            foreach (Route route in filler)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = route.FirstCity });
                row.Cells.Add(new TableCell { Text = route.SecondCity });
                row.Cells.Add(new TableCell { Text = (route.Distance).ToString() });
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Fills CityLList table on screen
        /// </summary>
        /// <param name="table">table to modify</param>
        /// <param name="filler">CityLList object to take data from</param>
        public static void FillCitiesTableOnScreen<Type>(Table table, IEnumerable<Type> filler) where Type : IReturnable
        {
            if (filler.Count() == 0)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { ColumnSpan = 3, Text = "Miestų nėra." });
                table.Rows.Add(row);
                return;
            }
            table.Rows.Add(HeaderRowB());
            foreach (Type t in filler)
            {
                TableRow row = new TableRow();
                string[] line = (t.ReturnDivisibleLine()).Split(';');
                row.Cells.Add(new TableCell { Text = line[0] });
                row.Cells.Add(new TableCell { Text = (line[1])});
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
        public static string[] PrintData(LinkList<Route> start1, LinkList<City> start2, LinkList<Route> end)
        {
            string[] AllLines = new string[start1.Count() + start2.Count() + end.Count() + 8];
            int index = 0;
            AllLines[index++] = String.Format("Pradiniai duomenys");
            start1.Append(AllLines, ref index);
            AllLines[index++] = String.Empty;
            start2.Append(AllLines, ref index);
            AllLines[index++] = String.Empty;
            AllLines[index++] = String.Format("Rezultatai");
            end.Append(AllLines, ref index);

            return AllLines;
        }
    }
}
