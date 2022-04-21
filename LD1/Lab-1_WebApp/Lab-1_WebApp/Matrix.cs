using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_WebApp
{
    public class Matrix
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
        /// <summary>
        /// Adds a char to a specific place in the container
        /// </summary>
        /// <param name="i">row to put the object in</param>
        /// <param name="j">column to put the object in</param>
        /// <param name="character">object</param>
        public void Add(int i, int j, char character)
        {
            this.V[i, j] = character;
        }

        /// <summary>
        /// Gets an object from a specific place
        /// </summary>
        /// <param name="i">row to take object from</param>
        /// <param name="j">column to take object from</param>
        /// <returns>the object</returns>
        public char Get(int i, int j)
        {

            return this.V[i, j];
        }



    }
}
