using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Header : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        NavigationMenu.Items.Add(new MenuItem("Home", "", "", "Home.aspx"));
        NavigationMenu.Items.Add(new MenuItem("Search Car", "", "", "CarSearch.aspx"));
        
        if (Session["CustId"] != null)
        {
            divLoginInfo.Visible = true;
            HeadLoginName.Text = Session["FirstName"].ToString();
            divLinkInfo.Visible = false;

            String sql = "select * from AppointmentDetails where Status='Scheduled' and CustId=" + SessionManagement.getSession("custId");
            DbClass dc = new DbClass();
            int recordCount = dc.getRecordCountFromQuery(sql);
            if (recordCount > 0)
            {
                NavigationMenu.Items.Add(new MenuItem("Appointments <font color='red'>" + "[" + recordCount + "]</font>", "", "", "CustomerAppointmentDetails.aspx"));
            }
            else
            {
                NavigationMenu.Items.Add(new MenuItem("Appointments", "", "", "CustomerAppointmentDetails.aspx"));
            }

            NavigationMenu.Items.Add(new MenuItem("Update Pofile", "", "", "CustomerUpdateProfile.aspx"));

        }

        //For Admin Login
        if (Session["AdminId"] != null)
        {
            divLoginInfo.Visible = true;
            HeadLoginName.Text = Session["FirstName"].ToString() + " [Admin] ";
            divLinkInfo.Visible = false;
            NavigationMenu.Items.Add(new MenuItem("Brand", "", "", "AddBrand.aspx"));
            NavigationMenu.Items.Add(new MenuItem("Model", "", "", "AddModel.aspx"));
            NavigationMenu.Items.Add(new MenuItem("Car Details", "", "", "Car.aspx"));


            String sql = "select * from AppointmentDetails where Status='Waiting for Approval'";
            DbClass dc = new DbClass();
            int recordCount = dc.getRecordCountFromQuery(sql);
            if (recordCount > 0)
            {
                NavigationMenu.Items.Add(new MenuItem("Manage Appointment <font color='red'>" + "[" + recordCount + "]</font>", "", "", "AdminManageAppointment.aspx"));
            }
            else
            {
                NavigationMenu.Items.Add(new MenuItem("Manage Appointment", "", "", "AdminManageAppointment.aspx"));
            }
        }

        NavigationMenu.Items.Add(new MenuItem("About", "", "", "About.aspx"));
        NavigationMenu.Items.Add(new MenuItem("Contact Us", "", "", "ContactUs.aspx"));

    }
}