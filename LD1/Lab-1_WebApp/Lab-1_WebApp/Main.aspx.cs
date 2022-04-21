using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab_1_WebApp
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] AllLines = File.ReadAllLines(Server.MapPath(InOutUtils.FormFileName(DropDownList1)));//inputs data
            Matrix scorpionMatrix = InOutUtils.ReadFile(AllLines);
            if (scorpionMatrix == null) //checks if the data is correct
            {
                Label1.Text = "<strong>Neteisingi duomenys!</strong>";
                File.WriteAllText(Server.MapPath("App_Data/Rezultatai.txt"), "Neteisingi duomenys.");
                return;
            }

            InOutUtils.StartingDataTable(Table2, scorpionMatrix);
            List<Vertice> AllVertices = new List<Vertice>();

            TaskUtils.FindVertices(scorpionMatrix, 0, AllVertices); //first lists all the vertices
            TaskUtils.NameVertices(scorpionMatrix, AllVertices); //names them
            TaskUtils.CustomListSort(AllVertices); //sorts them

            bool isScorpion = TaskUtils.IsScorpion(AllVertices); //checks if given data is a scorpion
            if (!isScorpion)
            {
                InOutUtils.IfError(Label1);
                string[] WrittenLines = InOutUtils.WriteData(scorpionMatrix, AllVertices);
                File.WriteAllLines(Server.MapPath("App_Data/Rezultatai.txt"), WrittenLines);
                File.AppendAllText(Server.MapPath("App_Data/Rezultatai.txt"), "Tai nėra skorpionas.");
                return;
            }

            else
            {
                string[] WrittenLines = InOutUtils.WriteData(scorpionMatrix, AllVertices);
                InOutUtils.WriteLines(WrittenLines, scorpionMatrix.Rows + 2, AllVertices);
                File.WriteAllLines(Server.MapPath("App_Data/Rezultatai.txt"), WrittenLines);
                InOutUtils.WriteIfScorpion(Label1);
                InOutUtils.FormTable(Table1, AllVertices);
            }
        }

    }
}