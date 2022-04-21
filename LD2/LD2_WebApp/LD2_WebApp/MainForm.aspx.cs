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
                Table1.Rows.AddRange(((TableRow[])Session["TABLE1"]));
                Table2.Rows.AddRange(((TableRow[])Session["TABLE2"]));
                Table3.Rows.AddRange(((TableRow[])Session["TABLE3"]));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                const string CFdA = "App_Data/U8a.txt";
                const string CFdB = "App_Data/U8b.txt";
                const string CFr = "App_Data/Rezultatai.txt";

                if (!File.Exists(Server.MapPath(CFdA)) || !File.Exists(Server.MapPath(CFdB)))
                {
                    Session["Files"] = false;
                    Page.Validate();
                    return;
                }
                string[] AllLinesA = File.ReadAllLines(Server.MapPath(CFdA));
                string[] AllLinesB = File.ReadAllLines(Server.MapPath(CFdB));

                RouteLList AllRoutes = InOutUtils.ReadFileA(AllLinesA);
                CityLList AllCities = InOutUtils.ReadFileB(AllLinesB);

                string startingCity = TextBox1.Text;
                long maxCitizens = long.Parse(TextBox2.Text);
                int minDistance = int.Parse(TextBox3.Text);

                RouteLList FilteredRoutes = TaskUtils.FindRoutes(startingCity, maxCitizens, minDistance, AllRoutes, AllCities);
                FilteredRoutes.Sort();

                Table1.Rows.Clear();
                Table2.Rows.Clear();
                Table3.Rows.Clear();

                Table1.Rows.Add(TaskUtils.ReturnRowWithText("Pradiniai duomenys (maršrutai)", 3));
                InOutUtils.FillRoutesTableOnScreen(Table1, AllRoutes);

                Table2.Rows.Add(TaskUtils.ReturnRowWithText("Pradiniai duomenys (miestai)", 2));
                InOutUtils.FillCitiesTableOnScreen(Table2, AllCities);

                Table3.Rows.Add(TaskUtils.ReturnRowWithText("Rezultatai", 3));
                InOutUtils.FillRoutesTableOnScreen(Table3, FilteredRoutes);

                Table1.Visible = true;
                Table2.Visible = true;
                Table3.Visible = true;

                string[] AllLines = InOutUtils.PrintData(AllRoutes, AllCities, FilteredRoutes);

                if (File.Exists(Server.MapPath(CFr)))
                {
                    File.Delete(Server.MapPath(CFr));
                }

                File.AppendAllLines(Server.MapPath(CFr), AllLines);

                Button2.Visible = true;
                TextBox4.Visible = true;
                Label.Visible = true;

                TableRow[] rows1 = new TableRow[Table1.Rows.Count];
                Table1.Rows.CopyTo(rows1, 0);
                Session.Remove("TABLE1");
                Session.Add("TABLE1", rows1);

                TableRow[] rows2 = new TableRow[Table2.Rows.Count];
                Table2.Rows.CopyTo(rows2, 0);
                Session.Remove("TABLE2");
                Session.Add("TABLE2", rows2);

                TableRow[] rows3 = new TableRow[Table3.Rows.Count];
                Table3.Rows.CopyTo(rows3, 0);
                Session.Remove("TABLE3");
                Session.Add("TABLE3", rows3);

                Session["RouteList"] = FilteredRoutes;
                Session["CFrAddress"] = CFr;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string CFr = (string)Session["CFrAddress"];
                string removeCity = TextBox4.Text;
                RouteLList filtered = (RouteLList)Session["RouteList"];
                filtered.Remove(removeCity);
                Table4.Rows.Add(TaskUtils.ReturnRowWithText("Rezultatai (po panaikinimo)", 3));
                InOutUtils.FillRoutesTableOnScreen(Table4, filtered);
                Table4.Visible = true;

                string[] AllLines = new string[filtered.Count + 3];
                int index = 0;
                AllLines[index++] = "Rezultatai (po panaikinimo)";
                filtered.AppendRoutes(AllLines, ref index);
                File.AppendAllLines(Server.MapPath(CFr), AllLines);
            }
        }


        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!ErrorCheck.CheckIfLong(TextBox2.Text))
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
            if (!ErrorCheck.CheckIfInt(TextBox3.Text))
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
            if (!ErrorCheck.CheckIfAllLetters(TextBox1.Text))
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
            }

            else
            {
                args.IsValid = true;
            }
        }
    }
}