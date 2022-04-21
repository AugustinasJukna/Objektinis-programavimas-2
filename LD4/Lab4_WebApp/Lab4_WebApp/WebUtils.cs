using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab4_WebApp
{
    public class WebUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Outputs data into a table
        /// </summary>
        /// <param name="table">Table to output data</param>
        /// <param name="columnSpan">span of the header row's cell's column</param>
        /// <param name="output">data to output</param>
        /// <param name="outputLine">header line</param>
        public static void OutputToTableRow(Table table, int columnSpan, int output, string outputLine)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = outputLine, ColumnSpan = columnSpan });
            row.Cells.Add(new TableCell() { Text = output.ToString() });
            table.Rows.Add(row);
        }

        /// <summary>
        /// Makes list into a table
        /// </summary>
        /// <param name="controls">Controls collection to put table in</param>
        /// <param name="locations">list of locations to output to a table</param>
        /// <param name="headerRow">header row</param>
        public static void ListToTable(ControlCollection controls, LinkList<Location> locations, TableRow headerRow)
        {
            Table table = new Table()
            {
                GridLines = GridLines.Both,
                CssClass = "table table-hover table-dark"
            };


            table.Rows.Add(headerRow);
            try
            {
                if (locations.Count() == 0) throw new ParseException();
                foreach (Location location in locations)
                {
                    table.Rows.Add(location.ToRow());
                }
            }
            catch (ParseException)
            {
                TableRow error = new TableRow();
                table.Rows.Add(error);
                table.Rows[table.Rows.GetRowIndex(error)].Cells.Add(new TableCell() { Text = "Tuščias sąrašas.", ColumnSpan = 7 });
            }
            finally
            {
                controls.Add(table);
            }
        }

        /// <summary>
        /// Executes files into Location lists and later - into tables
        /// </summary>
        /// <param name="controls">place to add table to</param>
        /// <param name="files">list of all the files</param>
        public static void FilesToTable(ControlCollection controls, LinkList<FileData> files)
        {
            foreach (FileData file in files)
            {
                TableRow fileNameHeader = new TableRow();
                string[] fileNameParts = file.FileName.Split('\\');
                fileNameHeader.Cells.Add(new TableCell() { Text = fileNameParts[fileNameParts.Length - 1], ColumnSpan = 7});

                ListToTable(controls, file.GetLocationsList(), fileNameHeader);
            }
        }
  
    }
}