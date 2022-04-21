using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class TaskUtils
    {
        public static void FindVertices(Matrix matrix, int startRow, List<Vertice> vertices) 
        {
            int plusesCount = 0;
            Vertice vertice = new Vertice();
            for (int j = 0; j < matrix.Columns; j++)
            {
                if (matrix.Get(startRow, j) == '*')
                {
                    vertice.Row = startRow;
                    vertice.Column = j;
                }

                else if (matrix.Get(startRow, j) == '+')
                {
                    plusesCount++;
                }
            }
            vertice.Pluses = plusesCount;
            vertices.Add(vertice);

            if (startRow == matrix.Rows - 1)
            {
                return;
            }

            else
            {
                FindVertices(matrix, startRow + 1, vertices);
            }
        }

        public static void NameVertices(Matrix matrix, List<Vertice> vertices)
        {
            string sting = "Geluonis", tail = "Uodega", waist = "Liemuo", leg = "koja";
            bool flag1 = true, flag2 = true;
            int legCount = 0;
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertice vertice = vertices[i];
                if (vertice.Pluses == 1 && flag1)
                {
                    for (int j = 0; j < vertices.Count; j++)
                    {
                        Vertice vertice2 = vertices[j];
                        if (ChecksConnection(matrix, vertice.Row, vertice2.Row) && vertice2.Pluses == 2)
                        {
                            vertices[j].Name = tail;
                            vertices[i].Name = sting;
                            i = 0;
                            flag1 = false;
                            break;
                        }
                    }
                }

                if (IsTheVerticeFound(vertices, tail) && vertice.Pluses >= 2 && flag2)
                {
                    Vertice vertice2 = vertices[ReturnIndexByName(vertices, tail)];
                    if (ChecksConnection(matrix, vertice.Row, vertice2.Row))
                    {
                        vertices[i].Name = waist;
                        i = 0;
                        flag2 = false;
                    }
                }

                if (IsTheVerticeFound(vertices, waist) && vertice.Pluses >= 1 && !flag1 && !flag2)
                {
                    Vertice vertice2 = vertices[ReturnIndexByName(vertices, waist)];
                    if (ChecksConnection(matrix, vertice.Row, vertice2.Row))
                    {
                        legCount++;
                        vertices[i].Name = legCount + " " + leg;
                    }
                }

            }
        }

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
    }
}
