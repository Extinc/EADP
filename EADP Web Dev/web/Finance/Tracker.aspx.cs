using System;
using System.Data.SqlClient;
using EADP_Web_Dev.Code.Finance;

namespace EADP_Web_Dev.web.Finance
{
    public partial class Tracker : System.Web.UI.Page
    {
        private SqlConnection con;
        private SqlCommand com;
        private string DBConnect, query;

        //connection
        private void connection()
        {
            DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            con = new SqlConnection(DBConnect);
            con.Open();
        }

        //get total income Amt where email = email
        public void findIncomeAmt()
        {
            string email = Session["email"].ToString();
            DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            string selectSql = "select SUM(incomeAmt) as totalIncomeAmt From Income where email = '" + email + "'";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        incomeTotalLbl.Text = (read["totalIncomeAmt"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }


        //get total expense amount where email = email
        public void totalGet ()
        {
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
                        lblTotalE.Text = (read["totalExpAmt"].ToString());

                    }
                }
            }
            finally
            {
                con.Close();
            }

        }

        //get max limit
        public void getMax()
        {
            DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(DBConnect);
            string selectSql = "select Max(monthlyHouseLimit) as MaxLimit From SchemesAvailable";
            SqlCommand cmd = new SqlCommand(selectSql, con);
            try
            {
                con.Open();

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        maxLbl.Text = (read["MaxLimit"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        //calculate income - expense so to compare with max value from the scheme table in database
        public double calcDifference ()
        {
            string income;
            string expense;
            double resultIE = 0;
            double result = 0;
            income = incomeTotalLbl.Text.ToString();
            expense = lblTotalE.Text.ToString();
            if (lblTotalE.Text != null && incomeTotalLbl.Text != null)
            {             
                //calculating income - expense
                resultIE = Math.Round(Convert.ToDouble(income.ToString()) - Convert.ToDouble(expense.ToString()),2);
            }
            else if (lblTotalE.Text == null)
            {
                resultIE = Math.Round(Convert.ToDouble(income.ToString()));

            }
            else if (incomeTotalLbl.Text == null)
            {
                resultIE = Math.Round(0 - Convert.ToDouble(expense.ToString()),2);
            }
            else
            {
                resultIE = 0;
            }
            return resultIE;           
        }


        //page load content
        protected void Page_Load(object sender, EventArgs e)
        {
            getMax();
            totalGet();
            findIncomeAmt();
            string date = calendarForDate.SelectedDate.ToLongDateString();
            monthTextBox.Text = date.ToString();
            maxLbl.ForeColor = System.Drawing.Color.White;
            lblTotalE.ForeColor = System.Drawing.Color.White;
            incomeTotalLbl.ForeColor = System.Drawing.Color.White;

        }

        //expense button 
        protected void expenseAddBtn_Click(object sender, EventArgs e)
        {
            double max = Convert.ToDouble(maxLbl.Text.ToString());
         
                if (calcDifference() < max || calcDifference() == max)
                {
                    financialPanel.Visible = true;
                }
                else
                {
                    financialPanel.Visible = false;
                
            }

            //inserting data into database
            double budget = Convert.ToDouble(budgetTextBox.Text.ToString());
            double expAmt = Convert.ToDouble(expAmtTextBox.Text.ToString());
            string expenseItem = itemTextBox.Text.ToString();
            string date = monthTextBox.Text.ToString();
            string email = Session["email"].ToString();

            try
            {
                //if user did not select an option
                string category = expenseDropDownList.SelectedItem.ToString();

                //calling the class to insert record into database
                expenseDAO expDAO = new expenseDAO();
                int instRecord = expDAO.insertExpense(email, budget, expAmt, category, expenseItem, date);

                //if record is inserted else ...
                if(instRecord == 1)
                {
                    // clear entry so that new entry can be inputted by the user
                    expenseDropDownList.SelectedIndex = 0;
                    expAmtTextBox.Text = "";
                    itemTextBox.Text = "";

                   // Response.Write("You have successfully created a record!");
                }
                else
                {
                    Response.Write("Unable to insert expense record !");
                }
               
            }
            catch(FormatException)
            {
                Response.Write("Please fill in all necessary information!");
            }


           

            //alarm notification if budget less then total expense amount
            if (Convert.ToDouble(lblTotalE.Text) > budget)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('You have overspent your budget! Please reduce your spending! ')</script>");
            }
            else if (Convert.ToDouble(lblTotalE.Text) < budget)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('You have hit your budget! ')</script>");
            }
            
        }

        //income button for inserting record into data base
        protected void incomeAddBtn_Click(object sender, EventArgs e)
        {
            double max = Convert.ToDouble(maxLbl.Text.ToString());

            if (calcDifference() < max || calcDifference() == max)
            {
                financialPanel.Visible = true;
            }
            else
            {
                financialPanel.Visible = false;

            }


            try
            {
                double incomeAmt = Convert.ToDouble(incomeTextBox.Text.ToString());
                string date = monthTextBox.Text.ToString();
                string email = Session["email"].ToString();

                //if user did not select an option
                string incomeType;
                if (incomeDropDownList.SelectedIndex == 0)
                {
                    incomeType = otherIncomeTextBox.Text.ToString();
                }
                else
                {
                    incomeType = incomeDropDownList.SelectedItem.ToString();
                }
                   
                incomeDAO incDAO = new incomeDAO();
                int instIncomeRecord = incDAO.insertIncome(email,incomeAmt,date,incomeType);

                //if record is inserted else ...
                if (instIncomeRecord == 1)
                {
                    // clear entry so that new entry can be inputted by the user
                    incomeDropDownList.SelectedIndex = 0;
                    incomeTextBox.Text = "";

                  //  Response.Write("You have successfully created a record!");

                }
                else
                {
                    Response.Write("Unable to insert income record !");
                }
               
            }
            catch (FormatException)
            {
                Response.Write("Please fill in all necessary information!");
            }
        }   
    }
}