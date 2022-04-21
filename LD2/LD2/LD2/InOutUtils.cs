using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LD2
{
    class InOutUtils
    {
        public static RouteLList ReadFileA(string fileName)
        {
            RouteLList routeList = new RouteLList();
            string[] AllLines = File.ReadAllLines(fileName, Encoding.UTF8);
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

        public static CityLList ReadFileB(string fileName)
        {
            CityLList cityList = new CityLList();
            string[] AllLines = File.ReadAllLines(fileName, Encoding.UTF8);
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
    }
}
