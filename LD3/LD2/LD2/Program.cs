using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            const string CFdA = "U8a.txt";
            const string CFdB = "U8b.txt";
            LinkList<Route> AllRoutes = InOutUtils.ReadFileA(CFdA);
            LinkList<City> AllCities = InOutUtils.ReadFileB(CFdB);

            LinkList<Route> Results = TaskUtils.FindRoutes("Kaunas", 1000000, 100, AllRoutes, AllCities);
            Results.Sort();

            for (Results.StartingPoint(); Results.While(); Results.Next())
            {
                Console.WriteLine(Results.ReturnCurrent().FirstCity + "  " + Results.ReturnCurrent().Distance + "  " + Results.ReturnCurrent().SecondCity);
            }
            Console.WriteLine("");

            Results.RemoveRoutes("Vilnius");
            for (Results.StartingPoint(); Results.While(); Results.Next())
            {
                Console.WriteLine(Results.ReturnCurrent().FirstCity + "  " + Results.ReturnCurrent().Distance + "  " + Results.ReturnCurrent().SecondCity);
            }

        }
    }
}
