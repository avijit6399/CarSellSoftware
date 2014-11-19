using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        String sql = "select * from CustomerMaster where Email='" + txtEmail.Text.Replace("'", "''") + "'";
        DbClass dc = new DbClass();
        DataSet ds = dc.returnDataSet(sql);
        if (ds.Tables[0].Rows.Count == 1)
        {
            String passwordFromDB = ds.Tables[0].Rows[0]["Password"].ToString();
            String passwordFromTextBox = txtPassword.Text;
            if (passwordFromDB.Equals(passwordFromTextBox))
            {
                Session["custId"] = ds.Tables[0].Rows[0]["CustId"].ToString();
                Session["FirstName"] = ds.Tables[0].Rows[0]["FirstName"].ToString();
                Response.Redirect("CarSearch.aspx");
            }
            else
            {
                lblMsg.Text = "Email or Password is not correct. Please try again.";
            }
        }
        else
        {
            lblMsg.Text = "Email or Password is not correct. Please try again.";
        }

    }
}
