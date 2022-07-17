using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace EADP_Web_Dev.Code.Admin
{
	public class BookingDAO
	{
		// Place the DBConnect to class variable to be shared by all the methodsin this class
		string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

		public int InsertBooking(String name, string contact, string date, string time, string facility, string location, double price, string email, string status)
		{

			StringBuilder sqlStr = new StringBuilder();
			int result = 0;    // Execute NonQuery return an integer value
			SqlCommand sqlCmd = new SqlCommand();
			// Step1 : Create SQL insert command to add record to TDMaster using     

			//         parameterised query in values clause
			//
			sqlStr.AppendLine("INSERT INTO Booking (name, contact, date, time, facility, location, price, email, status)");
			sqlStr.AppendLine("VALUES (@paraName,@paraContact, @paraDate, @paraTime, @paraFacility, @paraLocation, @paraPrice, @paraEmail, @paraStatus)");



			// Step 2 :Instantiate SqlConnection instance and SqlCommand instance

			SqlConnection myConn = new SqlConnection(DBConnect);

			sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

			// Step 3 : Add each parameterised query variable with value
			//          complete to add all parameterised queries
			sqlCmd.Parameters.AddWithValue("@paraName", name);
			sqlCmd.Parameters.AddWithValue("@paraContact", contact);
			sqlCmd.Parameters.AddWithValue("@paraDate", date);
			sqlCmd.Parameters.AddWithValue("@paraTime", time);
			sqlCmd.Parameters.AddWithValue("@paraFacility", facility);
			sqlCmd.Parameters.AddWithValue("@paraLocation", location);
			sqlCmd.Parameters.AddWithValue("@paraPrice", price);
			sqlCmd.Parameters.AddWithValue("@paraEmail", email);
			sqlCmd.Parameters.AddWithValue("@paraStatus", status);


			// Step 4 Open connection the execute NonQuery of sql command   

			myConn.Open();
			result = sqlCmd.ExecuteNonQuery();

			// Step 5 :Close connection
			myConn.Close();

			return result;

		}

		public int UpdateBooking(String name, string contact, string date, string time, string facility, string location, double price, string email, string status)
		{

			StringBuilder sqlStr = new StringBuilder();
			int result = 0;    // Execute NonQuery return an integer value
			SqlCommand sqlCmd = new SqlCommand();
			// Step1 : Create SQL insert command to add record to TDMaster using     

			//         parameterised query in values clause
			//
			sqlStr.AppendLine("UPDATE Booking (name, contact, date, time, facility, location, price, email, status)");
			sqlStr.AppendLine("VALUES (@paraName,@paraContact, @paraDate, @paraTime, @paraFacility, @paraLocation, @paraPrice, @paraEmail, @paraStatus)");



			// Step 2 :Instantiate SqlConnection instance and SqlCommand instance

			SqlConnection myConn = new SqlConnection(DBConnect);

			sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

			// Step 3 : Add each parameterised query variable with value
			//          complete to add all parameterised queries
			sqlCmd.Parameters.AddWithValue("@paraName", name);
			sqlCmd.Parameters.AddWithValue("@paraContact", contact);
			sqlCmd.Parameters.AddWithValue("@paraDate", date);
			sqlCmd.Parameters.AddWithValue("@paraTime", time);
			sqlCmd.Parameters.AddWithValue("@paraFacility", facility);
			sqlCmd.Parameters.AddWithValue("@paraLocation", location);
			sqlCmd.Parameters.AddWithValue("@paraPrice", price);
			sqlCmd.Parameters.AddWithValue("@paraEmail", email);
			sqlCmd.Parameters.AddWithValue("@paraStatus", status);


			// Step 4 Open connection the execute NonQuery of sql command   

			myConn.Open();
			result = sqlCmd.ExecuteNonQuery();

			// Step 5 :Close connection
			myConn.Close();

			return result;

		}

	}
}