using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LD2_WebApp;

namespace LD2_WebAppTests
{
    //Testing with Route class
    public class LinkListTests<T> where T : IComparable<T>, IEquatable<T>
    {
        LinkList<Route> Routes = new LinkList<Route>();

        [Fact]
        public void Should_Be_Null()
        {
            Routes = new LinkList<Route>();

            Assert.Null(Routes.ReturnCurrent());
        }

        [Fact]
        public void Should_Add_To_Beginning()
        {
            Routes = new LinkList<Route>();

            Routes.Add(new Route("Kaunas", "Panevėžys", 113));

            Route expected = new Route("Kaunas", "Panevėžys", 113);

            Assert.Equal(Routes.ReturnCurrent(), expected);
        }

        [Fact]
        public void Should_Add_New_Objects()
        {
            int expected = 3;

            Routes = new LinkList<Route>();

            Route route1 = new Route("Kaunas", "Vilnius", 100);
            Route route2 = new Route("Kaunas", "Panevėžys", 113);
            Route route3 = new Route("Kaunas", "Klaipėda", 150);

            Routes.Add(route1);
            Routes.Add(route2);
            Routes.Add(route3);

            Assert.Equal(Routes.Count(), expected);
        }

        [Fact]
        public void StartingPoint_Should_Be_Head()
        {
            Route expected = new Route("Kaunas", "Panevėžys", 113);

            Routes = new LinkList<Route>();

            Routes.Add(expected);
            Routes.Add(new Route("", "", 0));

            Routes.StartingPoint();

            Assert.Equal(Routes.ReturnCurrent(), expected);
        }

        [Fact]
        public void Next_Should_Point_Forward()
        {
            Route expected = new Route("Kaunas", "Panevėžys", 113);

            Routes = new LinkList<Route>();

            Routes.Add(new Route("", "", 0));
            Routes.Add(expected);

            Routes.StartingPoint();
            Routes.Next();

            Assert.Equal(Routes.ReturnCurrent(), expected);
        }

        [Fact]
        public void While_Should_Return_False()
        {
            bool expected = false;

            Routes = new LinkList<Route>();

            bool result = Routes.While();

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Should_Return_Current_Latest_Object()
        {
            Route expected = new Route("", "", 0);

            Routes = new LinkList<Route>();

            Routes.Add(expected);

            Assert.Equal(Routes.ReturnCurrent(), expected);
        }

        [Theory]
        [InlineData(100000)]
        [InlineData(100)]
        [InlineData(9764645)]
        public void Should_Return_Citizens_By_Object_Type(long expected)
        {
                    LinkList<City> Cities = new LinkList<City>();

                    Cities.Add(new City("Test1", 100000));
                    Cities.Add(new City("Test2", 100000));
                    Cities.Add(new City("Test3", 50000));
                    Cities.Add(new City("Test", expected));
                    Cities.Add(new City("Test4", 600000));

                    long result = Cities.ReturnCitizensByName("Test");

                    Assert.Equal(result, expected);
        }

        [Fact]
        public void Should_Return_Negative_One()
        {
            int expected = -1;

            Routes = new LinkList<Route>();

            Assert.Equal(Routes.ReturnCitizensByName(""), expected);
        }

        [Fact]
        public void Should_Sort_Correctly_By_Distance()
        {
            Route expected = new Route("A", "", 5);
            Routes = new LinkList<Route>();

            Routes.Add(new Route("F", "", 1000));
            Routes.Add(new Route("C", "", 100));
            Routes.Add(expected);
            Routes.Add(new Route("A", "", 70));

            Routes.Sort();

            Routes.StartingPoint();

            Assert.Equal(Routes.ReturnCurrent(), expected);
        }

        [Fact]
        public void Should_Sort_Correctly_By_FirstCity()
        {
            Route expected = new Route("A", "", 70);
            Routes = new LinkList<Route>();

            Routes.Add(new Route("F", "", 1000));
            Routes.Add(new Route("B", "", 70));
            Routes.Add(new Route("C", "", 100));
            Routes.Add(expected);

            Routes.Sort();

            Routes.StartingPoint();

            Assert.Equal(Routes.ReturnCurrent(), expected);
        }

        [Fact]
        public void Should_RemoveRoutes()
        {
            string indicator = "A";

            Routes = new LinkList<Route>();

            Routes.Add(new Route("B", "", 100000));
            Routes.Add(new Route(indicator, "", 100000));
            Routes.Add(new Route("C", "", 1000000));
            Routes.Add(new Route("", indicator, 100000));

            Routes.RemoveRoutes(indicator);

            bool checker = true, results = false;

            foreach (Route route in Routes)
            {
                if (route.FirstCity == indicator || route.SecondCity == indicator)
                {
                    checker = false;
                }
            }

            if (checker && Routes.Count() == 2)
            {
                results = true;
            }

            Assert.True(results);
        }

        [Fact]
        public void Should_Remove_First_Object()
        {
            Routes = new LinkList<Route>();

            Routes.Add(new Route("A", "", 100000));

            Routes.RemoveRoutes("A");

            Assert.False(Routes.Contains(new Route("A", "", 100000)));
        }

        [Fact]
        public void Should_Remove_Last_Object()
        {
            Routes = new LinkList<Route>();

            Routes.Add(new Route("A", "", 100000));
            Routes.Add(new Route("B", "", 100000));
            Routes.Add(new Route("C", "", 100000));
            Routes.Add(new Route("D", "", 100000));

            Routes.RemoveRoutes("D");

            Assert.False(Routes.Contains(new Route("D", "", 100000)));
        }

        [Fact]
        public void Should_Contain_Object()
        {
            Routes = new LinkList<Route>();

            Route duplicated = new Route("Duplicated", "B", 12121);

            Routes.Add(new Route("", "", 10000));
            Routes.Add(duplicated);
            Routes.Add(new Route("ABC", "", 1334545));
            Routes.Add(new Route("DEF", "", 67942));

            Assert.True(Routes.Contains(duplicated));
        }

        [Fact]
        public void Should_Find_A_Connection()
        {
            string startingCity = "Kaunas";
            Routes = new LinkList<Route>();

            Routes.Add(new Route(startingCity, "Vilnius", 12031));
            Route indicator = new Route("Vilnius", "Panevėžys", 1638456);

            Assert.True(Routes.Connection(startingCity, indicator));
        }

        [Fact]
        public void Should_Be_No_Connection()
        {
            string startingCity = "Kaunas";
            Routes = new LinkList<Route>();

            Routes.Add(new Route("Klaipėda", "Vilnius", 12031));
            Route indicator = new Route("Vilnius", "Panevėžys", 1638456);

            Assert.False(Routes.Connection(startingCity, indicator));
        }

        [Fact]
        public void Should_Count_Correctly()
        {
            int expected = 4;

            Routes = new LinkList<Route>();
            Routes.Add(new Route("", "", 0));
            Routes.Add(new Route("", "", 0));
            Routes.Add(new Route("", "", 0));
            Routes.Add(new Route("", "", 0));

            Assert.Equal(Routes.Count(), expected);
        }

        [Fact]
        public void Should_Append_Objects()
        {
            bool result = false;

            Routes = new LinkList<Route>();

            Routes.Add(new Route("", "", 0));
            Routes.Add(new Route("", "", 1));

            string[] ToStringLines = new string[Routes.Count() + 1];

            int ind = 0;
            Routes.Append(ToStringLines, ref ind);

            if (ToStringLines[ind - 2] == (new Route("", "", 0)).ToString() && ToStringLines[ind - 1] == (new Route("", "", 1)).ToString())
            {
                result = true;
            }

            Assert.True(result);
        }

        [Fact]
        public void Should_Append_Error_Message()
        {
            string expected = "Tokių maršrutų nėra.";

            Routes = new LinkList<Route>();

            string[] ToStringLines = new string[Routes.Count() + 1];

            int ind = 0;
            Routes.Append(ToStringLines, ref ind);

            Assert.Equal(ToStringLines[0], expected);
        }

        [Fact]
        public void Should_Use_GetEnumerator_Correctly()
        {
            Route expected = new Route("A", "B", 10000);

            Routes = new LinkList<Route>
            {
                expected
            };

            Route result = null;


            foreach (Route route in Routes)
            {
                result = route;
            }

            Assert.Equal(expected, result);
        }
    }
}
