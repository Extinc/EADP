using System.Data.SqlClient;
using System.Text;

namespace EADP_Web_Dev.Code.Finance
{
    public class incomeDAO
    {
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public int insertIncome(string email, double incomeAmt, string date, string incomeType)
        {
            StringBuilder sqlStr = new StringBuilder();

            // Execute NonQuery return an integer value
            int result = 0;

            SqlCommand sqlCmd = new SqlCommand();

            // Step1 : Create SQL insert command to add record to TDMaster using     

            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO Income (email,incomeAmt,date,incomeType)");
            sqlStr.AppendLine("VALUES (@paraEmail,@paraIncomeAmt,@paraDate,@paraIncomeType)");


            // Step 2 :Instantiate SqlConnection instance and SqlCommand instance

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Step 3 : Add each parameterised query variable with value
            //          complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraIncomeAmt", incomeAmt);
            sqlCmd.Parameters.AddWithValue("@paraDate", date);
            sqlCmd.Parameters.AddWithValue("@paraIncomeType", incomeType);

            // Step 4 Open connection the execute NonQuery of sql command   

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
    }
}