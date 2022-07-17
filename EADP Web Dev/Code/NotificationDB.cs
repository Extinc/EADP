using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EADP_Web_Dev.Code
{
    public class NotificationDB
    {
        public List<Notifications> GetNotificationsOfUser(string userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            List<Notifications> notiList = new List<Notifications>();
            string cmdstr = "SELECT * FROM Notifications WHERE resID = @res";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdstr, con))
                {
                    cmd.Parameters.AddWithValue("@res", userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        Notifications noti = new Notifications();
                        noti.Message = Convert.ToString(myRow["Message"]);
                        noti.NotificationId = Convert.ToInt32(myRow["NotificationId"]);
                        noti.ByUser = GetByWhoName(Convert.ToInt32(myRow["byWho"]));
                        noti.Type = Convert.ToString(myRow["type"]);
                        noti.ByUserEmail = GetEmail(Convert.ToInt32(myRow["byWho"]));
                        notiList.Add(noti);
                    }
                }
                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return notiList;
        }

        public string GetEmail(int id)
        {
            var email = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmdstr = "SELECT email FROM Account WHERE Id = @id";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdstr, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        email = Convert.ToString(myRow["email"]);
                    }
                }
                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return email;
        }

        public string GetByWhoName(int userid)
        {
            string who = "";
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmdstr = "SELECT * FROM Account WHERE Id = @id";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdstr, con))
                {
                    cmd.Parameters.AddWithValue("@id", userid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        who = Convert.ToString(myRow["fName"]) + " " + Convert.ToString(myRow["lName"]);
                    }
                }
                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return who;
        }

        public void SetConfirm(int notificationId, int userId, string eventName, bool confirm)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmdstr = "UPDATE dbo.CEmember SET confirmation = @confirm WHERE eventID = @eID AND memberID = @memID";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdstr, con))
                {
                    cmd.Parameters.AddWithValue("@eID", GetEventId(eventName));
                    cmd.Parameters.AddWithValue("@confirm", confirm);
                    cmd.Parameters.AddWithValue("@memID", userId);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public int GetEventId(string eventName)
        {
            var id = 0;
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string cmdstr = "SELECT Id FROM ComEvent WHERE event = @event";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(cmdstr, con))
                {
                    cmd.Parameters.AddWithValue("@event", eventName);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        id = Convert.ToInt32(myRow["Id"]);
                    }
                }
                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return id;
        }

        public void InsertNotification(string message, string by)
        {

        }
    }
}