using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_1_WebApp
{
    public class InOutUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Reads data file
        /// </summary>
        /// <param name="AllLines">Array of all the data</param>
        /// <returns>returns a Matrix class object</returns>
        public static Matrix ReadFile(string[] AllLines) 
        {
            int n = Int32.Parse(AllLines[0]);
            if (!ErrorProof.CheckTheN(n))
            {
                return null;
            }

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

        /// <summary>
        /// Forms a file name to fit system's settings 
        /// </summary>
        /// <param name="dropDownList">data file input</param>
        /// <returns>returns a fileName</returns>
        public static string FormFileName(DropDownList dropDownList)
        {
            string fileName = "App_Data/" + dropDownList.SelectedValue + ".txt";
            return fileName;
        }

        /// <summary>
        /// Changes label's text based on if a given matrix is a scorpion or not
        /// </summary>
        /// <param name="label">object to change text</param>
        public static void WriteIfScorpion(Label label)
        {
            label.Text = @"<strong>Matrica yra ""skorpionas"".</strong>";
        }
        /// <summary>
        /// If the matrix is not a scorpion, then changes label's text to fit accordingly
        /// </summary>
        /// <param name="label">object to change the text</param>
        public static void IfError(Label label)
        {
            label.Text = @"<strong>Ši matrica nėra ""skorpionas"".</strong>";
        }
        /// <summary>
        /// Returns a made cell
        /// </summary>
        /// <param name="text">cell's text input</param>
        /// <returns>a made cell</returns>
        public static TableCell ReturnCell(string text)
        {
            TableCell cell = new TableCell();
            cell.Text = text;
            return cell;
        }
        /// <summary>
        /// Creates table's header row
        /// </summary>
        /// <returns>a made header row for table</returns>
        public static TableRow HeaderRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(ReturnCell("Viršūnės pavadinimas"));
            row.Cells.Add(ReturnCell("Viršūnės numeris"));
            return row;
        }
        /// <summary>
        /// Forms a full table from inputs
        /// </summary>
        /// <param name="table">Displayed table</param>
        /// <param name="vertices">List of all the vertices</param>
        public static void FormTable(Table table, List<Vertice> vertices)
        {
            table.Rows.Add(HeaderRow());
            for (int i = 0; i < vertices.Count; i++)
            {
                TableRow row = new TableRow();
                row.Cells.Add(ReturnCell(vertices[i].Name));
                row.Cells.Add(ReturnCell((vertices[i].Row + 1).ToString()));
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Fills a table row with empty cells
        /// </summary>
        /// <param name="row">row to be filled</param>
        /// <param name="columns">how many cells to add</param>
        public static void FillTableRow(TableRow row, int columns)
        {
            for (int i = 0; i < columns; i++)
            {
                row.Cells.Add(ReturnCell(""));
            }
        }

        /// <summary>
        /// Creates starting data table for comparison
        /// </summary>
        /// <param name="table">table to display</param>
        /// <param name="matrix">data container</param>
        public static void StartingDataTable(Table table, Matrix matrix)
        {
            TableRow row0 = new TableRow();
            TableCell cell = ReturnCell("Pradiniai duomenys");
            cell.ColumnSpan = matrix.Columns;
            row0.Cells.Add(cell);

            TableRow row1 = new TableRow();
            row1.Cells.Add(ReturnCell(matrix.Rows.ToString()));
            FillTableRow(row1, matrix.Columns - 1);

            table.Rows.Add(row0);
            table.Rows.Add(row1);
            for (int i = 0; i < matrix.Rows; i++)
            {
                TableRow rowTemp = new TableRow();
                for (int j = 0; j < matrix.Columns; j++)
                {
                    rowTemp.Cells.Add(ReturnCell((matrix.Get(i, j)).ToString()));
                }
                table.Rows.Add(rowTemp);
            }
        }

        /// <summary>
        /// Writes lines from vertice's list
        /// </summary>
        /// <param name="allLines">array of all the lines to write</param>
        /// <param name="index">index of line to start writing to</param>
        /// <param name="vertices">list of all the vertices</param>
        public static void WriteLines(string[] allLines, int index, List<Vertice> vertices)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                allLines[index] = String.Format("Viršūnė: {0, -10} | Numeris: {1}", vertices[i].Name, vertices[i].Row + 1);
                index++;
            }
        }

        /// <summary>
        /// Creates a string array to hold all the lines
        /// </summary>
        /// <param name="matrix">data matrix</param>
        /// <param name="vertices">all the vertices list</param>
        /// <returns>returns a made string array</returns>
        public static string[] WriteData(Matrix matrix, List<Vertice> vertices)
        {
            string[] AllLines = new string[matrix.Rows + vertices.Count + 2];
            AllLines[0] = "Pradiniai duomenys";
            AllLines[1] = String.Format("n = {0}", matrix.Rows);
            for (int i = 2; i <= matrix.Rows + 1; i++)
            {
                string line = "";
                for (int j = 0; j < matrix.Columns; j++)
                {
                    line += matrix.Get(i - 2, j);
                }
                AllLines[i] = line;
            }
            return AllLines; 
        }

    }
}