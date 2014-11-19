using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class CarSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            new CommonFunctions().fillEngineDropDown(ddlEngineType);
            //new CommonFunctions().fillBrandDropDown(ddlBrandName);

            String sql = "select BrandId, BrandName from BrandMaster";
            CommonFunctions cf = new CommonFunctions();
            cf.fillDatabaseDropDown(ddlBrandName, sql, "");
            //ddlBrandName.Items.Add(new ListItem("Select Brand", "0"));


        }
    }
    protected void onchange_ddlBrandName(object sender, EventArgs e)
    {
        ddlModel.Items.Add(new ListItem("Select Model", "0"));
        String sql = "select ModelId, ModelName from ModelMaster where BrandId=" + ddlBrandName.SelectedValue;
        CommonFunctions cf = new CommonFunctions();
        cf.fillDatabaseDropDown(ddlModel, sql, "");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sql = "";
        //sql = "SELECT * FROM [CarSellDb].[dbo].[CarMaster]";
        sql = "select c.*, m.*, b.* from CarMaster c, ModelMaster m, BrandMaster b "
            + " where b.brandid = m.brandid "
            + " and m.modelid = c.modelid "
            + " and m.modelid=" + ddlModel.SelectedValue
            + " and c.CarEngineType='" + ddlEngineType.SelectedValue + "'";
        
        Response.Write(sql);

        DbClass dc = new DbClass();
        DataSet ds = dc.returnDataSet(sql);


        /*
        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        SqlDataAdapter sda = new SqlDataAdapter(command);
        DataSet ds = new DataSet();
        sda.Fill(ds);
         */

        gridView.DataSource = ds;
        gridView.DataBind();
    }
    
}