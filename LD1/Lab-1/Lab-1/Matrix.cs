using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Matrix
    {
        private char[,] V;
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Matrix(int n)
        {
            this.V = new char[n, n];
            this.Rows = n;
            this.Columns = n;
        }

        public void Add(int i, int j, char character)
        {
            this.V[i, j] = character;
        }

        public char Get(int i, int j)
        {

            return this.V[i, j];
        }



    }
}
