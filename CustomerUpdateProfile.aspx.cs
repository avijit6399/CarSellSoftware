using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using Extension;

public partial class CustomerUpdateProfile : System.Web.UI.Page
{
    public String currentDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (SessionManagement.isCustomerSession() == false)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?msg=loginreqforupdateprofile");
        }

        String msg = "";
        if (Request.QueryString["msg"] != null)
        {
            msg = Request.QueryString["msg"].ToString();
        }

        //Current Date
        currentDate = DateTime.Now.ToString("MM/dd/yyyy");
        validateDob.ValueToCompare = currentDate;

        if(!IsPostBack)
        {
            String sql = "Select * from CustomerMaster where CustId=" + SessionManagement.getSession("custId");
            DbClass dc = new DbClass();
            DataSet ds = dc.returnDataSet(sql);
            if(ds.Tables[0].Rows.Count > 0)
            {
                txtFirstName.Text = getDataFromDataSet(ds, "FirstName");
                txtLastName.Text = getDataFromDataSet(ds, "LastName");
                txtEmail.Text = getDataFromDataSet(ds, "Email");

                DateTime dt = Convert.ToDateTime(getDataFromDataSet(ds, "DateOfBirth"));
                txtDob.Text = String.Format("{0:MM/dd/yyyy}", dt);
                listGender.SelectedValue = getDataFromDataSet(ds, "Sex");

                txtAddress.Text = getDataFromDataSet(ds, "Address");
                txtCity.Text = getDataFromDataSet(ds, "City");
                txtState.Text = getDataFromDataSet(ds, "State");

                txtCountry.Text = getDataFromDataSet(ds, "Country");
                txtPin.Text = getDataFromDataSet(ds, "Pin");
                txtPhoneNumber.Text = getDataFromDataSet(ds, "PhoneNumber");
            }
        }
    }

    public String getDataFromDataSet(DataSet ds,String columnName)
    {
        return ds.Tables[0].Rows[0][columnName].ToString();
    }
    
    protected void btnSchedule_Click(object sender, EventArgs e)
    {
        if (SessionManagement.isCustomerSession() == false)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx?msg=loginreqforupdateprofile");
        }

    }

    public void PopulateGridView(int carId)
    {
        //Getting the connection string from web.config file
        sqlDataSource.ConnectionString = WebConfigurationManager.ConnectionStrings["conStr"].ToString();

        sqlDataSource.SelectCommand = "Select *,Cast(DateOfBirth as date) as Dob from CustomerMaster where CustId=" + SessionManagement.getSession("custId");

        sqlDataSource.UpdateCommand = "Update CustomerMaster set FirstName=@FirstName, "
            + " LastName=@LastName, DateOfBirth=@DateOfBirth, Sex=@Sex, Address=@Address, City=@City, State=@State, Country=@Country, Pin=@Pin "
            + " where CustId=" + SessionManagement.getSession("custId")
            +"";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String sql = "Update CustomerMaster set FirstName='{0}', "
            + " LastName='{1}', DateOfBirth='{2}', Sex='{3}', Address='{4}', "
            + " City='{5}', State='{6}', Country='{7}', Pin='{8}', PhoneNumber='{9}', Email='{10}' "
            + " where CustId=" + SessionManagement.getSession("custId");



        sql = String.Format(sql, txtFirstName.Text.ReplaceQuote(), txtLastName.Text.ReplaceQuote(), txtDob.Text.ReplaceQuote(),
            listGender.SelectedValue.ToString(), txtAddress.Text.ReplaceQuote(), txtCity.Text.ReplaceQuote(),
            txtState.Text.ReplaceQuote(), txtCountry.Text.ReplaceQuote(), txtPin.Text.ReplaceQuote(), txtPhoneNumber.Text.ReplaceQuote(), txtEmail.Text.ReplaceQuote());

        SqlConnection con = new SqlConnection(DbClass.getConnectionStr());
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);
        int returnCode = command.ExecuteNonQuery();
        if (returnCode > 0)
        {
            lblMsg.Text = "Successfully Updated";
        }
    }
}