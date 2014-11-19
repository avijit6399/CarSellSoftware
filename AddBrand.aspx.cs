using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Data;

public partial class AddCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionManagement.isAdminSession() != true)
        {
            Session.Abandon();
            Response.Redirect("AdminLogin.aspx");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean isDuplicate = false;
        String sql = "select BrandName from BrandMaster where BrandName='" + txtBrand.Text.Replace("'","''") + "'";
        DbClass dc = new DbClass();
        DataSet ds = dc.returnDataSet(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            isDuplicate = true;
        }

        if (isDuplicate == false)
        {
            sql = "INSERT INTO [CarSellDb].[dbo].[BrandMaster] ([BrandName]) VALUES(";
            sql += "'" + txtBrand.Text + "')";
            Response.Write(sql);

            string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand command = new SqlCommand(sql, con);
            int returnCode = command.ExecuteNonQuery();
            //Response.Write("Successfully Inserted " + Convert.ToString(returnCode));
            msg.Text = "Brand sucessfully added";
            txtBrand.Text = "";
        }
        else
        {
            msg.Text = "Brand " + txtBrand.Text + " already exists. Please try another one.";
        }
    }
}