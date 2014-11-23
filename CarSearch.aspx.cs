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
            ddlModel.Items.Add(new ListItem("Select Model","0"));
            //new CommonFunctions().fillBrandDropDown(ddlBrandName);

            String sql = "select BrandId, BrandName from BrandMaster";
            CommonFunctions cf = new CommonFunctions();
            cf.fillDatabaseDropDown(ddlBrandName, sql, "", "Select Brand", "0");
            //ddlBrandName.Items.Add(new ListItem("Select Brand", "0"));
            divGridView.Visible = false;

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
            + " and m.modelid = c.modelid ";

        if (ddlModel.SelectedValue != "")
        {
            sql = sql + " and m.modelid=" + ddlModel.SelectedValue;
        }

        if (ddlEngineType.SelectedValue != "Select")
        {
            sql += " and c.CarEngineType='" + ddlEngineType.SelectedValue + "'";
        }
        
        DbClass dc = new DbClass();
        DataSet ds = dc.returnDataSet(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gridView.DataSource = ds;
            gridView.DataBind();
            divGridView.Visible = true;
        }
        else
        {
            divGridView.Visible = false;
        }
       
    }
    
}