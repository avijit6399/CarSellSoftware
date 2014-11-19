using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.SessionState;

/// <summary>
/// Summary description for SessionManagement
/// </summary>
public class SessionManagement
{
	public SessionManagement()
	{
		
	}

    public static String getSession(String sessionKey)
    {
        String sessionValue="";
        try
        {
            if (System.Web.HttpContext.Current.Session[sessionKey] != null)
            {
                sessionValue = System.Web.HttpContext.Current.Session[sessionKey].ToString();
            }
            else
            {
                sessionValue = null;
            }
            
        }
        catch(System.Exception e)
        {
            throw e;
        }

        return sessionValue;

    }

    public static Boolean isAdminSession()
    {
        if (getSession("AdminId") == null)
        {
            return false;
        }
        else
        {
            if (getSession("AdminId").Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}