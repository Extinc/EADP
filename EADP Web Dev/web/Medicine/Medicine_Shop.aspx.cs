using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EADP_Web_Dev.web.Medicine
{
    public partial class Medicine_Shop : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Get connection string from web.config
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            //Create Adapter
            //WRITE SQL Statement to retrieve columns from Medicine
            //by medID using query parameter



            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            lblID.Text = "1";
            lblID2.Text = "2";
            ///medicine 1
            SqlCommand cmd1 = new SqlCommand("SELECT * from Medicine where medID = " + lblID.Text);
            cmd1.Connection = myConn;

             SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                med1.Text = reader1["medName"].ToString();
            }
            reader1.Close();
            ///medicine 2
            SqlCommand cmd2 = new SqlCommand("SELECT * from Medicine where medID = " + lblID2.Text);
            cmd2.Connection = myConn;

            SqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                med2.Text = reader2["medName"].ToString();
            }
        }
        protected void btnView_Click(object sender ,EventArgs e)
        {
            Session["lblID"] = lblID.Text;
            Session["lblID2"] = lblID2.Text;
            Response.Redirect("Panadol.aspx");
        }
        protected void btnView_Click2(object sender, EventArgs e)
        {
            Session["lblID"] = lblID.Text;
            Session["lblID2"] = lblID2.Text;
            Response.Redirect("Aspirin.aspx");
        }
    }
}