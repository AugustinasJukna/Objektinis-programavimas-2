using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab5_WebApp
{
    public static class ErrorCheck
    {
        /// <summary>
        /// method for checking textboxes
        /// </summary>
        /// <param name="a">first textbox to check</param>
        /// <param name="b">second textbox</param>
        /// <param name="c">third textbox</param>
        public static void CheckTextBoxes(TextBox a, TextBox b, TextBox c)
        {
            if (a.Text == "" || b.Text == "" || c.Text == "")
            {
                throw new CustomException("Nevisi įvesti duomenys.");
            }
        }
    }
}