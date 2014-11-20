using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
        protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String sql="INSERT INTO [CarSellDb].[dbo].[AdminMaster] ([FirstName],[LastName],[Email] ,[Password]) VALUES (";
            sql +="'" + txtFirstName.Text + "','" + txtLastName.Text + "','" +txtEmail.Text+"','" +txtPassword.Text+"')";

        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();
        Response.Write("Successfully Inserted " + Convert.ToString(returnCode));
    }
}