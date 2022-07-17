using System;
using EADP_Web_Dev.Code.Admin;

namespace EADP_Web_Dev.web.AdminEvent
{
	public partial class Booking : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void BtnBook_Click(object sender, EventArgs e)
		{

		}

		protected void BtnSubmit_Click(object sender, EventArgs e)
		{

			//BtnNew.Visible = true;
			//BtnSubmit.Visible = false;
			string name = TB_Name.Text.ToString();
			string contact = TB_Contact.Text.ToString();
			string date = calendar1.SelectedDate.ToLongDateString();
			string time = DDL_Time.SelectedItem.ToString();
			string facility = DDL_Facility.SelectedItem.ToString();
			string location = DDL_Location.SelectedItem.ToString();
			double price = Convert.ToDouble(DisplayPrice.Text.ToString());
			string email = TB_Email.Text.ToString();
			string status = "Pending";

			BookingDAO bookDAO = new BookingDAO();
			int insertRecord = bookDAO.InsertBooking(name, contact, date, time, facility, location, price, email, status);

			//String updatepass = "insert into AdminBooking(bookingID, name, contact, date, time, facility, location, price, email) values (" + lblBookID.Text + "','" + TB_Name.Text + "','" + TB_Contact.Text + "','" + calendar1.SelectedDate + "','" + DDL_Time.SelectedItem + "','" + DDL_Facility.SelectedItem + "','" + DDL_Location.SelectedItem + "','" + DisplayPrice.Text + "','" + TB_Email.Text + "')";

			//string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
			//SqlConnection scon = new SqlConnection(DBConnect);
			//scon.Open();
			//SqlCommand cmd = new SqlCommand();
			//cmd.CommandText = updatepass;
			//cmd.Connection = scon;
			//cmd.ExecuteNonQuery();

			//Label3.Text = "Succesfully booked!";
			//lblBookID.Text = "";
			//TB_Name.Text = "";
			//TB_Contact.Text = "";
			//DDL_Time.Text = "";
			//DDL_Facility.Text = "";
			//DDL_Location.Text = "";
			//DisplayPrice.Text = "";
			//TB_Email.Text = "";

			Session["name"] = name;
			Session["contact"] = contact;
			Session["date"] = date;
			Session["time"] = time;
			Session["facility"] = facility;
			Session["location"] = location;
			Session["price"] = price;
			Session["email"] = email;

			Response.Redirect("BookingSuccess.aspx");

		}

		protected void DDL_Facility_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (DDL_Facility.SelectedIndex == 1)
			{
				DisplayPrice.Text = "20.00";
			}

			else if (DDL_Facility.SelectedIndex == 2)
			{
				DisplayPrice.Text = "10.00";
			}

			else if (DDL_Facility.SelectedIndex == 3)
			{
				DisplayPrice.Text = "40.00";
			}

			else if (DDL_Facility.SelectedIndex == 4)
			{
				DisplayPrice.Text = "70.00";
			}
		}

		protected void DDL_Location_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void calendar1_SelectionChanged(object sender, EventArgs e)
		{

		}

		protected void BtnNew_Click(object sender, EventArgs e)
		{
			//getidno();
			//BtnSubmit.Visible = true;
			//BtnNew.Visible = false;
		}

		protected void ButtonEdit_Click(object sender, EventArgs e)
		{
			string name = TB_Name.Text.ToString();
			string contact = TB_Contact.Text.ToString();
			string date = calendar1.SelectedDate.ToLongDateString();
			string time = DDL_Time.SelectedItem.ToString();
			string facility = DDL_Facility.SelectedItem.ToString();
			string location = DDL_Location.SelectedItem.ToString();
			double price = Convert.ToDouble(DisplayPrice.Text.ToString());
			string email = TB_Email.Text.ToString();
			string status = "Pending";

			BookingDAO bookDAO = new BookingDAO();
			int updatebooking = bookDAO.UpdateBooking(name, contact, date, time, facility, location, price, email, status);

			Session["name"] = name;
			Session["contact"] = contact;
			Session["date"] = date;
			Session["time"] = time;
			Session["facility"] = facility;
			Session["location"] = location;
			Session["price"] = price;
			Session["email"] = email;

			Response.Redirect("BookingSuccess.aspx");
		}

		//public void getidno()
		//{
		//	string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
		//	SqlConnection scon = new SqlConnection(DBConnect);
		//	String myquery = "select bookingID from AdminBooking";
		//	SqlCommand cmd = new SqlCommand();
		//	cmd.CommandText = myquery;
		//	cmd.Connection = scon;
		//	SqlDataAdapter da = new SqlDataAdapter();
		//	da.SelectCommand = cmd;
		//	DataSet ds = new DataSet();
		//	da.Fill(ds);
		//	scon.Close();
		//	if (ds.Tables[0].Rows.Count < 1)
		//	{
		//		lblBookID.Text = "1";
		//	}
		//	else
		//	{
		//		string DBConnect1 = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
		//		SqlConnection scon1 = new SqlConnection(DBConnect1);
		//		String myquery1 = "select max(bookingID) from AdminBooking";
		//		SqlCommand cmd1 = new SqlCommand();
		//		cmd.CommandText = myquery;
		//		cmd.Connection = scon;
		//		SqlDataAdapter da1 = new SqlDataAdapter();
		//		da.SelectCommand = cmd;
		//		DataSet ds1 = new DataSet();
		//		da.Fill(ds);
		//		lblBookID.Text = ds1.Tables[0].Rows[0][0].ToString();
		//		int a;
		//		a = Convert.ToInt16(lblBookID.Text);
		//		a = a + 1;
		//		lblBookID.Text = a.ToString();
		//		scon1.Close();

		//	}
		//}
	}
}