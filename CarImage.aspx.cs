using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.IO;

public partial class CarImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int carid = 0;

        if (Request.QueryString["carid"] != null)
        {
            carid = Convert.ToInt16(Request.QueryString["carid"]);
            hiddenField.Value = carid.ToString();
        }

        String sql = "";
        //sql = "SELECT * FROM [CarSellDb].[dbo].[CarMaster]";
        sql = "select c.*, m.*, b.* from CarMaster c, ModelMaster m, BrandMaster b "
            + " where b.brandid = m.brandid "
            + " and m.modelid = c.modelid "
            + " and CarId=" + carid;


        DbClass dc = new DbClass();
        DataSet ds = dc.returnDataSet(sql);

        if (ds.Tables[0].Rows.Count > 0)
        {
            carImage.ImageUrl = "CarImages/" + ds.Tables[0].Rows[0]["ImageName"].ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String fileName = "";

        if (fileUpload.HasFile)
        {
            try
            {
                fileName = Path.GetFileName(fileUpload.FileName);
                fileUpload.SaveAs(CommonFunctions.getServerPath() + "/CarImages/" + fileName);
                String sql = "Update CarMaster set ImageName ='" + fileName.Replace("'", "''") + "' where CarId=" + hiddenField.Value;

                string conStr = DbClass.getConnectionStr();
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                SqlCommand command = new SqlCommand(sql, con);
                int returnCode = command.ExecuteNonQuery();
                Response.Redirect("CarImage.aspx?Carid=" + hiddenField.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}