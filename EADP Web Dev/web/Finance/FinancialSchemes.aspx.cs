using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using EADP_Web_Dev.Code.Finance;

namespace EADP_Web_Dev.web.Finance
{
    public partial class FinancialSchemes : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            //binding of scheme name and scheme type from schemesAvailable table
            if(!this.IsPostBack)
            {
                string connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT schemeType FROM SchemesAvailable"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        typeDdList.DataSource = cmd.ExecuteReader();
                        typeDdList.DataTextField = "schemeType";
                        typeDdList.DataValueField = "schemeType";
                        typeDdList.DataBind();
                        con.Close();
                    }
                }
                typeDdList.Items.Insert(0, new ListItem("--Select Type--", "0"));

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT schemeName FROM SchemesAvailable"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        schemeDdList.DataSource = cmd.ExecuteReader();
                        schemeDdList.DataTextField = "schemeName";
                        schemeDdList.DataValueField = "schemeName";
                        schemeDdList.DataBind();
                        con.Close();
                    }
                }
                schemeDdList.Items.Insert(0, new ListItem("--Select Scheme--", "0"));

            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Session["email"].ToString();
                string financialType = typeDdList.SelectedItem.ToString();
                string schemeName = schemeDdList.SelectedItem.ToString();
                string applicantName = applicantNameTextbox.Text.ToString();
                string address = addressTextbox.Text.ToString();
                string contactNo = contactNoTextBox.Text.ToString();
                string familyMemFirst = member1Textbox.Text.ToString();
                string familyMemSecond = member2TextBox.Text.ToString();
                string familyMemThird = member3TextBox.Text.ToString();
                string occupationFirst = occupation1TextBox.Text.ToString();
                string occupationSecond = occupation2TextBox.Text.ToString();
                string occupationThird = occupation3TextBox.Text.ToString();
                double totalGross = Convert.ToDouble(totalIncomeLbl.Text.ToString());
                double perCapitalIncome = Convert.ToDouble(perCapitaLbl.Text.ToString());
                string status = "Pending";

                //calling the class to insert record into database
                financialSchemeDAO avaiDAO = new financialSchemeDAO();
                int inst = avaiDAO.insertScheme(email, financialType, schemeName, applicantName, address, contactNo, familyMemFirst, familyMemSecond, familyMemThird, occupationFirst, occupationSecond, occupationThird, totalGross, perCapitalIncome,status);

                //if record is inserted else ...
                if (inst == 1)
                {
                    financialScheme Obj = new financialScheme();
                    financialSchemeDAO DAO = new financialSchemeDAO();
                    typeDdList.SelectedIndex = 0;
                    schemeDdList.SelectedIndex = 0;
                    applicantNameTextbox.Text = "";
                    addressTextbox.Text = "";
                    contactNoTextBox.Text = "";
                    member1Textbox.Text = "";
                    member2TextBox.Text = "";
                    member3TextBox.Text = "";
                    occupation1TextBox.Text = "";
                    occupation2TextBox.Text = "";
                    occupation3TextBox.Text = "";
                    relation1TextBox.Text = "";
                    relation2TextBox.Text = "";
                    relation3TextBox.Text = "";
                    totalIncomeLbl.Text = "";
                    perCapitaLbl.Text = "";
                   
                    // clear entry so that new entry can be inputted by the user
                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Thank you for your submission!Please wait for further notice.');</script>");

                }
                else
                {
                    Response.Write("Unable to insert expense record !");
                }

            }
            catch (FormatException)
            {
                Response.Write("Please fill in all necessary information!");
            }

           
        }

        protected void income1TextBox_TextChanged(object sender, EventArgs e)
        {
            if (income1TextBox.Text != null)
            {
                double monthlyIncome = 0;
                monthlyIncome = Convert.ToDouble(income1TextBox.Text);
                totalIncomeLbl.Text = "$" + monthlyIncome.ToString();
                perCapitaLbl.Text = "$" + monthlyIncome.ToString();

            }
        }

        protected void income2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (income1TextBox.Text != null && income2TextBox.Text !=null)
            {
                double perCapita = 0;
                double monthlyIncome = 0;
                monthlyIncome = Math.Round(Convert.ToDouble(income1TextBox.Text) + Convert.ToDouble(income2TextBox.Text),2);
                totalIncomeLbl.Text = "$" + monthlyIncome.ToString();
                perCapita = Math.Round(monthlyIncome/2, 2);
                perCapitaLbl.Text = "$" + perCapita.ToString();
            }
        }

        protected void income3TextBox_TextChanged(object sender, EventArgs e)
        {
            if (income1TextBox.Text != null && income2TextBox.Text != null && income3TextBox.Text !=null)
            {
                double perCapita = 0;
                double monthlyIncome = 0;
                monthlyIncome = Math.Round(Convert.ToDouble(income1TextBox.Text) + Convert.ToDouble(income2TextBox.Text) + Convert.ToDouble(income3TextBox.Text), 2);
                totalIncomeLbl.Text = "$" + monthlyIncome.ToString();
                perCapita = Math.Round(monthlyIncome / 3, 2);
                perCapitaLbl.Text = "$" + perCapita.ToString();

            }
        }
    }
}