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
    public partial class Aspirin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblID2.Text = "2";

            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            myConn.Open();
            ///Aspirin price
            SqlCommand cmd = new SqlCommand("SELECT * from Medicine where medID = 2");
            cmd.Connection = myConn;

            SqlDataReader reader1 = cmd.ExecuteReader();

            while (reader1.Read())
            {
                lblprice.InnerText = reader1["medPrice"].ToString();
            }
            reader1.Close();

            ///Aspirin quantity

            SqlDataReader reader3 = cmd.ExecuteReader();

            while (reader3.Read())
            {
                object quantity;
                quantity = reader3["medQuantity"].ToString();

                lblquantity.InnerText = "Quantity: " + quantity.ToString();
            }
            reader3.Close();

            ///Aspirin stock
            SqlDataReader reader2 = cmd.ExecuteReader();

            while (reader2.Read())
            {
                object stock;
                stock = reader2["medQuantity"].ToString();

                if (stock == null)
                {
                    lblstock.Text = "No Stock!";
                }
                else
                {
                    lblstock.Text = "In Stock!";
                }
            }
            reader2.Close();

        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Medicine"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT medID from medCart where medID = " + lblID2.Text);
            cmd.Connection = conn;

            SqlDataReader reader1 = cmd.ExecuteReader();

            if (reader1.Read())
            {
                lblErr.Text = "Already exist in Cart!";
            }
            else
            {
                string insertQuery = "Insert into MedCart (medID, medName, amount, medPrice) values(@id, @name, 1, @price)";
                SqlCommand com = new SqlCommand(insertQuery, conn);
                com.Parameters.AddWithValue("@id", lblID2.Text);
                com.Parameters.AddWithValue("@name", lblName.Text);
                com.Parameters.AddWithValue("@price", lblprice.InnerText);
                result = com.ExecuteNonQuery();
                conn.Close();

                if (result == 1)
                {
                    lblMessage.Text = "Rows Inserted!";
                }
                else
                {
                    lblMessage.Text = "ERROR";
                }

                Response.Redirect("Cart.aspx");
            }
        }
        protected void btnCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
    }
}