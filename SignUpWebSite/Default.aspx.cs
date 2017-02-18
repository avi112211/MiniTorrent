using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private List<String> userNames = new List<string> { };
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSetTableAdapters.TableTableAdapter ct = new DataSetTableAdapters.TableTableAdapter();
        DataSet ds = new DataSet();
        ct.Fill(ds.Table);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            userNames.Add(ds.Tables[0].Rows[i].Field<String>("UserName").Trim());
    }

    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (Password.Text.Length < 4)
            Label4.Visible = true;
        else
            Label4.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (userNames.Contains(UserName.Text.Trim()))
            Label5.Visible = true;
        else
        {
            Users u = new Users();
            u.Id = userNames.Count + 1;
            u.UserName = UserName.Text.Trim();
            u.PassWord = Password.Text.Trim();

            MyDBDataContext dc = new MyDBDataContext();
            dc.Users.InsertOnSubmit(u);
            dc.SubmitChanges();
            Label5.Visible = false;
            Response.Redirect("userCreated.aspx", false);

            //db add
        }
    }
}