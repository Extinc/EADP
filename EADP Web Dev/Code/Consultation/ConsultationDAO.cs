using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace EADP_Web_Dev.Code.Consultation
{
    public class ConsultationDAO
    {
        public List<Consultations> GetDoctors(int id)
        {
            List<Consultations> docList = new List<Consultations>();

            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder Command = new StringBuilder();
            Command.Append("SELECT Account.roleid, roleName, fName, lName, email, hpNo FROM dbo.Roles");
            Command.Append(" INNER JOIN dbo.Account ON Account.roleid = Roles.roleID ");
            Command.Append("WHERE Account.roleid = 3 AND Account.online = 'true'");

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand selDoctor = new SqlCommand(Command.ToString(), con))
                {
                    selDoctor.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(selDoctor);
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet, "Account");
                    foreach (DataRow myRow in myDataSet.Tables["Account"].Rows)
                    {
                        Consultations consult = new Consultations();
                        AccountEntity acc = new AccountEntity
                        {
                            FirstName = myRow["fName"].ToString(),
                            LastName = myRow["lName"].ToString(),
                            Email = myRow["email"].ToString(),
                            Phone = myRow["hpNo"].ToString()
                        };
                        consult.Doctors = acc;
                        docList.Add(consult);
                    }
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            if (CheckIfUserIsDoctor(id))
            {
                foreach (var d in docList)
                {
                    if (d.UserId == id)
                        docList.RemoveAt(docList.IndexOf(d));
                }
            }

            return docList;
        }

        public bool CheckIfUserIsDoctor(int id)
        {
            bool isDoc = false;
            int roleid = 1;
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder Command = new StringBuilder();
            Command.Append("SELECT Account.roleid, Id FROM dbo.Roles");
            Command.Append(" INNER JOIN dbo.Account ON Account.roleid = Roles.roleID ");
            Command.Append("WHERE Account.roleid = 3 AND Account.online = 'true' AND Id = @id ");

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand selDoctor = new SqlCommand(Command.ToString(), con))
                {
                    selDoctor.Parameters.AddWithValue("@id", id);
                    selDoctor.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(selDoctor);
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet, "Account");
                    if (myDataSet.Tables["Account"].Rows.Count > 0)
                    {
                        isDoc = true;
                    }
                    else
                    {
                        isDoc = false;
                    }
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return isDoc;
        }

        public AccountEntity GetLoggedInPatient(int userId)
        {
            AccountEntity acc = new AccountEntity();
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmd = "SELECT fName, lName, email, dob, hpNo FROM dbo.Account WHERE Id = @id";
            using (SqlConnection sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(cmd, sqlCon))
                {
                    sqlCmd.Parameters.AddWithValue("@id", userId);
                    sqlCmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet, "AccountEntity");
                    foreach (DataRow myRow in myDataSet.Tables["AccountEntity"].Rows)
                    {
                        acc.FirstName = myRow["fName"].ToString();
                        acc.LastName = myRow["lName"].ToString();
                        acc.Email = myRow["email"].ToString();
                        acc.Phone = myRow["hpNo"].ToString();
                    }
                }
                sqlCon.Close();
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return acc;
        }

        public bool CheckIfChatExist(int fId, string targetemail)
        {
            bool exist = false;
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmd =
                "SELECT * FROM dbo.Chat WHERE fmemberId = @fId1 AND lmemberid = @lId2";
            using (SqlConnection sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(cmd, sqlCon))
                {
                    sqlCmd.Parameters.AddWithValue("@fid1", fId);
                    sqlCmd.Parameters.AddWithValue("@lid2", GetTargetId(targetemail));
                    sqlCmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet, "chat");
                    if (myDataSet.Tables["chat"].Rows.Count > 0)
                    {
                        exist = true;
                    }
                    else
                    {
                        exist = false;
                    }
                }
                sqlCon.Close();
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return exist;
        }

        public int GetChatId(int fId, string targetemail)
        {
            int i = 0;
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            /*            string cmd =
                            "SELECT * FROM dbo.Chat WHERE fmemberId = @fId1 OR fmemberId = @fId2 AND lmemberid = @lId1 OR lmemberid = @lId2";*/
            string cmd =
                "SELECT * FROM dbo.Chat WHERE fmemberId = @fId1 AND lmemberid = @lId2";
            using (SqlConnection sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(cmd, sqlCon))
                {
                    sqlCmd.Parameters.AddWithValue("@fid1", fId);
/*                    sqlCmd.Parameters.AddWithValue("@fid2", GetTargetId(targetemail));*/
                    sqlCmd.Parameters.AddWithValue("@lId2", GetTargetId(targetemail));
     /*               sqlCmd.Parameters.AddWithValue("@lId2", GetTargetId(targetemail));*/
                    sqlCmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet, "chat");
                    foreach (DataRow myRow in myDataSet.Tables["chat"].Rows)
                    {
                        i = Convert.ToInt32(myRow["Id"]);
                    }
                }
                sqlCon.Close();
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return i;
        }

        public int CreateNewChat(int fid, string targetemail)
        {
            // i = 0 chat has been created before w
            // i = 1 create new chat
            int i = 0;

            if (CheckIfChatExist(fid, targetemail) == false)
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                var cmdstr = new StringBuilder();
                cmdstr.Append("INSERT INTO dbo.Chat (timestamp,fmemberId,lmemberid)");
                cmdstr.Append("VALUES (GETDATE(), @fmemberid,@lmemberids)");

                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdstr.ToString(), con))
                    {
                        int targetid = GetTargetId(targetemail);
                        cmd.Parameters.AddWithValue("@fmemberid", fid);
                        cmd.Parameters.AddWithValue("@lmemberids", targetid);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                i = 0;
            }

            return i;
        }

        public void InsertMessage(string message, int userid, int chatid)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            var cmdstr = new StringBuilder();
            cmdstr.Append("INSERT INTO dbo.Conversation (Conversation, userID, timestamp, chatId)");
            cmdstr.Append("VALUES (@message, @userid, GETDATE(), @chatId)");

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdstr.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@message", message);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@chatId", chatid);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void InsertChatNotification(string message, int userid, string targetemail)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder cmdInsertNotifiation = new StringBuilder();
            cmdInsertNotifiation.Append(
                "INSERT INTO dbo.Notifications(Message, date, resID, byWho, type)");
            cmdInsertNotifiation.Append(
                "VALUES(@Message, GETDATE(), @resID, @byWho, @type)");

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdInsertNotifiation.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@Message", message);
                    cmd.Parameters.AddWithValue("@resID", GetTargetId(targetemail));
                    cmd.Parameters.AddWithValue("@byWho", userid);
                    cmd.Parameters.AddWithValue("@type", "chat");
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }

        public bool CheckIfHaveSendNotification(int resID, int senderID)
        {
            bool send = false;

            return send;
        }

        public int GetTargetId(string email)
        {
            var i = 0;
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmd = "SELECT Id FROM dbo.Account WHERE email = @email";
            using (SqlConnection sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(cmd, sqlCon))
                {
                    sqlCmd.Parameters.AddWithValue("@email", email);
                    sqlCmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet, "Entity");
                    foreach (DataRow myRow in myDataSet.Tables["Entity"].Rows)
                    {
                        i = Convert.ToInt32(myRow["Id"]);
                    }
                }
                sqlCon.Close();
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }

            return i;
        }

        public List<Consultations> GetChatMessage(int chatid)
        {
            List<Consultations> consult = new List<Consultations>();

            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmd = "SELECT* FROM dbo.Conversation WHERE chatId = @chatid";
            using (SqlConnection sqlCon = new SqlConnection(constr))
            {
                sqlCon.Open();
                using (SqlCommand sqlCmd = new SqlCommand(cmd, sqlCon))
                {
                    sqlCmd.Parameters.AddWithValue("@chatid", chatid);
                    sqlCmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    DataSet myDataSet = new DataSet();
                    adapter.Fill(myDataSet, "chat");
                    foreach (DataRow myRow in myDataSet.Tables["chat"].Rows)
                    {
                        Consultations consultations = new Consultations();
                        consultations.Message = Convert.ToString(myRow["Conversation"]);
                        consultations.UserId = Convert.ToInt32(myRow["userID"]);
                        consultations.Timestamp = (DateTime) myRow["timestamp"];
                        consult.Add(consultations);
                    }

                }
                sqlCon.Close();
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }


            return consult;
        }

        //TODO: To be continue to retrieve all chat history
        public List<Consultations> GetChat(int snderid, string targetemail)
        {
            List<Consultations> consultlist = new List<Consultations>();
            int targetid = GetTargetId(targetemail);
            

            return consultlist;
        }
    }
}