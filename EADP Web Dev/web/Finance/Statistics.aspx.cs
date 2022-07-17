using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace EADP_Web_Dev.web.Finance
{
    public partial class Statistics : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //string email = Session["email"].ToString();
            findTotalExp();
            findCount();
        }

        public void findTotalExp()
        {
            string DBConnect;
            string email = Session["email"].ToString();
            DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            string selectSql = "select SUM(expAmt) as totalExpAmt From Expense where email = '" + email + "'";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        LblTotalExpenses.Text = "$" + (read["totalExpAmt"].ToString());

                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        public void findCount()
        {
            string DBConnect;
            string email = Session["email"].ToString();
            DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            string selectSql = "select Count(expenseID) as total From Expense where email = '" + email + "'";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        LblNumber.Text = (read["total"].ToString());

                    }
                }
            }
            finally
            {
                con.Close();
            }
        }


        [WebMethod]
        public static List<expense> GetChartData()
        {
            string email = System.Web.HttpContext.Current.Session["email"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\eadp_data.mdf; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT expenseItem as Name, SUM(expAmt) AS totalExpAmt  FROM Expense where email = @email GROUP BY expenseItem ", con);
                cmd.Parameters.Add("@email", email);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            List<expense> dataList = new List<expense>();
            foreach (DataRow dtrow in dt.Rows)
            {
                expense details = new expense();
                details.expenseItem = dtrow[0].ToString();
                details.totalExpAmt = Convert.ToInt32(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }


        public class expense
        {
            public double budget { get; set; }
            public string email { get; set; }
            public double totalExpAmt { get; set; }
            public string category { get; set; }
            public string expenseItem { get; set; }
            public string date { get; set; }
        }

        protected void incomeStatBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("incomeStatistics.aspx");
        }
    }
}
    
