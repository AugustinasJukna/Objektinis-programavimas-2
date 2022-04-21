using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LD2_WebApp
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack && Session["TABLE1"] != null && Session["TABLE2"] != null && Session["TABLE3"] != null && Table1.Rows.Count == 0 && Table2.Rows.Count == 0 && Table3.Rows.Count == 0)
            {
                Table1.Rows.AddRange(((TableRow[])Session["TABLE1"])); //Checks if there is any data to restore on page after postback
                Table2.Rows.AddRange(((TableRow[])Session["TABLE2"]));
                Table3.Rows.AddRange(((TableRow[])Session["TABLE3"]));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) //initiates validation
            {
                const string CFr = "App_Data/Rezultatai.txt";
                Session["CFr"] = CFr;

                if (!FileUpload1.HasFile || (FileUpload1.PostedFiles.Count == 2 && (!FileUpload1.PostedFiles[0].FileName.EndsWith(".txt") || !FileUpload1.PostedFiles[1].FileName.EndsWith(".txt"))) || FileUpload1.PostedFiles.Count > 2 || FileUpload1.PostedFiles.Count < 2)
                { //Checks if the file upload has 2 files
                    Session["Files"] = false;
                    Page.Validate();
                    return;
                }

                StreamReader AllLinesA = new StreamReader(FileUpload1.PostedFiles[0].InputStream); //reads starting data
                StreamReader AllLinesB = new StreamReader(FileUpload1.PostedFiles[1].InputStream);

                LinkList<Route> AllRoutes = InOutUtils.ReadFileA(AllLinesA); //puts starting data into lists
                LinkList<City> AllCities = InOutUtils.ReadFileB(AllLinesB);

                string startingCity = TextBox1.Text;
                long maxCitizens = long.Parse(TextBox2.Text);
                int minDistance = int.Parse(TextBox3.Text);

                LinkList<Route> FilteredRoutes = TaskUtils.FindRoutes(startingCity, maxCitizens, minDistance, AllRoutes, AllCities); //filters routes
                FilteredRoutes.Sort();

                Table1.Rows.Clear(); //clears tables rows to prevent data duplication
                Table2.Rows.Clear();
                Table3.Rows.Clear();

                Table1.Rows.Add(TaskUtils.ReturnRowWithText("Pradiniai duomenys (maršrutai)", 3));
                InOutUtils.FillRoutesTableOnScreen(Table1, AllRoutes); //fills first table

                Table2.Rows.Add(TaskUtils.ReturnRowWithText("Pradiniai duomenys (miestai)", 2));
                InOutUtils.FillCitiesTableOnScreen(Table2, AllCities); //fills second table

                Table3.Rows.Add(TaskUtils.ReturnRowWithText("Rezultatai", 3));
                InOutUtils.FillRoutesTableOnScreen(Table3, FilteredRoutes); //fills third table

                Table1.Visible = true; //makes hidden tables visible
                Table2.Visible = true;
                Table3.Visible = true;

                string[] AllLines = InOutUtils.PrintData(AllRoutes, AllCities, FilteredRoutes);

                if (File.Exists(Server.MapPath(CFr))) //checks if the result file exists to prevent data duplication
                {
                    File.Delete(Server.MapPath(CFr));
                }

                File.AppendAllLines(Server.MapPath(CFr), AllLines); //appends results

                Button2.Visible = true; //makes hidden controls visible
                Button3.Visible = true;
                TextBox4.Visible = true;
                Label.Visible = true;

                TableRow[] rows1 = new TableRow[Table1.Rows.Count]; //prepares for data preservation
                Table1.Rows.CopyTo(rows1, 0);
                Session.Remove("TABLE1"); //prevents data duplication
                Session.Add("TABLE1", rows1); //preserves data

                TableRow[] rows2 = new TableRow[Table2.Rows.Count];
                Table2.Rows.CopyTo(rows2, 0);
                Session.Remove("TABLE2");
                Session.Add("TABLE2", rows2);

                TableRow[] rows3 = new TableRow[Table3.Rows.Count];
                Table3.Rows.CopyTo(rows3, 0);
                Session.Remove("TABLE3");
                Session.Add("TABLE3", rows3);

                Session["RouteList"] = FilteredRoutes; //preserves filtered routes list
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string CFr = (string)Session["CFr"];
                string removeCity = TextBox4.Text; //finds out what city to remove
                LinkList<Route> filtered = (LinkList<Route>)Session["RouteList"]; //gets filtered route from Session
                filtered.RemoveRoutes(removeCity); //removes chosen city from result's list
                Table4.Rows.Add(TaskUtils.ReturnRowWithText("Rezultatai (po panaikinimo)", 3));
                InOutUtils.FillRoutesTableOnScreen(Table4, filtered);
                Table4.Visible = true; //reveals another hidden table

                string[] AllLines = new string[filtered.Count() + 3];
                int index = 0;
                AllLines[index++] = "Rezultatai (po panaikinimo)";
                filtered.Append(AllLines, ref index);
                File.AppendAllLines(Server.MapPath(CFr), AllLines); //fills results file

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string CFr = (string)Session["CFr"];
                //downloads results file
                FileStream results = File.OpenRead(Server.MapPath("App_Data/" + CFr.Remove(0, 9))); //reads file
                byte[] temp = new byte[results.Length];
                results.Read(temp, 0, Convert.ToInt32(results.Length)); //converts
                results.Close();
                Response.AddHeader("Content-disposition", "attachment; filename=" + CFr.Remove(0, 9)); //sets file's properties
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(temp);
                Response.End(); //sends file to download
            }
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ErrorCheck.CheckIfLong(TextBox2.Text)) //checks if the inputed string is long
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ErrorCheck.CheckIfInt(TextBox3.Text)) //checks if the inputed string is int
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ErrorCheck.CheckIfAllLetters(TextBox1.Text)) //checks if the inputed string is a word or a combination of words
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ErrorCheck.CheckIfAllLetters(TextBox4.Text))
            {
                args.IsValid = false;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Session["Files"] != null && !(bool)Session["Files"])
            {
                args.IsValid = false;
                Session["Files"] = true;
            }

            else
            {
                args.IsValid = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(Page.Request.RawUrl);
        }
    }
}