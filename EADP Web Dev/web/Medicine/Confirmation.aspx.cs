using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Web_Dev.web.Medicine
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String name = Session["name"].ToString();

            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["Medicine"].ConnectionString;
            //Create Adapter
            //WRITE SQL Statement to retrieve columns from Medicine
            //by medID using query parameter

            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();

            SqlCommand cmd1 = new SqlCommand("SELECT * from Customer where name = '" + name + "'");
            cmd1.Connection = myConn;

            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                lblName.Text = reader1["name"].ToString();
                lblID.Text = reader1["id"].ToString();
                lblItems.Text = reader1["medName"].ToString();
                lbltotal.Text = reader1["totalPrice"].ToString();
            }
            reader1.Close();
        }
    }
}