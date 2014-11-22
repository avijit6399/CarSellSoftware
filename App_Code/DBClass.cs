using System;
using System.Collections.Generic;
using System.Web;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBClass
/// </summary>
public class DbClass
{
    public DbClass()
    {

    }
    public static String getConnectionStr()
    {
        return WebConfigurationManager.ConnectionStrings["conStr"].ToString();
    }

    public SqlConnection SqlCon()
    {
        string conStr = DbClass.getConnectionStr();
        SqlConnection con = new SqlConnection(conStr);
        return con;
    }



    public DataSet returnDataSet(string sqlStr)
    {
        DataSet ds = new DataSet();
        DbClass dc = new DbClass();
        SqlConnection con = dc.SqlCon();
        SqlCommand com = new SqlCommand();

        com.Connection = con;
        com.CommandText = sqlStr;
        com.CommandType = CommandType.Text;

        SqlDataAdapter sda = new SqlDataAdapter(com);
        try
        {
            sda.Fill(ds);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet returnDataSet(string sqlStr, string tableName)
    {
        DataSet ds = new DataSet();
        DbClass dc = new DbClass();
        SqlConnection con = dc.SqlCon();
        SqlCommand com = new SqlCommand();

        com.Connection = con;
        com.CommandText = sqlStr;
        com.CommandType = CommandType.Text;

        SqlDataAdapter sda = new SqlDataAdapter(com);
        try
        {
            sda.Fill(ds.Tables[tableName]);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

}