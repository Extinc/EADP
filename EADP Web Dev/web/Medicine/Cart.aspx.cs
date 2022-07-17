using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EADP_Web_Dev.web.Medicine
{
    public partial class Cart : System.Web.UI.Page
    {

        TextBox txtQuantity = new TextBox();

        public void Page_Load(object sender, EventArgs e)
        {
            GridView1.Rows[0].Cells[2].Controls.Add(txtQuantity);
            string DBConnect;
            DBConnect = ConfigurationManager.ConnectionStrings["Medicine"].ConnectionString;
            //Create Adapter
            //WRITE SQL Statement to retrieve columns from Medicine
            //by medID using query parameter

            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            ///medicine 1
            SqlCommand cmd1 = new SqlCommand("SELECT * from MedCart");
            cmd1.Connection = myConn;

            SqlDataReader reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                txtQuantity.Text = reader1["Amount"].ToString();
            }
            reader1.Close();

        }

        protected int calcprice(int qty, int price)
        {
            return qty * price;
        }



        public void btnUpdate_Click(object sender, EventArgs e)
        {
            int qty = 0, price = 0, result = 0;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Medicine"].ConnectionString);
            conn.Open();

            //SqlCommand cmd1 = new SqlCommand("select Amount, medPrice from MedCart where medID = '" + Session["lblID"] + "'");
            SqlCommand cmd1 = new SqlCommand("select Amount, medPrice from MedCart where medID = 1");
            cmd1.Connection = conn;
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                qty = Convert.ToInt16(reader1["Amount"]);
                price = Convert.ToInt16(reader1["medPrice"]);
            }
            reader1.Close();
            int total = calcprice(qty, price);

            //string insertQuery = "UPDATE MedCart SET Amount = @qty, total = @total WHERE medID = '" + Session["lblID"] + "'";
            string insertQuery = "UPDATE MedCart SET Amount = @qty, total = @total WHERE medID = 1";
            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@qty", txtQuantity.Text);
            com.Parameters.AddWithValue("@total", total);

            result = com.ExecuteNonQuery();

            //SqlCommand cmd2 = new SqlCommand("SELECT Amount from MedCart where medID = '" + Session["lblID"] +"'");
            SqlCommand cmd2 = new SqlCommand("SELECT Amount from MedCart where medID = 1");
            cmd2.Connection = conn;

            SqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                txtQuantity.Text = reader2["Amount"].ToString();
            }
            reader2.Close();
            conn.Close();
        }

        ///add total price
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Totals = int.Parse(e.Row.Cells[4].Text); //Just Change the cells index based on your requirements
                lblTotal.Text += Totals.ToString();
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        ///delete DB
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e){

    if (e.CommandName == "DeleteRow")
    {
                Int32 Id = Convert.ToInt32(e.CommandArgument.ToString());
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Medicine"].ConnectionString);
                conn.Open();

                SqlCommand cmd1 = new SqlCommand("delete from MedCart where medID = 1");
                cmd1.Connection = conn;
                cmd1.ExecuteNonQuery();

                GridView1.DataBind(); // Bind your gridview again. 
                conn.Close();
    }

}

    }
}