using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_1
{
    class InOutUtils
    {
        public static Matrix ReadFile(string fileName)
        {
            string[] AllLines = File.ReadAllLines(fileName);
            int n = Int32.Parse(AllLines[0]);
            Matrix allData = new Matrix(n);
            for (int i = 0; i < allData.Rows; i++)
            {
                for (int j = 0; j < allData.Columns; j++)
                { 
                    char c = AllLines[i + 1][j];
                    allData.Add(i, j, c);
                }
            }
            return allData;
        }
    }
}
