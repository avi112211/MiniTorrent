﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void signUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("signUp.aspx", false);
    }

    protected void admin_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminLogin.aspx", false);
    }
}