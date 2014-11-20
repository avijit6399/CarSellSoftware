using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public class CommonFunctions
{
    public CommonFunctions()
    {

    }

    //Gender List
    #region fillGenderDropDown
    public void fillGenderDropDown(DropDownList dl)
    {
        dl.Items.Clear();

        dl.Items.Add(new ListItem("Male", "M"));
        dl.Items.Add(new ListItem("Female", "F"));
    }
    #endregion

    //Filled with number
    #region fillNumberDropDown
    public void fillNumberDropDown(DropDownList dl, int startNumber, int endNumber)
    {
        dl.Items.Clear();

        if (startNumber <= endNumber)
        {
            for (int i = startNumber; i <= endNumber; i++)
            {
                dl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        else
        {
            dl.Items.Add(new ListItem("-1", "-1"));
        }

    }
    #endregion

    #region fillNumberDropDown
    public void fillNumberDropDown(DropDownList dl, int startNumber, int endNumber, string firstItemText, string firstItemValue, string direction)
    {
        dl.Items.Clear();
        dl.Items.Add(new ListItem(firstItemText, firstItemValue));
        if (startNumber <= endNumber && direction == "LowToHigh")
        {
            for (int i = startNumber; i <= endNumber; i++)
            {
                dl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        else if (startNumber <= endNumber && direction == "HighToLow")
        {
            for (int i = endNumber; i > startNumber; i--)
            {
                dl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        else
        {
            dl.Items.Add(new ListItem("-1", "-1"));
        }
    }
    #endregion

    #region fillNumberDropDown
    public void fillNumberDropDown(DropDownList dl, int startNumber, int endNumber, string firstItemText, string firstItemValue, string direction, string selectValue)
    {
        dl.Items.Clear();
        dl.Items.Add(new ListItem(firstItemText, firstItemValue));
        if (startNumber <= endNumber && direction == "LowToHigh")
        {
            for (int i = startNumber; i <= endNumber; i++)
            {
                dl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        else if (startNumber <= endNumber && direction == "HighToLow")
        {
            for (int i = endNumber; i > startNumber; i--)
            {
                dl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        else
        {
            dl.Items.Add(new ListItem("-1", "-1"));
        }
        if (selectValue != "")
        {
            dl.SelectedValue = selectValue;
        }
    }
    #endregion

    //Database DropDown List
    #region fillDatabaseDropDown
    public void fillDatabaseDropDown(DropDownList dl, string sql, string selectValue)
    {
        dl.Items.Clear();

        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdr;
        try
        {
            con.Open();
            sdr = com.ExecuteReader();
            //Response.Write("Total Field = " + sdr.FieldCount.ToString());
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    dl.Items.Add(new ListItem(sdr[1].ToString(), sdr[0].ToString()));
                }
                if (selectValue != "")
                {
                    dl.SelectedValue = selectValue;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con = null;
            com = null;
            sdr = null;
        }
    }
    #endregion

    #region fillDatabaseDropDown
    public void fillDatabaseDropDown(DropDownList dl, string sql, string selectValue, string firstElementName, string firstElementValue)
    {
        dl.Items.Clear();

        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand com = new SqlCommand(sql, con);
        SqlDataReader sdr;
        try
        {
            dl.Items.Add(new ListItem(firstElementName, firstElementValue));
            con.Open();
            sdr = com.ExecuteReader();

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    dl.Items.Add(new ListItem(sdr[1].ToString(), sdr[0].ToString()));
                }
                if (selectValue != "")
                {
                    dl.SelectedValue = selectValue;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con = null;
            com = null;
            sdr = null;
        }
    }
    #endregion

    #region fillMonthDropDown
    public void fillMonthDropDown(DropDownList dl, string firstItemText, string firstItemValue)
    {
        dl.Items.Clear();
        dl.Items.Add(new ListItem(firstItemText, firstItemValue));
        for (int i = 1; i <= 12; i++)
        {
            dl.Items.Add(new ListItem(getMonthName(i), i.ToString()));
        }
    }
    #endregion

    #region fillMonthDropDown
    public void fillMonthDropDown(DropDownList dl, string firstItemText, string firstItemValue, string selectValue)
    {
        dl.Items.Clear();
        dl.Items.Add(new ListItem(firstItemText, firstItemValue));
        for (int i = 1; i <= 12; i++)
        {
            dl.Items.Add(new ListItem(getMonthName(i), i.ToString()));
        }
        if (selectValue != "")
        {
            dl.SelectedValue = selectValue;
        }
    }
    #endregion

    #region selectDropDownValue
    public void selectDropDownValue(DropDownList dl, string strValue)
    {
        try
        {
            dl.SelectedValue = strValue;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion

    #region OtherFunction
    public static bool isDate(string date)
    {
        DateTime dt;
        return DateTime.TryParse(date, out dt);
    }


    public static string getMonthName(int month)
    {
        DateTime dt = new DateTime(2000, month, 1);
        return dt.ToString("MMM");
    }
    #endregion
    //EngineType List
    #region fillEngineDropDown
    public void fillEngineDropDown(DropDownList d1)
    {
        d1.Items.Clear();

        d1.Items.Add(new ListItem("Select", "Select"));
        d1.Items.Add(new ListItem("Petrol", "P"));
        d1.Items.Add(new ListItem("Diesel", "D"));
    }
    #endregion

    public static String getServerPath()
    {
        return HttpContext.Current.Server.MapPath("~/");
    }
    #region fillBrandDropDown
    public void fillBrandDropDown(DropDownList d1)
    {
        d1.Items.Clear();

        d1.Items.Add(new ListItem("Select", "Select"));
        d1.Items.Add(new ListItem("Honda", "Honda"));
        d1.Items.Add(new ListItem("Hyundai", "Hyundai"));
        d1.Items.Add(new ListItem("Mahindra", "Mahindra"));
        d1.Items.Add(new ListItem("Tata", "Tata"));
    }
    #endregion
}