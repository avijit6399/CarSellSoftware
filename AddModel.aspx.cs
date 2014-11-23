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

public partial class AddModel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionManagement.isAdminSession() != true)
        {
            Session.Abandon();
            Response.Redirect("AdminLogin.aspx");
        }
        if (!IsPostBack)
        {
            String sql = "select BrandId, BrandName from BrandMaster order by BrandName";
            CommonFunctions cf = new CommonFunctions();
            cf.fillDatabaseDropDown(ddlBrandName, sql, "");
        }

        int ModelId = 0;

        if (Request.QueryString["mid"] != null)
        {
            ModelId = Convert.ToInt16(Request.QueryString["mid"]);
        }

        PopulateGridView(ModelId);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Boolean isDuplicate = false;
        String sql = "select ModelName from ModelMaster where ModelName='" + txtModel.Text.Replace("'","''") + "'";
        DbClass dc = new DbClass();
        DataSet ds = dc.returnDataSet(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            isDuplicate = true;
        }

        if (isDuplicate == false)
        {
            sql = "INSERT INTO [CarSellDb].[dbo].[ModelMaster] ([BrandID],[ModelName]) VALUES(";
            sql += "'" + ddlBrandName.SelectedValue + "','" + txtModel.Text.Replace("'", "''") + "')";

            string conStr = DbClass.getConnectionStr();
            SqlConnection con = new SqlConnection(conStr);
            con.Open();

            SqlCommand command = new SqlCommand(sql, con);
            int returnCode = command.ExecuteNonQuery();
            //Response.Write("Successfully Inserted " + Convert.ToString(returnCode));
            msg.Text = "Model sucessfully added";
            txtModel.Text = "";
          
        }
        else
        {
            msg.Text = "Model " + txtModel.Text + " already exists. Please try another one.";
        }
        //Important Part
        gridView.DataBind();
        PopulateGridView(0);
        
    }

    public void PopulateGridView(int mid)
    {
        //Getting the connection string from web.config file
        sqlDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        if (mid == 0)
        {
            sqlDataSource.SelectCommand = "Select b.*, m.* from ModelMaster m, BrandMaster b where b.BrandId=m.BrandId";
        }
        else
        {
            sqlDataSource.SelectCommand = "Select b.*, m.* from ModelMaster m, BrandMaster b where b.BrandId=m.BrandId and m.ModelId=" + mid;
        }

        //Update statement. Here the Primary key of the table is testId and that has //been mentioned as
        //DataKeyNames="testId" in the GridView control on .aspx page.
        //sqlDataSource.UpdateCommand = "Update ModelMaster m set ModelName=@ModelName where ModelId=@ModelId AND (select count(*) from ModelMaster mm where mm.BrandId = m.BrandId and mm.ModelName=@ModelName)=0";
        sqlDataSource.UpdateCommand = "Update ModelMaster set ModelName=@ModelName where ModelId=@ModelId AND (select count(*) from ModelMaster where ModelName=@ModelName and BrandId=@BrandId)=0";
        //Delete statement.
        sqlDataSource.DeleteCommand = "Exec DeleteFromMaster @ModelIdVal=@ModelId;";

    }
}