using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using EADP_Web_Dev.Code.Admin;

namespace EADP_Web_Dev.web.AdminEvent
{
	public partial class CourseMain : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string[] filePaths = Directory.GetFiles(Server.MapPath("~/Image/"));
				List<ListItem> files = new List<ListItem>();
				foreach (string filePath in filePaths)
				{
					string fileName = Path.GetFileName(filePath);
					files.Add(new ListItem(fileName, "~/Image/" + fileName));
				}
				GridView2.DataSource = files;
				GridView2.DataBind();
			}
		}
		protected void Upload(object sender, EventArgs e)
		{
			if (FileUpload1.HasFile)
			{
				string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
				FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Image/") + fileName);
				Response.Redirect(Request.Url.AbsoluteUri);
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
			string courseName = tbName.Text.ToString();
			string courseDes = tbDes.Text.ToString();

			CourseDAO coursedao = new CourseDAO();
			int insertRecord = coursedao.InsertCourse(courseName, courseDes);
		
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Redirect("SignUpCourse.aspx");
		}
	}
	}
