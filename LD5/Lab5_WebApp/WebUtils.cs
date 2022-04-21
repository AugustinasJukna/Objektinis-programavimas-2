using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5_WebApp
{
    public class WebUtils : System.Web.UI.Page
    {
        /// <summary>
        /// Makes a list into a table
        /// </summary>
        /// <param name="controls">Controls collection to put table in</param>
        /// <param name="locations">list of locations to output to a table</param>
        /// <param name="headerRow">header row</param>
        public static void StartingDataToTable<T>(ControlCollection controls, string text, List<T> items) where T : IResults, new()
        {
            int columnSpan;
            if (typeof(T) == typeof(User))
            {
                columnSpan = 7;
            }
            else
            {
                columnSpan = 6;
            }
            Table table = new Table()
            {
                GridLines = GridLines.Both,
                CssClass = "table table-hover table-dark"
            };

            TableRow textRow = new TableRow();
            textRow.Cells.Add(new TableCell() { Text = text, ColumnSpan = columnSpan});
            table.Rows.Add(textRow);

            table.Rows.Add(new T().ReturnRowHeader());
            try
            {
                if (items.Count() == 0) throw new CustomException("Sąrašas yra tuščias.");
                foreach (T item in items)
                {
                    table.Rows.Add(item.ToTableRow());
                }
            }
            catch (CustomException ex)
            {
                TableRow error = new TableRow();
                table.Rows.Add(error);
                table.Rows[table.Rows.GetRowIndex(error)].Cells.Add(new TableCell() { Text = ex.ErrorMessage, ColumnSpan = columnSpan });
            }
            finally
            {
                controls.Add(table);
            }
        }

        /// <summary>
        /// Prints results list into table
        /// </summary>
        /// <param name="controls">ControlCollection object to add a new table</param>
        /// <param name="headerRow">header row for a table</param>
        /// <param name="items">list to output into a table</param>
        public static void PrintResultsIntoTable(ControlCollection controls, TableRow headerRow, List<User> items, Button button)
        {
            Table table = new Table()
            {
                GridLines = GridLines.Both,
                CssClass = "table table-hover table-dark"
            };
            table.Rows.Add(headerRow);
            TableRow names = new User().ReturnRowHeader();
            names.Cells.Add(new TableCell() { Text = "Laikotarpis" });
            names.Cells.Add(new TableCell() { Text = "Pilna suma" });
            table.Rows.Add(names);
            try
            {
                if (items.Count() == 0) throw new CustomException("Sąrašas yra tuščias.");
                foreach (User item in items)
                {
                    TableRow temp = item.ToTableRow();
                    temp.Cells.Add(new TableCell() { Text = item.FormMonthsGraph() });
                    temp.Cells.Add(new TableCell() { Text = item.FullPrice != null ? item.FullPrice.ToString() : "0" });
                    table.Rows.Add(temp);
                }
            }
            catch (CustomException ex)
            {
                TableRow error = new TableRow();
                table.Rows.Add(error);
                table.Rows[table.Rows.GetRowIndex(error)].Cells.Add(new TableCell() { Text = ex.ErrorMessage, ColumnSpan = 8 });
                button.Visible = true; //Makes delete button visible
            }
            finally
            {
                controls.Add(table);
            }
        }

        /// <summary>
        /// Returns a List<Table> for preserving controls, so that when the page is in a postback, data can be recovered
        /// </summary>
        /// <param name="controls">collection of controls to preserve</param>
        /// <returns>Table class objects list</returns>
        public static List<Table> PreserveTables(ControlCollection controls)
        {
            List<Table> Tables = new List<Table>();
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] is Table)
                {
                    Tables.Add(controls[i] as Table);
                }
            }
            return Tables;
        }


    }
}