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
            txtCarId.Value = CarId.ToString();
        }
        else
        {
            txtCarId.Value = "";
        }

        PopulateGridView(CarId);
    }
    
    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        if (SessionManagement.isCustomerSession() == false)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?msg=loginreqappointment");
        }

        string sql = "";
        //sql = "SELECT * FROM [CarSellDb].[dbo].[CarMaster]";
        sql = "Insert into AppointmentDetails (CarId, CustId, PreferredDateTime, status) values ("
            + "'" + txtCarId.Value + "'"
            + ",'" + SessionManagement.getSession("custId") + "'" 
            + ",'" + txtDateTime.Text.Replace("'","''") + "','Waiting for Approval')";

        string conStr = DbClass.getConnectionStr();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();
        //Response.Write("Successfully Inserted " + Convert.ToString(returnCode));
        
       
    }

    public void PopulateGridView(int carId)
    {
        //Getting the connection string from web.config file
        sqlDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        if (carId != 0)
        {
            sqlDataSource.SelectCommand = "Select b.*, m.*, c.* from ModelMaster m, BrandMaster b, CarMaster c"
                + " where b.BrandId=m.BrandId and m.ModelId=c.modelid and c.CarId=" + carId;
        }

    }
    
}