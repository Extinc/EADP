using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EADP_Web_Dev.web.Finance.ADMIN
{
    public partial class Approval : System.Web.UI.Page
    {
        //Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Displaying the Data  
                showData();
                //Adding an Attribute to Server Control(i.e. btnDeleteRecord)  
                btnUpdateRecord.Attributes.Add("onclick", "javascript:return UpdateConfirm()");
            }
        }

        //Method for Displaying Data  
        protected void showData()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(DBConnect);
            SqlDataAdapter adapt = new SqlDataAdapter("select financialSchemeID,applicantName,schemeName,totalGross,perCapitalIncome,status From FinancialScheme where status LIKE '%Pending%'", con);
            con.Open();
            adapt.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //Method for approving Record  
        protected void approveRecord(int financialSchemeID)
        {
            SqlConnection con = new SqlConnection(DBConnect);
            SqlCommand com = new SqlCommand("Update FinancialScheme set status = 'Approved'", con);
            com.Parameters.AddWithValue("@financialSchemeID", financialSchemeID);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        protected void btnUpdateRecord_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow grow in GridView1.Rows)
            {
                //Searching CheckBox("chkDel") in an individual row of Grid  
                CheckBox chkdel = (CheckBox)grow.FindControl("chkDel");
                //If CheckBox is checked than delete the record with particular empid  
                if (chkdel.Checked)
                {
                    int financialSchemeID = Convert.ToInt32(grow.Cells[1].Text);
                    approveRecord(financialSchemeID);
                }
            }
            //Displaying the Data in GridView  
            showData();
        }
    }


}