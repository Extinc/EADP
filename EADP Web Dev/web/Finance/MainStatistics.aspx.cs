using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace EADP_Web_Dev.web.Finance
{
    public partial class MainStatistics : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [WebMethod]
        public static List<object> GetOverviewChartData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string email = System.Web.HttpContext.Current.Session["email"].ToString();
            string query = "SELECT date, SUM(expAmt) AS totalExpense";
            query += " FROM Expense WHERE email = @email GROUP BY date";
            
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
            {
            "date", "totalExpense"
            });
            using (SqlConnection con = new SqlConnection(constr))
            {
                
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add("@email", email);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                        {
                        sdr["date"], sdr["totalExpense"]
                        });
                        }
                    }
                    con.Close();
                    return chartData;
                }
            }
        }

        [WebMethod]
        public static List<object> GetIncomeOverviewChartData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string email = System.Web.HttpContext.Current.Session["email"].ToString();
            string query = "SELECT date, SUM(incomeAmt) AS totalIncome";
            query += " FROM Income WHERE email = @email GROUP BY date";

            List<object> chartData = new List<object>();
            chartData.Add(new object[]
            {
            "date", "totalIncome"
            });
            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.Add("@email", email);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                        {
                        sdr["date"], sdr["totalIncome"]
                        });
                        }
                    }
                    con.Close();
                    return chartData;
                }
            }
        }

        [WebMethod]
        public static List<expense> GetColumnChartData()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ToString()))
            {
                string email = System.Web.HttpContext.Current.Session["email"].ToString();
                SqlCommand cmd = new SqlCommand("SELECT category as Name, SUM(expAmt) AS totalExpAmt  FROM Expense where email = @email GROUP BY category", con);
                cmd.Parameters.Add("@email", email);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<expense> dataList = new List<expense>();

                foreach (DataRow dtrow in dt.Rows)
                {
                    expense details = new expense();
                    details.category = dtrow[0].ToString();
                    details.expAmt = Convert.ToInt32(dtrow[1]);

                    dataList.Add(details);
                }
                return dataList;
            }
        }

        public class expense
        {
            public double budget { get; set; }
            public string email { get; set; }
            public double expAmt { get; set; }
            public string category { get; set; }
            public string expenseItem { get; set; }
            public string date { get; set; }
        }

        protected void statIncomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("incomeStatistics.aspx");
        }

        protected void expenseStatBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Statistics.aspx");
        }
    }
}