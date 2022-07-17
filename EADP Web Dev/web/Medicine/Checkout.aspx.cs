using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace EADP_Web_Dev.web.Medicine
{
    public partial class Checkout : System.Web.UI.Page
    {
        string med = "";
        int amt = 0;
        int sum = 0;
        static Random random = new Random();

        string randnum = Convert.ToString(random.Next(10, 200));
        protected void Page_Load(object sender, EventArgs e)
        {


            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                sum += int.Parse(GridView1.Rows[i].Cells[4].Text);
            }
            lblTotal.Text = "Total Price: $" + sum.ToString();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                med += GridView1.Rows[i].Cells[1].Text + ",";
            }


            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                amt += int.Parse(GridView1.Rows[i].Cells[2].Text);
            }
            

        }



        protected void btnTest_Click(object sender, EventArgs e)
        {

            int result = 0;


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Medicine"].ConnectionString);
            conn.Open();

            string insertQuery = "Insert into Customer (id,name,address,telephone,email,medName, amount, totalPrice,cardNum,cardName,MM,YYYY,CVV,DeliType)" +
            " values(@id,@name,@addr, @phone, @email,@medName,@amt, @totalPrice,@cardNum, @cardName, @MM,@YYYY, @CVV,@DeliType)";
            SqlCommand com = new SqlCommand(insertQuery, conn);
            com.Parameters.AddWithValue("@id", randnum);
            com.Parameters.AddWithValue("@name", txtName.Value);
            com.Parameters.AddWithValue("@addr", txtAddress.Value);
            com.Parameters.AddWithValue("@phone", Convert.ToInt64(txtphone.Value));
            com.Parameters.AddWithValue("@email", txtEmail.Value);
            com.Parameters.AddWithValue("@medName", med);
            com.Parameters.AddWithValue("@amt", amt);
            com.Parameters.AddWithValue("@totalPrice", sum);
            com.Parameters.AddWithValue("@cardNum", (TextBox1.Text + TextBox2.Text + TextBox3.Text + TextBox4.Text));
            com.Parameters.AddWithValue("@cardName", TextBox5.Text);
            com.Parameters.AddWithValue("@MM", txtMM.Text);
            com.Parameters.AddWithValue("@YYYY", txtYear.Text);
            com.Parameters.AddWithValue("@CVV", txtCVV.Text);
            com.Parameters.AddWithValue("@DeliType", lblDelivery.Text);


            result = com.ExecuteNonQuery();
            conn.Close();
            Session["name"] = txtName.Value;
            Response.Redirect("Confirmation.aspx");

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
         
                if (TextBox1.Text == "4218")
                {
                    lblMaster.Visible = false;
                    lblVisa.Visible = true;
                    lblVisa.Text = "<img src='../../Images/visa.png' width= '50'>";
                lblErr1.Visible = false;
                }
                else if (TextBox1.Text == "5264")
                {
                    lblVisa.Visible = false;
                    lblMaster.Visible = true;
                    lblMaster.Text = "<img src='../../Images/mastercard.ico' width='50'>";
                lblErr1.Visible = false;
                }
                else
                {
                    lblErr1.Text = "Please enter a valid card";
                }

                if(btnDelivery.Checked == true)
            {
                lblDelivery.Visible = true;
                lblDelivery.Text = "Home delivery will take 3-5 working days";
            }
                else if (btnPickup.Checked == true)
            {
                lblDelivery.Visible = true;
                lblDelivery.Text = "Pick up location is at: Ang Mo Kio Community Center Medical Shop";
            }
            
        }

    }
}