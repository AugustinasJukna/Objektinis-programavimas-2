using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFD = "U3.txt";
            Matrix graphMatrix = InOutUtils.ReadFile(CFD);
            List<Vertice> allVertices = new List<Vertice>();
            TaskUtils.FindVertices(graphMatrix, 0, allVertices);
            TaskUtils.NameVertices(graphMatrix, allVertices);

            foreach(Vertice vertice in allVertices)
            {
                Console.WriteLine(vertice.Name + " " + vertice.Row + " " + vertice.Column);
            }
        }
    }
}
