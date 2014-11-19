using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ToString();
        SqlConnection con = new SqlConnection(conStr);
        String sql = "select * from CarMaster";
        con.Open();

        SqlCommand command = new SqlCommand(sql, con);

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows == true)
        {
            while (reader.Read())
            {
                Response.Write("Value = " + reader["CarBrand"].ToString());
            }
        }
        else
        {
            Console.WriteLine("No rows found.");
        }
        reader.Close();
    }
}
