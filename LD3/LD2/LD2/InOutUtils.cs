using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD3
{
    class InOutUtils
    {
        public static LinkList<Route> ReadFileA(string fileName)
        {
            LinkList<Route> AllRoutes = new LinkList<Route>();
            string line;
            using (var wholeFile = new StreamReader(fileName, Encoding.UTF8))
            {
                while ((line = wholeFile.ReadLine()) != null)
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

        public static LinkList<City> ReadFileB(string fileName)
        {
            LinkList<City> AllCities = new LinkList<City>();
            string[] AllLines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in AllLines)
            {
                string[] AllParts = line.Split(';');
                string name = AllParts[0];
                long citizens = long.Parse(AllParts[1]);
                City city = new City(name, citizens);
                AllCities.Add(city);
            }
            return AllCities;
        }
    }
}
