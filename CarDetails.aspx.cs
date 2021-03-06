﻿using System;
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
    public String minDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Date Logic written here
        Boolean isNewDay=false;
        DateTime src = DateTime.Now;
        src = src.AddHours(2);

        if(src.Hour > 20)
        {
            src = src.AddDays(1);
            isNewDay = true;
        }

        minDate = src.Year + "," + (src.Month-1) + "," + src.Day + "," ;

        if (isNewDay == true)
        {
            minDate += "8" + "," + "30";
        }
        else
        {
            minDate += src.Hour + "," + src.Minute;
        }
        //DateTime Logic ends here


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
        sql = "Insert into AppointmentDetails (CarId, CustId, PreferredDateTime, status) values ("
            + "'" + txtCarId.Value + "'"
            + ",'" + SessionManagement.getSession("custId") + "'" 
            + ",'" + txtDateTime.Text.Replace("'","''") + "','Waiting for Approval')";

        string conStr = DbClass.getConnectionStr();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();
        Response.Redirect("CustomerAppointmentDetails.aspx?msg=added");
      
    }

    public void PopulateGridView(int carId)
    {
        //Getting the connection string from web.config file
        sqlDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        if (carId != 0)
        {
            sqlDataSource.SelectCommand = "Select b.*, m.*, c.*, EngineType = case c.CarEngineType when 'P' then 'PETROL' WHEN 'D' THEN 'DIESEL' END from ModelMaster m, BrandMaster b, CarMaster c"
                + " where b.BrandId=m.BrandId and m.ModelId=c.modelid and c.CarId=" + carId;
        }

    }
    
}