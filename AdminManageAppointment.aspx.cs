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
        if (SessionManagement.isAdminSession() == false)
        {
            Session.Abandon();
            Response.Redirect("AdminLogin.aspx");
        }

        if (Request.QueryString["msg"] != null)
        {
            String msgStr = Request.QueryString["msg"].ToString();
            if (msgStr.Equals("added"))
            {
                lblMsg.Text = "Appoint Request sent. Waiting for Confirmation";
            }

        }


        PopulateGridView();
    }

    

    public void PopulateGridView()
    {
        //Getting the connection string from web.config file
        sqlDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        sqlDataSource.SelectCommand = "Select b.*, m.*, c.*, ad.*,cm.* from ModelMaster m, BrandMaster b, CarMaster c, AppointmentDetails ad, CustomerMaster cm "
                + " where b.BrandId=m.BrandId and m.ModelId=c.modelid and ad.CarId=c.CarId and ad.CustId=cm.CustId order by ad.DateCreated desc";

        sqlDataSource.UpdateCommand = "Update AppointmentDetails set Status=@Status where AppointmentId=@AppointmentId";

        //Delete statement.
        sqlDataSource.DeleteCommand = "Delete AppointmentDetails where AppointmentId=@AppointmentId";
    }
}