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
        if (!IsPostBack)
        {
            new CommonFunctions().fillEngineDropDown(ddlEngineType);
        }
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

        String sql = "INSERT INTO [CarSellDb].[dbo].[CarMaster] ([CarBrand],[CarModel],[Carcolor],[CarPrice]";
            sql += ",[CarEngineType],[CarMileage],[ImageName]) VALUES (";
            sql += "'" + txtCarBrand.Text + "','" + txtCarModel.Text + "','" + txtCarColor.Text + "','" + txtCarPrice.Text + "'";
            sql += ",'" + ddlEngineType.Text + "','" + txtMileage.Text + "','" + fileName + "');select @@identity";
            Response.Write(sql);

        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();


        Response.Write("Successfully Inserted " + Convert.ToString(returnCode));
    }
   
}