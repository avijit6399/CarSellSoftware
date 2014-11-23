using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Customer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["msg"] !=null){
            String msgStr = Request.QueryString["msg"].ToString();
            if (msgStr.Equals("success"))
            {
                msg.Text = "Successfully Added. Please Click Login link";
            }
            
        }

        if (!IsPostBack)
        {
            new CommonFunctions().fillGenderDropDown(ddlSex);
            new CommonFunctions().fillNumberDropDown(ddlDay, 1, 31, "DD", "0", "LowToHigh");
            new CommonFunctions().fillMonthDropDown(ddlMonth, "MMM", "0");
            new CommonFunctions().fillNumberDropDown(ddlYear, DateTime.Now.AddYears(-110).Year, DateTime.Now.AddYears(-18).Year, "YYYY", "0", "HighToLow");

            /*
            string sql = "select * from i_MotherTongueMaster order by MotherTongue";
            new CommonFunctions().fillDatabaseDropDown(motherTongueDropDown_search, sql, "5");
            new CommonFunctions().fillDatabaseDropDown(motherTongueDropDown, sql, "5");

            sql = "select * from i_ReligionMaster";
            new CommonFunctions().fillDatabaseDropDown(religionDropDown, sql, "2");

            new CommonFunctions().fillNumberDropDown(dropDownDay, 1, 31, "DD", "0", "LowToHigh");
            new CommonFunctions().fillMonthDropDown(dropDownMonth, "MMM", "0");
            new CommonFunctions().fillNumberDropDown(dropDownYear, DateTime.Now.AddYears(-80).Year, DateTime.Now.AddYears(-18).Year, "YYYY", "0", "HighToLow");
             */
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String sql="INSERT INTO [CarSellDb].[dbo].[CustomerMaster] ([FirstName],[LastName],[Email] ,[Password]";
            sql += ",[DateOfBirth] ,[Sex],[Address],[City],[State],[Country],[Pin],[PhoneNumber]) VALUES (";
            sql += "'" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtEmail.Text +"','" + txtPassword.Text +"'";
            sql += ",'" + ddlMonth.SelectedValue + "/" + ddlDay.SelectedValue + "/" + ddlYear.SelectedValue + "'";
            sql += ",'" + ddlSex.Text + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtState.Text + "','"
                + txtCountry.Text + "','" + txtPin.Text + "','" + txtPhoneNumber.Text + "')";

        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();
        if (returnCode>0)
        {
            Response.Redirect("Login.aspx?msg=success");
        }
    }
}