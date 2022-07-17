using System;
using EADP_Web_Dev.Code.Admin;

namespace EADP_Web_Dev.web.AdminEvent
{
	public partial class SignUpCourse : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void BtnSubmit_Click(object sender, EventArgs e)
		{
			string name = TB_Name.Text.ToString();
			string course = DDL_Course.SelectedItem.ToString();
			string date = DDL_Date.SelectedItem.ToString();
			string location = DDL_Location.SelectedItem.ToString();
			string time = DDL_Time.SelectedItem.ToString();

			CourseDAO courses = new CourseDAO();
			int insertRecord = courses.InsertSignUp(name, course, date, location, time);

			lblMsg.Text = "Successfully signed up!";
		}

		protected void DDL_Facility_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void DDL_Date_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void DDL_Time_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		protected void DDL_Course_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}