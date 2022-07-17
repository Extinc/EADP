using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EADP_Web_Dev.Code.Admin
{
	public class CourseDAO
	{
		// Place the DBConnect to class variable to be shared by all the methodsin this class
		string DBConnect1 = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

		public int InsertCourse(String courseName, string courseDes)
		{

			StringBuilder sqlStr = new StringBuilder();
			int result = 0;    // Execute NonQuery return an integer value
			SqlCommand sqlCmd = new SqlCommand();
			// Step1 : Create SQL insert command to add record to TDMaster using     

			//         parameterised query in values clause
			//
			sqlStr.AppendLine("INSERT INTO CourseMain (courseName, courseDes)");
			sqlStr.AppendLine("VALUES (@paraCourseName, @paraCourseDes)");



			// Step 2 :Instantiate SqlConnection instance and SqlCommand instance

			SqlConnection myConn = new SqlConnection(DBConnect1);

			sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

			// Step 3 : Add each parameterised query variable with value
			//          complete to add all parameterised queries
			sqlCmd.Parameters.AddWithValue("@paraCourseName", courseName);
			sqlCmd.Parameters.AddWithValue("@paraCourseDes", courseDes);



			// Step 4 Open connection the execute NonQuery of sql command   

			myConn.Open();
			result = sqlCmd.ExecuteNonQuery();

			// Step 5 :Close connection
			myConn.Close();

			return result;
		}
			public List<Course> findAll()
		{
			List<Course> result = new List<Course>();
			result.Add(new Course { Id = "C01", Name = "Course 1", Price = 100, Photo = "dance.gif" });
			return result;
		}

		// Place the DBConnect to class variable to be shared by all the methodsin this class
		string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

		public int InsertSignUp(String name, string course, string date, string location, string time)
		{

			StringBuilder sqlStr = new StringBuilder();
			int result = 0;    // Execute NonQuery return an integer value
			SqlCommand sqlCmd = new SqlCommand();
			// Step1 : Create SQL insert command to add record to TDMaster using     

			//         parameterised query in values clause
			//
			sqlStr.AppendLine("INSERT INTO CourseSignUp (name, course, date, location, time)");
			sqlStr.AppendLine("VALUES (@paraName, @paraCourse, @paraDate, @paraLocation, @paraTime)");



			// Step 2 :Instantiate SqlConnection instance and SqlCommand instance

			SqlConnection myConn = new SqlConnection(DBConnect);

			sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

			// Step 3 : Add each parameterised query variable with value
			//          complete to add all parameterised queries
			sqlCmd.Parameters.AddWithValue("@paraName", name);
			sqlCmd.Parameters.AddWithValue("@paraCourse", course);
			sqlCmd.Parameters.AddWithValue("@paraDate", date);
			sqlCmd.Parameters.AddWithValue("@paraLocation", location);
			sqlCmd.Parameters.AddWithValue("@paraTime", time);



			// Step 4 Open connection the execute NonQuery of sql command   

			myConn.Open();
			result = sqlCmd.ExecuteNonQuery();

			// Step 5 :Close connection
			myConn.Close();

			return result;
		}
	}
}