using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Admin_test : System.Web.UI.Page
{
    private static DBactions dba;
    protected void Page_Load(object sender, EventArgs e)
    {
        dba = new DBactions();
        int [] count = dba.countUsers();
        numOfUsers.Text = count[0].ToString();
        onlineUsers.Text = count[1].ToString();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = userText.Text.Trim();
        string password = passText.Text.Trim();

        if (!username.Equals("") && !password.Equals(""))
        {
            dba.addNewUser(username, password);
            Response.Redirect("adminCp.aspx", false);
        }
    }
}