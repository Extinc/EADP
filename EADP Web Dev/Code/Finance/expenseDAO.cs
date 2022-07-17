using System.Data.SqlClient;
using System.Text;

namespace EADP_Web_Dev.Code.Finance
{
    public class expenseDAO
    {
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public int insertExpense(string email, double budget, double expAmt, string category, string expenseItem, string date)
        {
            StringBuilder sqlStr = new StringBuilder();

            // Execute NonQuery return an integer value
            int result = 0;

            SqlCommand sqlCmd = new SqlCommand();

            //Create SQL insert command to add record to expense using     
            //         parameterised query in values clause
            //
            sqlStr.AppendLine("INSERT INTO Expense (email, budget, expAmt, category, expenseItem, date)");
            sqlStr.AppendLine("VALUES (@paraEmail,@paraBudget,@paraExpAmt, @paraCategory, @paraExpenseItem,@paraDate)");
            //instantiate SqlConnection instance and SqlCommand instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            // Add each parameterised query variable with value
            //  complete to add all parameterised queries
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraBudget", budget);
            sqlCmd.Parameters.AddWithValue("@paraExpAmt", expAmt);
            sqlCmd.Parameters.AddWithValue("@paraCategory", category);
            sqlCmd.Parameters.AddWithValue("@paraExpenseItem", expenseItem);
            sqlCmd.Parameters.AddWithValue("@paraDate", date);


            //Open connection the execute NonQuery of sql command   
            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            //Close connection
            myConn.Close();
            return result;
        }

        ////construct getTDbyEmail with email as input argument
        //public List<expense> getTDbyEmail(string email)
        //{
        //    //declare a list to hold collection of expense of the particulaar user
        //    // DataSet instance and dataTable instance 

        //    List<expense> exList = new List<expense>();
        //    DataSet ds = new DataSet();
        //    DataTable tdData = new DataTable();

        //    // Create SQLcommand to select all columns from Expense Databas by parameterised email


        //    StringBuilder sqlStr = new StringBuilder();
        //    sqlStr.AppendLine("SELECT category, expAmt, expenseItem FROM Expense WHERE email LIKE @paraEmail + '%'");

        //    //Instantiate SqlConnection instance and SqlDataAdapter instance

        //    SqlConnection myConn = new SqlConnection(DBConnect);
        //    SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

        //    //add value to parameter 

        //    da.SelectCommand.Parameters.AddWithValue("paraEmail", email);

        //    //fill dataset
        //    da.Fill(ds, "TableTD");

        //    //Iterate the rows from TableTD above to create a collection of TD
        //    //for this particular expense entry

        //    int rec_cnt = ds.Tables["TableTD"].Rows.Count;
        //    if (rec_cnt > 0)
        //    {
        //        foreach (DataRow row in ds.Tables["TableTD"].Rows)
        //        {
        //            expense myTD = new expense();

        //            //Set attribute of expense instance for each row of record in TableTD

        //            myTD.category = row["category"].ToString();
        //            myTD.expAmt = Convert.ToDouble(row["expAmt"]);
        //            myTD.expenseItem = row["expenseItem"].ToString();

        //            //Add each expense instance to array list
        //            exList.Add(myTD);
        //        }
        //    }
        //    else
        //    {
        //        exList = null;
        //    }

        //    return exList;
        //}
    }
}