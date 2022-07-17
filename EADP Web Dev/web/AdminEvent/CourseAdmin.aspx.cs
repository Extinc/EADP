using System;
using EADP_Web_Dev.Code.Admin;

namespace EADP_Web_Dev.web.AdminEvent
{
	public partial class AdminDetails : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}


		protected void btnUpload_Click(object sender, EventArgs e)
		{
			if (FileUpload1.HasFile)
			{
				string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

				if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx")
				{
					lblMessage.Text = "Only files with .doc or .docx extension are allowed";
					lblMessage.ForeColor = System.Drawing.Color.Red;
				}
				else
				{
					int fileSize = FileUpload1.PostedFile.ContentLength;
					if (fileSize > 102400)
					{
						lblMessage.Text = "Maximum file size (100KB) exceeded";
						lblMessage.ForeColor = System.Drawing.Color.Red;
					}

					else
					{
						FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
						lblMessage.Text = "File Uploaded";
						lblMessage.ForeColor = System.Drawing.Color.Green;
					}
				}
			}
			else
			{
				lblMessage.Text = "Please select a file to upload";
				lblMessage.ForeColor = System.Drawing.Color.Red;
			}
		}

		protected void btnPrevious_Click(object sender, EventArgs e)
		{
			Response.Redirect("CourseMain.aspx");
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{

		}


		protected void btnCreate_Click(object sender, EventArgs e)
		{
			string courseName = TB_CourseName.Text.ToString();
			string location = DDL_Location.SelectedItem.Text.ToString();
			string day = DDL_Days.SelectedItem.Text.ToString();
			string timing = DDL_Timing.SelectedItem.Text.ToString();
			string limit = TB_SignUpLimit.Text.ToString();

			AdminCourseDAO adminDAO = new AdminCourseDAO();
			int insertRecord = adminDAO.InsertCourse(courseName,location,day,timing,limit);
			LabelMsg.Text = "Course created!";
		}

		protected void step2_yes_Click(object sender, EventArgs e)
		{

		}

		protected void step2_no_Click(object sender, EventArgs e)
		{

		}

	}
}
