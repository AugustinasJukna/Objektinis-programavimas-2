using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1_WebApp
{
    public class TaskUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Finds all the vertices and lists them (uses recursion)
        /// </summary>
        /// <param name="matrix">all data container</param>
        /// <param name="startRow">starting row</param>
        /// <param name="vertices">list of all the vertices</param>
        public static void FindVertices(Matrix matrix, int startRow, List<Vertice> vertices) 
        {
            int plusesCount = 0;
            Vertice vertice = new Vertice();
            for (int j = 0; j < matrix.Columns; j++)
            {
                if (matrix.Get(startRow, j) == '*') //if char == '*', that means, it's i and j, will be the row and the column of the vertice
                {
                    vertice.Row = startRow;
                    vertice.Column = j;
                }

                else if (matrix.Get(startRow, j) == '+') //counts how many connections does this vertice has
                {
                    plusesCount++;
                }
            }
            vertice.Pluses = plusesCount;
            vertices.Add(vertice);

            if (startRow == matrix.Rows - 1) //returns to prevent errors
            {
                return;
            }

            else
            {
                FindVertices(matrix, startRow + 1, vertices);
            }
        }

        /// <summary>
        /// Sorts through all the vertices and finds their hierarchy
        /// </summary>
        /// <param name="matrix">data container</param>
        /// <param name="vertices">list of all the vertices</param>
        public static void NameVertices(Matrix matrix, List<Vertice> vertices)
        {
            string sting = "Geluonis", tail = "Uodega", waist = "Liemuo", leg = "koja";
            bool flag1 = true, flag2 = true; //keeps method usage in check, so that certain methods would be used once only
            int legCount = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertice vertice = vertices[i];
                if (vertice.Pluses == 1 && flag1)
                {
                    for (int j = 0; j < vertices.Count; j++)//starts a new loop to find a suitable vertice that connects to it
                    {
                        Vertice vertice2 = vertices[j];
                        if (ChecksConnection(matrix, vertice.Row, vertice2.Row) && vertice2.Pluses == 2)
                        {
                            vertices[j].Name = tail;
                            vertices[i].Name = sting;
                            i = 0; //starts a new cycle of loop to not miss any vertices
                            flag1 = false;  //to keep the method from repeating
                            break;
                        }
                    }
                }

                if (IsTheVerticeFound(vertices, tail) && vertice.Pluses >= 2 && flag2)
                {
                    Vertice vertice2 = vertices[ReturnIndexByName(vertices, tail)];
                    if (ChecksConnection(matrix, vertice.Row, vertice2.Row))//checks if  both of the vertices have a connection ('+')
                    {
                        vertices[i].Name = waist;
                        i = 0;
                        flag2 = false; //to keep the method from repeating
                    }
                }

                if (IsTheVerticeFound(vertices, waist) && vertice.Pluses >= 1 && !flag1 && !flag2) //this method will start the last, because both flag1 and flag2 have to be false
                {
                    Vertice vertice2 = vertices[ReturnIndexByName(vertices, waist)];
                    if (ChecksConnection(matrix, vertice.Row, vertice2.Row))//checks connection
                    {
                        legCount++;//counts the legs
                        vertices[i].Name = legCount + " " + leg;
                    }
                }

            }
        }

        /// <summary>
        /// Checks if the vertices connect together
        /// </summary>
        /// <param name="matrix">data container</param>
        /// <param name="vertice1Row">first vertice to check</param>
        /// <param name="vertice2Row">second vertice to check</param>
        /// <returns>returns a true or false statement</returns>
        public static bool ChecksConnection(Matrix matrix, int vertice1Row, int vertice2Row)
        {
            if (matrix.Get(vertice2Row, vertice1Row) == '+')
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the vertice is already in the list and named
        /// </summary>
        /// <param name="vertices">list of all the vertices</param>
        /// <param name="name">name of the needed vertice</param>
        /// <returns>a true or false statement</returns>
        public static bool IsTheVerticeFound(List<Vertice> vertices, string name)
        {
            foreach (Vertice vertice in vertices)
            {
                if (vertice.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns a vertice's index by name
        /// </summary>
        /// <param name="vertices">list of all the vertices</param>
        /// <param name="name">name of the vertice</param>
        /// <returns>true or false statement</returns>
        public static int ReturnIndexByName(List<Vertice> vertices, string name)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Sorts the list in a custom manner
        /// </summary>
        /// <param name="vertices">list of all the vertices</param>
        public static void CustomListSort(List<Vertice> vertices)
        {
            string sting = "Geluonis", tail = "Uodega", waist = "Liemuo";
            Vertice temp = new Vertice();
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Name == sting)
                {
                    temp = vertices[0];
                    vertices[0] = vertices[i];
                    vertices[i] = temp;
                }

                if (vertices[i].Name == tail)
                {
                    temp = vertices[1];
                    vertices[1] = vertices[i];
                    vertices[i] = temp;
                }

                if (vertices[i].Name == waist)
                {
                    temp = vertices[2];
                    vertices[2] = vertices[i];
                    vertices[i] = temp;
                }
            } 
        }
        /// <summary>
        /// Checks if the matrix is scorpion
        /// </summary>
        /// <param name="vertices">list of all the vertices</param>
        /// <returns>a true or false statement</returns>
        public static bool IsScorpion(List<Vertice> vertices)
        {
            foreach (Vertice vertice in vertices)
            {
                if (vertice.Name == null)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
