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
            new CommonFunctions().fillEngineDropDown(ddlEngineType);
            String sql = "select BrandId, BrandName from BrandMaster order by BrandName";
            CommonFunctions cf = new CommonFunctions();
            cf.fillDatabaseDropDown(ddlBrandName, sql, "", "Select Brand", "0");
        }

        int CarId = 0;

        if (Request.QueryString["carid"] != null)
        {
            CarId = Convert.ToInt16(Request.QueryString["carId"]);
        }

        PopulateGridView(CarId);

    }

    protected void onchange_ddlBrandName(object sender, EventArgs e)
    {
        ddlModelName.Items.Add(new ListItem("Select Model", "0"));
        String sql = "select ModelId, ModelName from ModelMaster where BrandId=" + ddlBrandName.SelectedValue;
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

        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();
        Response.Write("Successfully Inserted " + Convert.ToString(returnCode));

        //Important Part
        gridView.DataBind();
        PopulateGridView(0);
    }

    public void PopulateGridView(int carId)
    {
        //Getting the connection string from web.config file
        sqlDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        if (carId == 0)
        {
            sqlDataSource.SelectCommand = "Select b.*, m.*, c.* from ModelMaster m, BrandMaster b, CarMaster c "
            + " where b.BrandId=m.BrandId and m.ModelId=c.modelid";
        }
        else
        {
            sqlDataSource.SelectCommand = "Select b.*, m.*, c.* from ModelMaster m, BrandMaster b, CarMaster c"
                + " where b.BrandId=m.BrandId and m.ModelId=c.modelid and c.CarId=" + carId;
        }

        //Update statement. Here the Primary key of the table is testId and that has //been mentioned as
        //DataKeyNames="testId" in the GridView control on .aspx page.
        sqlDataSource.UpdateCommand = "Update CarMaster set CarColor=@CarColor, CarPrice=@CarPrice, CarMileage=@CarMileage, CarEngineType=@CarEngineType where CarId=@CarId";

        //Delete statement.
        sqlDataSource.DeleteCommand = "Delete CarMaster where ModelId=@ModelId";

    }

    protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink hl = (HyperLink)e.Row.FindControl("linkBrandName");
            hl.NavigateUrl = "javascript:window.open('carimage.aspx?carid=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CarId")) + "','',200,300);";
        }
    }
   
}