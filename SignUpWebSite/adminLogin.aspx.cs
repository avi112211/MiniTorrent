﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_adminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(UserName.Text.Trim().Equals("admin") && Password.Text.Trim().Equals("admin"))
        {
            Response.Redirect("admin/adminCP.aspx", true);
        }
    }
}