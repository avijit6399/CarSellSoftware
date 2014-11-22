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
            //it's ok
        }

        int BrandId = 0;

        if (Request.QueryString["bid"] != null)
        {
            BrandId = Convert.ToInt16(Request.QueryString["bid"]);
        }

        PopulateGridView(BrandId);
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

            string conStr = DbClass.getConnectionStr();
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand command = new SqlCommand(sql, con);
            int returnCode = command.ExecuteNonQuery();
            //Response.Write("Successfully Inserted " + Convert.ToString(returnCode));
            msg.Text = "Brand " + txtBrand.Text + " sucessfully added";
            txtBrand.Text = "";
            
        }
        else
        {
            msg.Text = "Brand " + txtBrand.Text + " already exists. Please try another one.";
        }

        //Important Part
        gridView.DataBind();
        PopulateGridView(0);
        
    }

    public void PopulateGridView(int bid)
    {
        //Getting the connection string from web.config file
        sqlDataSource.ConnectionString = DbClass.getConnectionStr();
        if (bid == 0)
        {
            sqlDataSource.SelectCommand = "Select * from BrandMaster";
        }
        else
        {
            sqlDataSource.SelectCommand = "Select * from BrandMaster where BrandId=" + bid;
        }

        //Update statement. Here the Primary key of the table is testId and that has //been mentioned as
        //DataKeyNames="testId" in the GridView control on .aspx page.
        sqlDataSource.UpdateCommand = "Update BrandMaster set BrandName=@BrandName where BrandId=@BrandId";

        //Delete statement.
        sqlDataSource.DeleteCommand = "Delete BrandMaster where BrandId=@BrandId";
                        
    }
}