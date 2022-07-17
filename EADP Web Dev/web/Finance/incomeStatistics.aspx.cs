using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace EADP_Web_Dev.web.Finance
{
    public partial class incomeStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            findTotalIncome();
            findCount();
        }
        public void findTotalIncome()
        {
            string DBConnect;
            string email = Session["email"].ToString();
            DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            string selectSql = "select SUM(incomeAmt) as totalIncome From Income where email = '" + email + "'";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        LblTotalIncome.Text = "$" + (read["totalIncome"].ToString());

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
            string selectSql = "select Count(incomeID) as total From Income where email = '" + email + "'";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        LblNumber.Text =(read["total"].ToString());

                    }
                }
            }
            finally
            {
                con.Close();
            }
        }



        [WebMethod]
        public static List<income> GetChartData()
        {
           string email = System.Web.HttpContext.Current.Session["email"].ToString();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\eadp_data.mdf; Integrated Security = True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT incomeType as Name, SUM(incomeAmt) AS totalIncomeAmt  FROM Income where email=@email GROUP BY incomeType ", con);
                cmd.Parameters.Add("@email", email);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }

            List<income> dataList = new List<income>();
            foreach (DataRow dtrow in dt.Rows)
            {
                income details = new income();
                details.incomeType = dtrow[0].ToString();
                details.totalIncomeAmt = Convert.ToInt32(dtrow[1]);
                dataList.Add(details);
            }
            return dataList;
        }

        public class income
        {
            public string email { get; set; }
            public double totalIncomeAmt { get; set; }
            public string date { get; set; }
            public string incomeType { get; set; }
        }

        protected void expenseStatBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Statistics.aspx");
        }
    }

}

