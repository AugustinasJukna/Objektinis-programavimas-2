using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Individual
{
    public class TaskUtils
    {
        /// <summary>
        /// Returns selected languages list
        /// </summary>
        /// <param name="checkBoxList1">checkbox from the form</param>
        /// <returns>a list of languages</returns>
        public static List<string> ReturnLanguagesList(CheckBoxList checkBoxList1)
        {
            List<string> Languages = new List<string>();
            for (int i = 0; i < checkBoxList1.Items.Count; i++)
            {
                if (checkBoxList1.Items[i].Selected)
                {
                    Languages.Add(checkBoxList1.Items[i].ToString());
                }
            }
            return Languages;
        }

        /// <summary>
        /// Unselects languages from the checkbox list
        /// </summary>
        /// <param name="checkBoxList1">checkbox list from the form</param>
        public static void UnselectLanguages(CheckBoxList checkBoxList1)
        {
            for (int i = 0; i < checkBoxList1.Items.Count; i++)
            {
                if (checkBoxList1.Items[i].Selected)
                {
                    checkBoxList1.Items[i].Selected = false;
                }
            }
        }
        /// <summary>
        /// Returns a formed cell
        /// </summary>
        /// <param name="text">text to be put in a cell</param>
        /// <returns>a made cell</returns>
        private static TableCell ReturnCell(string text)
        {
            TableCell cell = new TableCell();
            cell.Text = text;
            return cell;
        }

        /// <summary>
        /// Finds index's list
        /// </summary>
        /// <param name="participant">participant</param>
        /// <param name="participants">participants list</param>
        /// <returns>an index</returns>
        public static int FindIndexInList(Participant participant, List<Participant> participants)
        {
            for (int i = 0; i < participants.Count; i++)
            {
                if (participants[i] == participant)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Returns a formed row
        /// </summary>
        /// <param name="participant">participant</param>
        /// <param name="participants">a list of participants</param>
        /// <returns>a made row</returns>
        public static TableRow ReturnRow(Participant participant, List<Participant> participants)
        {
            TableRow row = new TableRow();
            row.Cells.Add(ReturnCell((FindIndexInList(participant, participants) + 1).ToString()));
            row.Cells.Add(ReturnCell(participant.Name));
            row.Cells.Add(ReturnCell(participant.Surname));
            row.Cells.Add(ReturnCell(participant.SchoolName));
            row.Cells.Add(ReturnCell((participant.Age).ToString()));
            row.Cells.Add(ReturnCell(participant.ReturnLanguages()));
            return row;
        }

        /// <summary>
        /// Creates a header row
        /// </summary>
        /// <returns>returns the header row</returns>
        public static TableRow HeaderRow()
        {
            TableRow row = new TableRow();
            TableCell number = new TableCell();
            number.Text = "Numeris";
            row.Cells.Add(number);
            TableCell name = new TableCell();
            name.Text = "Vardas";
            row.Cells.Add(name);
            TableCell surname = new TableCell();
            surname.Text = "Pavardė";
            row.Cells.Add(surname);
            TableCell schoolName = new TableCell();
            schoolName.Text = "Mokyklos pavadinimas";
            row.Cells.Add(schoolName);
            TableCell age = new TableCell();
            age.Text = "Amžius";
            row.Cells.Add(age);
            TableCell languages = new TableCell();
            languages.Text = "Programavimo kalbos";
            row.Cells.Add(languages);
            return row;
        }

        /// <summary>
        /// Checks if a char is a letter or not
        /// </summary>
        /// <param name="text">string from which chars wil be taken from</param>
        /// <returns>returns the true or false statement</returns>
        public static bool CheckIfLetter(string text)
        {
            string specialChars = "+-*/;'\\[]/!@#%$^&()-=|";
            for (int i = 0; i < text.Length; i++)
            {
                if (specialChars.IndexOf(text[i]) > 0 || Char.IsDigit(text[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}