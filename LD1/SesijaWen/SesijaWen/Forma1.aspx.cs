using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SesijaWen
{
    public partial class Forma1 : System.Web.UI.Page
    {
        private string issaugotasTekstas;

        protected void Page_Load(object sender, EventArgs e)
        {
            issaugotasTekstas = (string)Session["tekstas"];
            IterptiIrasa(issaugotasTekstas);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            issaugotasTekstas = TextBox1.Text;
            IterptiIrasa(issaugotasTekstas);
            Session["tekstas"] = issaugotasTekstas;
        }

        private void IterptiIrasa(string tekstas)
        {
            TableCell cell = new TableCell();
            cell.Text = tekstas;

            TableRow row = new TableRow();
            row.Cells.Add(cell);

            Table1.Rows.Add(row);
        }
    }
}