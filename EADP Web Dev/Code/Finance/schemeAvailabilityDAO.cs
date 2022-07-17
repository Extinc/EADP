using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EADP_Web_Dev.Code.Finance
{
    public class schemeAvailabilityDAO
    {
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public int insertAvailableScheme(string schemeName, double monthlyHouseLimit, string schemeDetails, string schemeType)
        {
            StringBuilder sqlStr = new StringBuilder();

            // Execute NonQuery return an integer value
            int result = 0;

            SqlCommand sqlCmd = new SqlCommand();

            //Create SQL insert command to add record to expense using     
            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO SchemesAvailable (schemeName, monthlyHouseLimit, schemeDetails, schemeType)");
            sqlStr.AppendLine("VALUES (@paraSchemeName,@paraMonthlyHouseLimit,@paraSchemeDetails, @paraSchemeType)");
            //instantiate SqlConnection instance and SqlCommand instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Add each parameterised query variable with value
            //  complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraSchemeName", schemeName);
            sqlCmd.Parameters.AddWithValue("@paraMonthlyHouseLimit", monthlyHouseLimit );
            sqlCmd.Parameters.AddWithValue("@paraSchemeDetails", schemeDetails );
            sqlCmd.Parameters.AddWithValue("@paraSchemeType", schemeType);

            //Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            //Close connection
            myConn.Close();
            return result;
        }


        public schemeAvailability getSchemeCreated()
        {
            SqlDataAdapter dat;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from SchemesAvailable order by schemeId Desc");

            schemeAvailability obj = new schemeAvailability();   // create a schemeAvailability instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            dat = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            // fill dataset
            dat.Fill(ds, "avalTable");
            int rec_cnt = ds.Tables["avalTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["avalTable"].Rows[0];  // Sql command returns only one record
                obj.schemeType = row["schemeType"].ToString();
                obj.schemeName = row["schemeName"].ToString();
                obj.monthlyHouseLimit = Convert.ToDouble(row["monthlyHouseLimit"].ToString());
                obj.schemeDetails = row["schemeDetails"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }
    }
}