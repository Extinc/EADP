using System.Data.SqlClient;
using System.Text;

namespace EADP_Web_Dev.Code.Finance
{
    public class financialSchemeDAO
    {
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public int insertScheme(string email, string financialType, string schemeName, string applicantName, string address, string contactNo, string familyMemFirst, string familyMemSecond, string familyMemThird, string occupuationFirst, string occupationSecond, string occupationThird, double totalGross, double perCapitalIncome, string status)
        {
            StringBuilder sqlStr = new StringBuilder();

            // Execute NonQuery return an integer value
            int result = 0;

            SqlCommand sqlCmd = new SqlCommand();

            //Create SQL insert command to add record to expense using     
            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO FinancialScheme (email,financialType,schemeName,applicantName,address,contactNo,familyMemFirst,familyMemSecond,familyMemThird,occupationFirst,occupationSecond,occupationThird,totalGross,perCapitalIncome,status)");
            sqlStr.AppendLine("VALUES (@paraEmail,@paraFinancialType,@paraSchemeName,@paraApplicantName,@paraAddress,@paraContactNo,@paraFamilyMemFirst,@paraFamilyMemSecond,@paraFamilyMemThird,@paraOccupationFirst,@paraOccupationSecond,@paraOccupationThird,@paraTotalGross,@paraPerCapitalIncome,@paraStatus)");
            //instantiate SqlConnection instance and SqlCommand instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Add each parameterised query variable with value
            //  complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraFinancialType", financialType);
            sqlCmd.Parameters.AddWithValue("@paraSchemeName", schemeName);
            sqlCmd.Parameters.AddWithValue("@paraApplicantName", applicantName);
            sqlCmd.Parameters.AddWithValue("@paraAddress", address);
            sqlCmd.Parameters.AddWithValue("@paraContactNo", contactNo);
            sqlCmd.Parameters.AddWithValue("@paraFamilyMemFirst", familyMemFirst);
            sqlCmd.Parameters.AddWithValue("@paraFamilyMemSecond", familyMemSecond);
            sqlCmd.Parameters.AddWithValue("@paraFamilyMemThird", familyMemThird);
            sqlCmd.Parameters.AddWithValue("@paraOccupationFirst", occupuationFirst);
            sqlCmd.Parameters.AddWithValue("@paraOccupationSecond", occupationSecond);
            sqlCmd.Parameters.AddWithValue("@paraOccupationThird", occupationThird);
            sqlCmd.Parameters.AddWithValue("@paraTotalGross", totalGross);
            sqlCmd.Parameters.AddWithValue("@paraPerCapitalIncome", perCapitalIncome);
            sqlCmd.Parameters.AddWithValue("@paraStatus", status);



            //Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            //Close connection
            myConn.Close();
            return result;

        }
    }
}