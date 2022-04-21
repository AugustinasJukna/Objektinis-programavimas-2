using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab5_WebApp
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            if (Session["Controls"] != null && (Session["Controls"] as List<Table>).Count == 4)
            {
                Session.Remove("Controls");
            }
            if (Page.IsPostBack && Session["Controls"] != null && (Session["Controls"] as List<Table>).Count <= 4) //Recovers data after postback
            {
                var Tables = Session["Controls"] as List<Table>;
                foreach(Table table in Tables)
                {
                    mainContainer.Controls.Add(table);
                }
                Session.Remove("Controls");
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                const string CFr = "App_Data//Rezultatai.txt";
                Session["CFr"] = CFr;
                if (File.Exists(Server.MapPath(CFr))) File.Delete(Server.MapPath(CFr));

                string[] Files = Directory.GetFiles(Server.MapPath(@"//App_Data"));
                Files = Files.Where(f => f.EndsWith(".txt")).ToArray(); //Filters fileNames

                if (Files.Count() == 0) throw new CustomException("Trūksta duomenų failų!");

                ErrorCheck.CheckTextBoxes(TextBox1, TextBox2, TextBox3); //Input check
                string city = TextBox1.Text;
                bool date1 = DateTime.TryParse(TextBox2.Text, out DateTime startDate);
                bool date2 = DateTime.TryParse(TextBox3.Text, out DateTime endDate);

                if (!date1 || !date2) throw new CustomException("Bloga įvesta data! Teisingos datos pavyzdys: 2021-05-06"); //Checks date

                List<User> AllUsers = InOutUtils.ReadAllFilesOfType<User>(Files);
                List<Publication> AllPublications = InOutUtils.ReadAllFilesOfType<Publication>(Files); //Inputs starting data into lists

                List<Subscription> Subscriptions = TaskUtils.ConnectUsersWithPublications(AllUsers, AllPublications); //Connects users with publications
                TaskUtils.SetPrices(Subscriptions); //Sets prices for users

                List<User> Filtered = TaskUtils.FindUsersByCriteria(AllUsers, city, startDate, endDate); //Filters users

                InOutUtils.PrintStartingData<User>(Server.MapPath(CFr), AllUsers); //Data outputs
                InOutUtils.PrintStartingData<Publication>(Server.MapPath(CFr), AllPublications);
                WebUtils.StartingDataToTable<User>(mainContainer.Controls, "Pradiniai duomenys", AllUsers);
                WebUtils.StartingDataToTable<Publication>(mainContainer.Controls, "Pradiniai duomenys", AllPublications);
                InOutUtils.PrintResults(Server.MapPath(CFr), "Rezultatai", Filtered);

                TableRow headerRow = new TableRow();
                headerRow.Cells.Add(new TableCell()
                {
                    Text = "Rezultatai",
                    ColumnSpan = 8
                });
                WebUtils.PrintResultsIntoTable(mainContainer.Controls, headerRow, Filtered, Button3); //Results table


                Button2.Visible = true; //Sort button visibility is set to true
                Session["Results"] = Filtered;
                Session.Remove("Controls");
                Session["Controls"] = WebUtils.PreserveTables(mainContainer.Controls); //Table controls preservation
            }

            catch (CustomException ex) //Exceptions control
            {
                errorLabel.InnerText = ex.ErrorMessage;
                errorLabel.Visible = true;
                Panel1.Visible = true;
                Button3.Visible = true; //Makes delete button visible
            }

            catch (Exception ex)
            {
                errorLabel.InnerText = "Klaida! " + ex.Message;
                errorLabel.Visible = true;
                Panel1.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var Filtered = (Session["Results"] as List<User>);
                var CFr = Session["CFr"] as string;
                Filtered = TaskUtils.CustomSort(Filtered); //Sorts
                InOutUtils.PrintResults(Server.MapPath(CFr), "Rezultatai (surikiuotas sąrašas)", Filtered);
                TableRow headerRow = new TableRow();
                headerRow.Cells.Add(new TableCell()
                {
                    Text = "Rezultatai (surikiuotas sąrašas)",
                    ColumnSpan = 8
                });
                WebUtils.PrintResultsIntoTable(mainContainer.Controls, headerRow, Filtered, Button3); //Outputs a sorted list
            }

            catch (CustomException ex) //Exceptions control
            {
                errorLabel.InnerText = ex.ErrorMessage;
                errorLabel.Visible = true;
                Panel1.Visible = true;
            }

            catch (Exception ex)
            {
                errorLabel.InnerText = "Klaida! " + ex.Message;
                errorLabel.Visible = true;
                Panel1.Visible = true;
            }

            finally
            {
                Button3.Visible = true; //Makes delete button visible
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control control in mainContainer.Controls.OfType<Control>().ToList())
                {
                    if (control is Table)
                        mainContainer.Controls.Remove(control);
                }
                Session.Remove("Controls");
                Response.Redirect(Page.Request.RawUrl); //Deletes all tables and resets page
            }
            catch (Exception ex)
            {
                errorLabel.InnerText = "Klaida! " + ex.Message;
                errorLabel.Visible = true;
                Panel1.Visible = true;
            }
            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false; //Minimizes user interface for simplicity and aesthetics
        }
    }
}