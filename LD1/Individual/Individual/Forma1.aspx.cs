using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Individual
{
    public partial class Forma1 : System.Web.UI.Page
    {
        private string key = "KEY#00FFAJ";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count == 0)
            {
                DropDownList1.Items.Add("-");
                for (int i = 7; i <= 19; i++)
                {
                    DropDownList1.Items.Add(i.ToString());
                }
            }

            if ((List<Participant>)Session[key] != null && ((List<Participant>)Session[key]).Count > 0)
            {
                Table1.Rows.Clear();
                Table1.Rows.Add(TaskUtils.HeaderRow());
                foreach (Participant participant in (List<Participant>)Session[key])
                {
                    Table1.Rows.Add(TaskUtils.ReturnRow(participant, (List<Participant>)Session[key]));
                }
                List<Participant> participants = (List<Participant>)Session[key];
                Label1.Text = "<b>Bendras dalyvių kiekis: </b>" + (participants.Count).ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<string> Languages = new List<string>();
                string name = TextBox1.Text;
                string surname = TextBox2.Text;
                string schoolName = TextBox3.Text;
                int age = Int32.Parse(DropDownList1.Text);
                Languages = TaskUtils.ReturnLanguagesList(CheckBoxList1);
                Participant participant = new Participant(name, surname, schoolName, age, Languages);

                if ((List<Participant>)Session[key] == null)
                {
                    Table1.Rows.Add(TaskUtils.HeaderRow());
                    List<Participant> participants = new List<Participant>();
                    participants.Add(participant);
                    Session[key] = participants;
                }

                else
                {
                    List<Participant> participants = (List<Participant>)Session[key];
                    participants.Add(participant);
                    Session[key] = participants;
                }

                Table1.Rows.Add(TaskUtils.ReturnRow(participant, (List<Participant>)Session[key]));
                List<Participant> participantsAll = (List<Participant>)Session[key];
                Label1.Text = "Bendras dalyvių kiekis " + (participantsAll.Count).ToString();
                TextBox1.Text = null;
                TextBox2.Text = null;
                TextBox3.Text = null;
                DropDownList1.Text = null;
                TaskUtils.UnselectLanguages(CheckBoxList1);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Table1.Rows.Clear();
            Label1.Text = "<b>Bendras dalyvių kiekis: </b>" + 0.ToString();
            Session[key] = null;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CustomValidator1_ServerValidate1(object source, ServerValidateEventArgs args)
        {
                if (!TaskUtils.CheckIfLetter(TextBox1.Text))
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
                if (!TaskUtils.CheckIfLetter(TextBox2.Text))
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
            if (!TaskUtils.CheckIfLetter(TextBox3.Text))
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