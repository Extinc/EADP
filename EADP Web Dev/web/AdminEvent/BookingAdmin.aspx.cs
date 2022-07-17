using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace EADP_Web_Dev.web.AdminEvent
{
	public partial class BookingAdmin : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
			
			}
		}


		protected void bookingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			// this segment changes colour of a row based on status value = PENDING
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				string defaultamtS = e.Row.Cells[6].Text;
			}
		}


		protected void bookingDetails_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow row = bookingDetails.SelectedRow;
			Session["emailAddr"] = row.Cells[9].Text;
			Response.Redirect("Email.aspx");
		}


		protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			bookingDetails.PageIndex = e.NewPageIndex;
			
		}


		public override void VerifyRenderingInServerForm(Control control)
		{
			/* Verifies that the control is rendered */
		}

		protected void ButtonPDF_Click(object sender, EventArgs e)
		{
			using (StringWriter sw = new StringWriter())
			{
				using (HtmlTextWriter hw = new HtmlTextWriter(sw))
				{
					//To Export all pages
					bookingDetails.AllowPaging = false;
					

					bookingDetails.RenderControl(hw);
					StringReader sr = new StringReader(sw.ToString());
					Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
					HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
					PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
					pdfDoc.Open();
					htmlparser.Parse(sr);
					pdfDoc.Close();

					Response.ContentType = "application/pdf";
					Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
					Response.Cache.SetCacheability(HttpCacheability.NoCache);
					Response.Write(pdfDoc);
					Response.End();
				}
			}
		}
	}
}