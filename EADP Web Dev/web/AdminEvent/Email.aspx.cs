using System;
using System.Data.SqlClient;
using System.Net.Mail;

namespace EADP_Web_Dev.web.AdminEvent
{
	public partial class email : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			from.Text = "pzpzeadp@gmail.com";
			from.ReadOnly = true;
			subject.Text = "Booking Status";
			subject.ReadOnly = true;

			if (IsPostBack == false)
			{
				to.Text = Session["emailAddr"].ToString();
			}

		}

		protected void send_click(object sender, EventArgs e)
		{
			try
			{
				MailMessage message = new MailMessage(from.Text, to.Text, subject.Text, body.Text);
				message.IsBodyHtml = true;

				SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
				client.EnableSsl = true;
				client.Credentials = new System.Net.NetworkCredential("pzpzeadp@gmail.com", "pzpzpzppz");
				client.Send(message);
				status.Text = "Mail was sent successfully!";
			}
			catch (Exception ex)
			{
				status.Text = ex.StackTrace;
			}
		}
		protected void accept_click(object sender, EventArgs e)
		{
		    string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
		    string email = to.Text;
            SqlConnection con = new SqlConnection(DBConnect);
			con.Open();
			SqlCommand com = new SqlCommand("Update Booking set status = 'Approved' where email = '"+email+"'",con);
		    com.ExecuteNonQuery();
            con.Close();

			body.Text = "We are pleased to inform you that your booking has been approved!";
		}
		protected void decline_click(object sender, EventArgs e)
		{
		    string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
		    string email = to.Text;
		    SqlConnection con = new SqlConnection(DBConnect);
		    SqlCommand com = new SqlCommand("Update Booking set status = 'Declined' where email = '" + email + "'",con);
		    con.Open();
		    com.ExecuteNonQuery();
		    con.Close();

            body.Text = "We are sorry to inform you that your booking has been declined. Please contact us for any enquiry.";
		}

		protected void BtnBack_Click(object sender, EventArgs e)
		{
			Response.Redirect("BookingAdmin.aspx");
		}
	}
}