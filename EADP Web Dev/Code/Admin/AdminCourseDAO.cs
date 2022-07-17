using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EADP_Web_Dev.Code.Admin
{
	public class AdminCourseDAO
	{
		// Place the DBConnect to class variable to be shared by all the methodsin this class
		string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

		public int InsertCourse(String courseName, string location, string day, string timing, string limit)
		{

			StringBuilder sqlStr = new StringBuilder();
			int result = 0;    // Execute NonQuery return an integer value
			SqlCommand sqlCmd = new SqlCommand();
			// Step1 : Create SQL insert command to add record to TDMaster using     

			//         parameterised query in values clause
			//
			sqlStr.AppendLine("INSERT INTO AdminCourse (courseName, location, day, timing, limit)");
			sqlStr.AppendLine("VALUES (@paraCourseName,@paraLocation, @paraDay, @paraTiming, @paraLimit)");
			


			// Step 2 :Instantiate SqlConnection instance and SqlCommand instance

			SqlConnection myConn = new SqlConnection(DBConnect);

			sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

			// Step 3 : Add each parameterised query variable with value
			//          complete to add all parameterised queries
			sqlCmd.Parameters.AddWithValue("@paraCourseName", courseName);
			sqlCmd.Parameters.AddWithValue("@paraLocation", location);
			sqlCmd.Parameters.AddWithValue("@paraDay", day);
			sqlCmd.Parameters.AddWithValue("@paraTiming", timing);
			sqlCmd.Parameters.AddWithValue("@paraLimit", limit);
			//sqlCmd.Parameters.AddWithValue("@paraCourseDetails", courseDetails);


			// Step 4 Open connection the execute NonQuery of sql command   

			myConn.Open();
			result = sqlCmd.ExecuteNonQuery();

			// Step 5 :Close connection
			myConn.Close();

			return result;

		}

	}
}