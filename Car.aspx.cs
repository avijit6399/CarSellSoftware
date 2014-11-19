using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;


public partial class Car : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            new CommonFunctions().fillEngineDropDown(ddlEngineType);
        }
    }
    protected void onchange_ddlBrandName(object sender, EventArgs e)
    {
        ddlModelName.Items.Add(new ListItem("Select Model", "0"));
        String sql = "select brandId, ModelName from ModelMaster where BrandId=" + ddlBrandName.SelectedValue;
        CommonFunctions cf = new CommonFunctions();
        cf.fillDatabaseDropDown(ddlModelName, sql, "");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String fileName = "";

        if (fileUpload.HasFile)
        {
            try
            {
                fileName = Path.GetFileName(fileUpload.FileName);
                fileUpload.SaveAs(CommonFunctions.getServerPath() + "/CarImages/" + fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        String sql = "INSERT INTO [CarSellDb].[dbo].[CarMaster] ([ModelId],[Carcolor],[CarPrice]";
            sql += ",[CarEngineType],[CarMileage],[ImageName]) VALUES (";
            sql += "'" + ddlModelName.SelectedValue + "','" + txtCarColor.Text + "','" + txtCarPrice.Text + "'";
            sql += ",'" + ddlEngineType.Text + "','" + txtMileage.Text + "','" + fileName + "')";
            Response.Write(sql);

        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();
        Response.Write("Successfully Inserted " + Convert.ToString(returnCode));
    }
   
}