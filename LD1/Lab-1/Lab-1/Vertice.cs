using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Vertice
    {
        public string Name { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int Pluses { get; set; }

        public Vertice(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Vertice()
        {
            this.Row = -1;
            this.Column = -1;
        }
    }
}
