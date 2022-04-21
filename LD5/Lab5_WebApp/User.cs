using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Lab5_WebApp
{
    public class User : IParsable, IResults
    {
        public DateTime Date { get; set; }
        public string Surname {get; set;}
        public string Address { get; set; }
        public int Start { get; set; }
        public int Duration { get; set; }
        public int Number { get; set; }
        public int AmountOfPublications { get; set; }

        public decimal? FullPrice { get; set; }

        public User() { } //Empty constructor

        /// <summary>
        /// Checks if this object fits a particular criteria
        /// </summary>
        /// <param name="month">number of month</param>
        /// <param name="startDate">start date to compare with</param>
        /// <param name="endDate">end date to compare with</param>
        /// <returns>true or false depending on the outcome</returns>
        public bool CheckIfFits(int month, DateTime startDate, DateTime endDate)
        {
            int endMonth = this.Start + this.Duration;
            if ((month >= this.Start && endMonth >= month) && (this.Date >= startDate && this.Date <= endDate))
            {
                return true;
            }

            else return false;
        }

        /// <summary>
        /// Forms months string line ('.' - for motnhs that are not taken, '*' - for taken months)
        /// </summary>
        /// <returns>string line</returns>
        public string FormMonthsGraph()
        {
            char[] array = new char[12];
            int count = this.Start - 1;
            array = array.Select(c => '.').ToArray();
            for (int i = 0; i < this.Duration; i++)
            {
                array[count] = '*';
                if (count == 11 && i < this.Duration - 1)
                {
                    count = 0;
                }
                else
                {
                    count++;
                }
            }
            return new string(array);
        }

        /// <summary>
        /// Parses string line's parts into object's properties
        /// </summary>
        /// <param name="lineParts">parts to parse from</param>
        public void ParseLine(string[] lineParts)
        {
            Surname = lineParts[0];
            Address = lineParts[1];
            Start = int.Parse(lineParts[2]);
            Duration = int.Parse(lineParts[3]);
            Number = int.Parse(lineParts[4]);
            AmountOfPublications = int.Parse(lineParts[5]);
        }
        /// <summary>
        /// IParsable interface method for adding date
        /// </summary>
        /// <param name="date">date to add</param>
        public void AddDate(DateTime date)
        {
            Date = date;
        }

        /// <summary>
        /// Special method for printing results
        /// </summary>
        /// <returns>string line</returns>
        public string ToResults() => String.Format("|{0, -20}|{1, -20}|{2, -20}|{3, 15}|{4, 15}|{5, 15}|{6, 20}|{7, 15}", Surname, Address, Start, Duration, Number, AmountOfPublications, FormMonthsGraph(), FullPrice != null ? FullPrice : 0);

        /// <summary>
        /// ToString() method override
        /// </summary>
        /// <returns>string line</returns>
        public override string ToString() => String.Format("|{0, -20}|{1, -20}|{2, 15}|{3, 15}|{4, 15}|{5, 20}|", Surname, Address, Start, Duration, Number, AmountOfPublications);

        /// <summary>
        /// Specila method for printing starting data
        /// </summary>
        /// <returns>returns object's header with names of it's properties</returns>
        public string ReturnHeader() => String.Format("|{0, -20}|{1, -20}|{2, -15}|{3, -15}|{4, -15}|{5, -20}|", "Pavardė", "Adresas", "Pradžios mėnuo", "Laikotarpis", "Kodas", "Leidinių kiekis");

        /// <summary>
        /// Interface method for returning object's properties made into table row
        /// </summary>
        /// <returns>properties in a table row</returns>
        public TableRow ToTableRow()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = Surname });
            row.Cells.Add(new TableCell() { Text = Address });
            row.Cells.Add(new TableCell() { Text = Start.ToString()});
            row.Cells.Add(new TableCell() { Text = Duration.ToString()});
            row.Cells.Add(new TableCell() { Text = Number.ToString() });
            row.Cells.Add(new TableCell() { Text = AmountOfPublications.ToString() });
            return row;
        }

        /// <summary>
        /// Returns object's properties names in TableRow form
        /// </summary>
        /// <returns>properties in table row</returns>
        public TableRow ReturnRowHeader()
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = "Pavardė" });
            row.Cells.Add(new TableCell() { Text = "Adresas" });
            row.Cells.Add(new TableCell() { Text = "Pradžios mėnuo" });
            row.Cells.Add(new TableCell() { Text = "Laikotarpis" });
            row.Cells.Add(new TableCell() { Text = "Kodas" });
            row.Cells.Add(new TableCell() { Text = "Leidinių kiekis" });
            return row;
        }
    }
}
