using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace EADP_Web_Dev.web.Finance
{
    public partial class incomeDetails : System.Web.UI.Page
    {
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\eadp_data.mdf; Integrated Security = True");
        protected void gvbind()
        {
            string email = Session["email"].ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Income where email = @email", conn);
            cmd.Parameters.Add("@email", email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string email = Session["email"].ToString();
                    cmd.CommandText = "SELECT incomeID, date,incomeAmt,incomeType FROM Income WHERE email = @email and (incomeID LIKE '%' + @incomeID +  '%' or date LIKE'%' + @date +  '%' or incomeAmt LIKE '%' + @incomeAmt +  '%' or incomeType LIKE '%' + @incomeType +  '%' )";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@incomeID", searchTextbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@date", searchTextbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@incomeAmt", searchTextbox.Text.Trim());
                    cmd.Parameters.AddWithValue("@incomeType", searchTextbox.Text.Trim());
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvbind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("income");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete FROM Income where incomeID='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int incomeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label income = (Label)row.FindControl("income");
            //TextBox txtname=(TextBox)gr.cell[].control[];  
            TextBox date = (TextBox)row.Cells[1].Controls[0];
            TextBox incomeType = (TextBox)row.Cells[2].Controls[0];
            TextBox incomeAmt = (TextBox)row.Cells[3].Controls[0];
            //TextBox textadd = (TextBox)row.FindControl("txtadd");  
            //TextBox textc = (TextBox)row.FindControl("txtc");  
            GridView1.EditIndex = -1;
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
            SqlCommand sqlCmd = new SqlCommand("Update Income set incomeType= @paraIncomeType,date=@paraDate,incomeAmt=@paraIncomeAmt where incomeID=@paraIncomeID", conn);
            sqlCmd.Parameters.AddWithValue("@paraIncomeID", incomeID);
            sqlCmd.Parameters.AddWithValue("@paraIncomeAmt", Convert.ToDouble(incomeAmt.Text.ToString()));
            sqlCmd.Parameters.AddWithValue("@paraDate", date.Text.ToString());
            sqlCmd.Parameters.AddWithValue("@paraIncomeType", incomeType.Text.ToString());
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
            //GridView1.DataBind();  
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }

        protected void GoBtn_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}