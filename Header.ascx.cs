using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            NavigationMenu.Items.Add(new MenuItem("Update Pofile", "", "", "UpdateProfile.aspx"));

        }

        //For Admin Login
        if (Session["AdminId"] != null)
        {
            divLoginInfo.Visible = true;
            HeadLoginName.Text = Session["FirstName"].ToString();
            divLinkInfo.Visible = false;
            NavigationMenu.Items.Add(new MenuItem("Brand", "", "", "AddBrand.aspx"));
            NavigationMenu.Items.Add(new MenuItem("Model", "", "", "AddModel.aspx"));
            NavigationMenu.Items.Add(new MenuItem("Car Details", "", "", "Car.aspx"));
            NavigationMenu.Items.Add(new MenuItem("Update Pofile", "", "", "AdminUpdateProfile.aspx"));

        }

        NavigationMenu.Items.Add(new MenuItem("About", "", "", "About.aspx"));
        NavigationMenu.Items.Add(new MenuItem("Contact Us", "", "", "ContactUs.aspx"));

    }
}