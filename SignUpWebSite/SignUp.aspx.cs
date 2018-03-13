using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class _Default : System.Web.UI.Page
{
    private static DBactions dba = new DBactions();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        emptyFields.Visible = false;
        if (!UserName.Text.Trim().Equals("") && !Password.Text.Trim().Equals("") && !RePassword.Text.Trim().Equals(""))
        {
            if (dba.checkUsernameExisit(UserName.Text.Trim()))
                Label5.Visible = true;
            else
            {
                dba.addNewUser(UserName.Text.Trim(), Password.Text.Trim());
                Label5.Visible = false;
                Response.Redirect("userCreated.aspx", false);
            }
        }
        else
            emptyFields.Visible = true;
    }
}