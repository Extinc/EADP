using System;

namespace EADP_Web_Dev.web.AdminEvent
{

	public partial class BookingSuccess : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{

			Booking bookObj = new Booking();
			if (Session != null)
			{

				LabelName.Text = Session["name"].ToString();
				LabelContact.Text = Session["contact"].ToString();
				LabelDate.Text = Session["date"].ToString();
				LabelTime.Text = Session["time"].ToString();
				LabelFacility.Text = Session["facility"].ToString();
				LabelLocation.Text = Session["location"].ToString();
				LabelPrice.Text = Session["price"].ToString();
				LabelEmail.Text = Session["email"].ToString();

			}

			if (!this.IsPostBack)
			{
				//string filePath = Server.MapPath("~/~/Uploads") + Request.QueryString["FN"];
				//this.Response.ContentType = "application/pdf";
				//this.Response.AppendHeader("Content-Disposition;", "attachment;filename=" + Request.QueryString["FN"]);
				//this.Response.WriteFile(filePath);
				//this.Response.End();
			}
		}

		protected void ButtonPrint_Click(object sender, EventArgs e)
		{

		}

		protected void BtnUpdate_Click(object sender, EventArgs e)
		{
			Response.Redirect("Booking.aspx");
		}

		protected void View(object sender, EventArgs e)
		{
			//string url = string.Format("BookingSuccess.aspx?FN={0}.pdf", (sender as linkButton).CommandArgument);
			//string script = "<script type='text/javascript'>window.open('" + url + "')</script>";
			//this.ClientScript.RegisterStartupScript(this.GetType(), "script", script);
		}
	}
}
