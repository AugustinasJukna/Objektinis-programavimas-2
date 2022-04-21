using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab4_WebApp
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            const string CFrAll = "App_Data\\VisosVietos.csv";
            const string CFrNew = "App_Data\\Nauji.csv";
            const string CFr = "App_Data\\Rezultatai.txt"; //file names

            try
            {
                if (File.Exists(Server.MapPath(CFrAll))) File.Delete(Server.MapPath(CFrAll)); //deletes files, to prevent duplication
                if (File.Exists(Server.MapPath(CFrNew))) File.Delete(Server.MapPath(CFrNew));
                if (File.Exists(Server.MapPath(CFr))) File.Delete(Server.MapPath(CFr));

                string[] Files = Directory.GetFiles(Server.MapPath("App_Data/")).Where(s => s.EndsWith(".txt")) //gets all the fileNames from App_Data folder
                      .ToArray();
                if (Files.Count() == 0) throw new ParseException("Nėra duomenų failų!");
                LinkList<FileData> allLists = InOutUtils.ReadFiles(Files);
               
                LinkList<Location> AllDataList = TaskUtils.MergeLists(allLists); //merges all files into one list

                InOutUtils.WriteToCSV(Server.MapPath(CFrAll), AllDataList);
                LinkList<Location> newLocations = TaskUtils.FilterNewLocations(allLists);
                newLocations.CustomSort();
                InOutUtils.WriteToCSV(Server.MapPath(CFrNew), newLocations);
                InOutUtils.PrintData(Server.MapPath(CFr), allLists, "Pradiniai duomenys");
                InOutUtils.PrintData(Server.MapPath(CFr), AllDataList, "Visų lankytinų vietų sąrašas.");
                InOutUtils.PrintData(Server.MapPath(CFr), newLocations, "Naujų vietų sąrašas.");

                int guidesCount = TaskUtils.FindGuidesCount(allLists);
                Location oldestLocation = TaskUtils.OldestLocation(allLists);

                WebUtils.OutputToTableRow(Table1, 1, guidesCount, "Muziejų turinčius gidus yra:");
                Table1.Rows.Add(new TableRow());
                Table1.Rows[1].Cells.Add(new TableCell() { Text = "Seniausia lankoma vieta:" });
                Table1.Rows.Add(oldestLocation.ToRow());
                Table1.Visible = true; //Outputs results

                string[] AppendLines = new string[2];
                AppendLines[0] = String.Format("Muziejų turinčius gidus yra: {0}", guidesCount);
                AppendLines[1] = String.Format("Seniausia lankoma vieta: {0}", (oldestLocation == null ? "Sąrašas tuščias." : oldestLocation.ToString()));
                InOutUtils.AppendText(Server.MapPath(CFr), AppendLines); //Adds additional data to the results file

                WebUtils.FilesToTable(MainContainer.Controls, allLists);
                TableRow headerRowAll = new TableRow();
                headerRowAll.Cells.Add(new TableCell() { Text = "Pilnas sąrašas.", ColumnSpan = 7 }); //Outputs results
                WebUtils.ListToTable(MainContainer.Controls, AllDataList, headerRowAll);

                TableRow headerRowNew = new TableRow();
                headerRowNew.Cells.Add(new TableCell() { Text = "Naujų lankytinų vietų sąrašas.", ColumnSpan = 7 });
                WebUtils.ListToTable(MainContainer.Controls, newLocations, headerRowNew); //Outputs results
            }

            catch (ParseException ex)
            {
                if (ex.CustomMessage != null)
                {
                    Label1.Text = ex.CustomMessage; //creates custom error
                }
                else
                {
                    Label1.Text = "Nuskaitymo klaida!"; //creates custom error
                }
                Table1.Visible = false;
            }

            catch (NullReferenceException)
            {
                Label1.Text = "Klaida! Skaičiuojama su nuliu!"; //creates custom error
            }

            catch (Exception)
            {
                Label1.Text = "Nenustatyta klaida!"; //creates custom error
            }
            
        }

    }
}