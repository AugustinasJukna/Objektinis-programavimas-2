using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Lab5_WebApp
{
    public class Publication : IParsable, IResults
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal MonthlyPrice { get; set; }

        public Publication() { } //Constructor

        /// <summary>
        /// Interface method for parsing data from one line
        /// </summary>
        /// <param name="lineParts">line parts to parse data from</param>
        public void ParseLine(string[] lineParts)
        {
            Number = int.Parse(lineParts[0]);
            Name = lineParts[1];
            MonthlyPrice = decimal.Parse(lineParts[2]);
        }

        /// <summary>
        /// (Interface method) Not intended for this object, so it does nothing.
        /// </summary>
        public void AddDate(DateTime date)
        {
            return;
        }

        /// <summary>
        /// Returns a header with names of the properties
        /// </summary>
        /// <returns>string header</returns>
        public string ReturnHeader()
        {
            return String.Format("|{0, -10}|{1, -15}|{2, -15}|", "Kodas", "Pavadinimas", "Mėnesio kaina");
        }

        /// <summary>
        /// ToString() method override
        /// </summary>
        /// <returns>string line</returns>
        public override string ToString()
        {
            return String.Format("|{0, 10}|{1, -15}|{2, 15}|", Number, Name, MonthlyPrice);
        }

        /// <summary>
        /// Interface method for outputting properties to a table row
        /// </summary>
        /// <returns>a table row with properties</returns>
        public TableRow ToTableRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = Number.ToString() });
            row.Cells.Add(new TableCell() { Text = Name });
            row.Cells.Add(new TableCell() { Text = MonthlyPrice.ToString() });
            return row;
        }

        /// <summary>
        /// Returns objects table row with names of it's properties
        /// </summary>
        /// <returns>a table row</returns>
        public TableRow ReturnRowHeader()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = "Kodas" });
            row.Cells.Add(new TableCell() { Text = "Pavadinimas" });
            row.Cells.Add(new TableCell() { Text = "Mėnesio kaina" });
            return row;
        }
    }
}
