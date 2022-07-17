using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EADP_Web_Dev.Code.Finance;
using System.Text.RegularExpressions;
using System.Configuration;

namespace EADP_Web_Dev.web.Finance
{
    public partial class ExpenseDetails : System.Web.UI.Page
    {
        // for displaying total expense
        double totalexpense = 0;
        private SqlConnection con;
        private SqlCommand com;
        private string DBConnect, query;
        SqlDataAdapter adapt;
        DataTable dt;
        // Place the DBConnect to class variable to be shared by all the methodsin this class
        string DBConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\eadp_data.mdf; Integrated Security = True");
        protected void gvbind()
        {
            string email = Session["email"].ToString();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Expense where email = '"+email+"'", conn);
            //cmd.Parameters.Add("@email", email);
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


        private void connection()
        {
            DBConnect = System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            con = new SqlConnection(DBConnect);
            con.Open();
        }
 
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Expense" + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridView1.GridLines = GridLines.Both;
            GridView1.HeaderStyle.Font.Bold = true;
            GridView1.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string email = Session["email"].ToString();
                    cmd.CommandText = "SELECT expenseID, date,expAmt,category,expenseItem FROM Expense WHERE email = @email and (expenseID LIKE '%' + @expenseID +  '%' or date LIKE'%' + @date +  '%' or expAmt LIKE '%' + @expAmt +  '%' or category LIKE '%' + @category +  '%' or expenseItem LIKE '%' + @expenseItem +  '%')";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@expenseID", searchTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@date", searchTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@expAmt", searchTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@category", searchTextBox.Text.Trim());
                    cmd.Parameters.AddWithValue("@expenseItem", searchTextBox.Text.Trim());
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

        protected void Export(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    GridView1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());

                    //Download the HTML file.
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.htm");
                    Response.Charset = "";
                    Response.ContentType = "text/html";
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }

       

        //private void SearchRecord()
        //{
        //    string search = searchTextBox.Text.ToString();
        //    string Connstr = ConfigurationManager.ConnectionStrings["Connstr"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(Connstr))
        //    {
        //        string email = Session["email"].ToString();
        //        using (SqlCommand cmd = new SqlCommand())
        //        {


        //            string sql = "SELECT category, expAmt, expenseItem FROM Expense";
        //            if (!string.IsNullOrEmpty(searchTextBox.Text.Trim()))
        //            {
        //                sql += " WHERE email LIKE @paraEmail + '%'";
        //                cmd.Parameters.AddWithValue("@paraEmail", searchTextBox.Text.Trim());
        //            }
        //            cmd.CommandText = sql;
        //            cmd.Connection = con;
        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //                detailsGridView.DataSource = dt;
        //                detailsGridView.DataBind();
        //            }

        //        }
        //    }
        //}


        protected void Page_Load(object sender, EventArgs e)
        {

            expense expObj = new expense();
            expenseDAO expDAO = new expenseDAO();
            string email = Session["email"].ToString();
            Console.Write(email);

            if (expObj == null)
            {
                Lbl_err.Text = "No record maded!";
                PanelErrorResult.Visible = true;
                GridView1.Visible = false;
            }
            else
            {
                PanelErrorResult.Visible = false;

                ////call expense to get all td for expenses
                //expenseDAO eDAO = new expenseDAO();
                //List<expense> expList = new List<expense>();

                ////getting the email to find record
                //expList = eDAO.getTDbyEmail(email);
                //detailsGridView.DataSource = expList;
                //detailsGridView.DataBind();
            } 
                if (!IsPostBack)
                {
                    gvbind();
                }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("expense");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete FROM Expense where expenseID='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
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
            int expenseID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label expense = (Label)row.FindControl("expense");
            //TextBox txtname=(TextBox)gr.cell[].control[];  
            TextBox date = (TextBox)row.Cells[1].Controls[0]; 
            TextBox incomeAmt = (TextBox)row.Cells[2].Controls[0];
            TextBox category = (TextBox)row.Cells[3].Controls[0];
            TextBox expenseItem = (TextBox)row.Cells[4].Controls[0];
            //TextBox textadd = (TextBox)row.FindControl("txtadd");  
            //TextBox textc = (TextBox)row.FindControl("txtc");  
            GridView1.EditIndex = -1;
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
            SqlCommand sqlCmd = new SqlCommand("Update Expense set category= @paraCategory,expenseItem= @paraExpenseItem,date=@paraDate,expAmt=@paraExpAmt where expenseID=@paraExpenseID", conn);
            sqlCmd.Parameters.AddWithValue("@paraExpenseID", expenseID);
            sqlCmd.Parameters.AddWithValue("@paraExpAmt", Convert.ToDouble(incomeAmt.Text.ToString()));
            sqlCmd.Parameters.AddWithValue("@paraDate", date.Text.ToString());
            sqlCmd.Parameters.AddWithValue("@paraExpenseItem", expenseItem.Text.ToString());
            sqlCmd.Parameters.AddWithValue("@paraCategory", category.Text.ToString());
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
            //GridView1.DataBind();  
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
            this.BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }


        protected void exportDetails_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."
        }

        protected void detailsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        protected void exportHTML_Click(object sender, EventArgs e)
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    GridView1.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());

                    //Download the HTML file.
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.htm");
                    Response.Charset = "";
                    Response.ContentType = "text/html";
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalexpense += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "expAmt"));
                e.Row.Cells[0].Text = Regex.Replace(e.Row.Cells[0].Text, searchTextBox.Text.Trim(), delegate (Match match)
                {
                    return string.Format("<span style = 'background-color:#FFFF00'>{0}</span>", match.Value);
                }, RegexOptions.IgnoreCase);
              
            
            }
            // Display totals in the gridview footer
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "Grand Total";
                e.Row.Cells[0].Font.Bold = true;

                e.Row.Cells[1].Text = "$" + totalexpense.ToString("c");
                e.Row.Cells[1].Font.Bold = true;
            }

        }

        //protected void searchTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    string identifier = Session["email"].ToString();
        //    connection();
        //    adapt = new SqlDataAdapter("select * from Expense where Category like '" + searchTextBox.Text + "%' and email = 'identifier'", con);
        //    dt = new DataTable();
        //    adapt.Fill(dt);
        //    detailsGridView.DataSourceID = dt.ToString();
        //    detailsGridView.DataBind();
           
        //    con.Close();
        //}

        protected void OnPaging(object sender, GridViewPageEventArgs e)
            {
                GridView1.PageIndex = e.NewPageIndex;
                //this.SearchRecord();
            }

        }
    }

     


