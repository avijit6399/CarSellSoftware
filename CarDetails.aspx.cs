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
        int CarId = 0;

        if (Request.QueryString["carid"] != null)
        {
            CarId = Convert.ToInt16(Request.QueryString["carId"]);
        }

        PopulateGridView(CarId);
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sql = "";
        //sql = "SELECT * FROM [CarSellDb].[dbo].[CarMaster]";
        sql = "select c.*, m.*, b.* from CarMaster c, ModelMaster m, BrandMaster b "
            + " where b.brandid = m.brandid "
            + " and m.modelid = c.modelid "
            + " and m.modelid=" + ""
            + " and c.CarEngineType='" + "" + "'";

        DbClass dc = new DbClass();
        DataSet ds = dc.returnDataSet(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //gridView.DataSource = ds;
            //gridView.DataBind();
            //divGridView.Visible = true;
        }
        else
        {
            //divGridView.Visible = false;
        }
       
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

    }
    
}