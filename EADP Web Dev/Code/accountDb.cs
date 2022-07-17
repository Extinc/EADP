using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace EADP_Web_Dev.Code
{
    public class AccountDb
    {
        public void Register(AccountEntity acc)
        {
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder Command = new StringBuilder();
            Command.Append(
                "INSERT INTO dbo.Account(fname,lname,email, nric,dob,hpNo,address,gender,famNo,password,roleid,online)");
            Command.Append(
                "VALUES(@paramfName, @paramlName, @paramemail,'', @paramdob, @paramMobile,'','','',@paramPW,1,0)");
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                using (SqlCommand ceeAdapter = new SqlCommand(Command.ToString(), con))
                {
                    ceeAdapter.Parameters.AddWithValue("@paramfName", acc.FirstName);
                    ceeAdapter.Parameters.AddWithValue("@paramlName", acc.LastName);
                    ceeAdapter.Parameters.AddWithValue("@paramemail", acc.Email);
                    ceeAdapter.Parameters.AddWithValue("@paramdob", acc.Dob);
                    ceeAdapter.Parameters.AddWithValue("@paramMobile", acc.Phone);
                    ceeAdapter.Parameters.AddWithValue("@paramPW", acc.Password);
                    /*            ceeAdapter.Parameters.AddWithValue("@paramsalt", acc.Salt);*/
                    ceeAdapter.ExecuteNonQuery();
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public Boolean CheckEmailExist(string email)
        {
            int numberofRec = 0;
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string Command = "SELECT count(email) FROM dbo.Account WHERE email = @ParamEmail";
            /*           for (int i = 0; i < 50; i++)
           
                       {*/
            using (SqlConnection con = new SqlConnection(strConString))
            {
                using (SqlCommand ceeAdapter = new SqlCommand(Command, con))
                {
                    con.Open();
                    ceeAdapter.Parameters.AddWithValue("@ParamEmail", email);
                    numberofRec = (int) ceeAdapter.ExecuteScalar();
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            //       Debug.WriteLine("COns : " + i);
            //       }

            return numberofRec > 0;
        }

/*
        internal byte[] GenerateSalt()
        {
            int saltLength = 32;
            byte[] salt = new byte[saltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }
*/

        public bool VerifyPw(string email, string input)
        {
            string dbpw = "";
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string Command = "SELECT password FROM dbo.Account WHERE email = @ParamEmail";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                using (SqlCommand selPwcmd = new SqlCommand(Command, con))
                {
                    selPwcmd.Parameters.AddWithValue("@ParamEmail", email);
                    con.Open();
                    selPwcmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(selPwcmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        dbpw = myRow["password"].ToString();
                    }
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            if (input == dbpw)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

/*        public byte[] RetrieveSalt(string email)
        {
            byte[] salt = new byte[32];

            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(strConString);
            string Command = "SELECT salt FROM dbo.AccountEntity WHERE email = @ParamEmail";
            SqlCommand selSaltCMD = new SqlCommand(Command, con);
            selSaltCMD.Parameters.AddWithValue("@ParamEmail", email);
            con.Open();
            selSaltCMD.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(selSaltCMD);
            DataTable myDataSet = new DataTable();
            adapter.Fill(myDataSet);
            foreach (DataRow myRow in myDataSet.Rows)
            {
                salt = (byte[]) myRow["salt"];
            }


            con.Close();
            return salt;
        }*/

        public AccountEntity GetAccountData(string email)
        {
            AccountEntity acc = new AccountEntity();
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string Command = "SELECT id, roleid FROM dbo.Account WHERE email = @ParamEmail";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                using (SqlCommand selPwcmd = new SqlCommand(Command, con))
                {
                    selPwcmd.Parameters.AddWithValue("@ParamEmail", email);
                    con.Open();
                    selPwcmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(selPwcmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        acc.Roleid = (int) myRow["roleid"];
                        acc.Userid = (int) myRow["id"];
                    }
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            acc.Email = email;
            return acc;
        }

        public void UpdatePassword(AccountEntity acc)
        {
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder command = new StringBuilder();
            command.Append(
                "UPDATE dbo.Account SET password = @paramPW ");
            command.Append(
                "WHERE email = @paramemail");

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                using (SqlCommand ceeAdapter = new SqlCommand(command.ToString(), con))
                {
                    ceeAdapter.Parameters.AddWithValue("@paramPW", acc.Password);
                    ceeAdapter.Parameters.AddWithValue("@paramemail", acc.Email);
                    /*            ceeAdapter.Parameters.AddWithValue("@paramsalt", acc.Salt);*/
                    ceeAdapter.ExecuteNonQuery();
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void UpdateInterest(AccountEntity acc)
        {
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder Command = new StringBuilder();
            Command.Append(
                "INSERT INTO dbo.Interest(UserID, Interest)");
            Command.Append(
                "VALUES(@UserID, @Interest)");
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                using (SqlCommand ceeAdapter = new SqlCommand(Command.ToString(), con))
                {
                    List<string> interestList = acc.Interest;
                    ceeAdapter.Parameters.AddWithValue("@UserID", acc.Userid);
                    SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@Interest";
                    ceeAdapter.Parameters.Add(sqlParameter);
                    foreach (var interest in interestList)
                    {
                        ceeAdapter.Parameters["@Interest"].Value = interest;
                        ceeAdapter.ExecuteNonQuery();
                    }
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public bool CheckUserInterestExist(AccountEntity acc)
        {
            bool exist = false;

            List<string> intList = acc.Interest;
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            foreach (var interest in intList)
            {
                string command =
                    "SELECT Interest, Account.Id FROM dbo.Interest INNER JOIN dbo.Account ON Account.Id = Interest.userID WHERE dbo.Account.Id = @userID AND Interest = @Interest";
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    using (SqlCommand selinterestcmd = new SqlCommand(command, con))
                    {
                        con.Open();
                        selinterestcmd.Parameters.AddWithValue("@userID", acc.Userid);
                        selinterestcmd.Parameters.AddWithValue("@Interest", interest);
                        using (SqlDataReader dr = selinterestcmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                exist = true;
                            }
                            else
                            {
                                exist = false;
                            }
                        }
                    }

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }

            return exist;
        }

        public List<string> GetUserInterest(AccountEntity acc)
        {
            List<string> interestList = new List<string>();
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string command =
                "SELECT Interest FROM dbo.Interest INNER JOIN dbo.Account ON Account.Id = Interest.userID WHERE dbo.Account.Id = @userID";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                using (SqlCommand selinterestcmd = new SqlCommand(command, con))
                {
                    con.Open();
                    selinterestcmd.Parameters.AddWithValue("@userID", acc.Userid);
                    selinterestcmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(selinterestcmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        interestList.Add(myRow["Interest"].ToString());
                    }
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return interestList;
        }

        public List<string> GetAllOtherEmail(string useremail)
        {
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string Command = "SELECT email FROM dbo.Account WHERE email != @ParamEmail";
            List<string> emails = new List<string>();
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                using (SqlCommand selPwcmd = new SqlCommand(Command, con))
                {
                    selPwcmd.Parameters.AddWithValue("@ParamEmail", useremail);

                    selPwcmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(selPwcmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        emails.Add(myRow["email"].ToString());
                    }
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return emails;
        }

        public void SetUserOnline(string email)
        {
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder cmd = new StringBuilder();
            cmd.Append(
                "UPDATE dbo.Account");
            cmd.Append(
                " SET online='True' ");
            cmd.Append(
                "WHERE email = @email");
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                using (SqlCommand adapter = new SqlCommand(cmd.ToString(), con))
                {
                    adapter.Parameters.AddWithValue("@email", email);
                    adapter.ExecuteNonQuery();
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void SetUserOffline(string email)
        {
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder cmd = new StringBuilder();
            cmd.Append(
                "UPDATE dbo.Account");
            cmd.AppendLine(
                " SET online='false' ");
            cmd.AppendLine(
                "WHERE email = @email");
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                using (SqlCommand adapter = new SqlCommand(cmd.ToString(), con))
                {
                    adapter.Parameters.AddWithValue("@email", email);
                    adapter.ExecuteNonQuery();
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}