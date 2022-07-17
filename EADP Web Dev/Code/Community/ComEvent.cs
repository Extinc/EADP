using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EADP_Web_Dev.Code.Community
{
    public class ComEvent
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public ComEvent()
        {
        }


        public void CreateEvent(Community com, string userId)
        {
            string strConString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            StringBuilder command = new StringBuilder();
            command.Append(
                "INSERT INTO dbo.ComEvent(event, startDate, endDate, ownerID)");
            command.Append(
                "VALUES(@event, @startDate, @endDate, @ownerID) SELECT @@IDENTITY AS [@@IDENTITY]");
            string scopeIdentity = "SELECT scope_identity()";
            var eventId = 0; 
            StringBuilder cmdInsertMember = new StringBuilder();
            cmdInsertMember.Append(
                "INSERT INTO dbo.CEmember(eventID, memberID, confirmation)");
            cmdInsertMember.Append(
                "VALUES(@eventid, @memberid, @confirm)");

            StringBuilder cmdInsertNotifiation = new StringBuilder();
            cmdInsertNotifiation.Append(
                "INSERT INTO dbo.Notifications(Message, date, resID, byWho, type)");
            cmdInsertNotifiation.Append(
                "VALUES(@Message, GETDATE(), @resID, @byWho, @type)");
            var memberID = 0;
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command.ToString(), con))
                {
                    cmd.Parameters.AddWithValue("@event", com.EventTitle);
                    cmd.Parameters.AddWithValue("@startDate", com.StartDateTime);
                    cmd.Parameters.AddWithValue("@endDate", com.EndDateTime);
                    cmd.Parameters.AddWithValue("@ownerID", userId);
                    eventId = (int) (decimal) cmd.ExecuteScalar();
                }

                if (!com.EventInvitees.All(string.IsNullOrWhiteSpace))
                {
                    foreach (var member in com.EventInvitees)
                    {
                        string cmdstr = "SELECT Id FROM dbo.Account WHERE email = @email";
                        using (SqlCommand cmd = new SqlCommand(cmdstr, con))
                        {
                            cmd.Parameters.AddWithValue("@email", member);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable myDataSet = new DataTable();
                            adapter.Fill(myDataSet);
                            foreach (DataRow myRow in myDataSet.Rows)
                            {
                                memberID = (int) myRow["Id"];
                            }
                        }

                        using (SqlCommand cmd1 = new SqlCommand(cmdInsertMember.ToString(), con))
                        {
                            cmd1.Parameters.AddWithValue("@eventid", eventId);
                            cmd1.Parameters.AddWithValue("@memberid", memberID);
                            cmd1.Parameters.AddWithValue("@confirm", false);
                            cmd1.ExecuteNonQuery();
                        }


                        using (SqlCommand cmd1 = new SqlCommand(cmdInsertNotifiation.ToString(), con))
                        {
                            cmd1.Parameters.AddWithValue("@Message", "You have been invited to "+ com.EventTitle);
                            cmd1.Parameters.AddWithValue("@resID", memberID);
                            cmd1.Parameters.AddWithValue("@byWho", Convert.ToInt32(userId));
                            cmd1.Parameters.AddWithValue("@type", "noti");
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }

                con.Close();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<Community> GetUserCreatedEvent(string userId)
        {
            List<Community> lCom = new List<Community>();
            int ownerID = 0;
            string cmdstr = "SELECT * FROM dbo.CEmember INNER JOIN dbo.ComEvent ON ComEvent.Id = CEmember.eventID WHERE memberID = @id OR  ownerID = @id  AND confirmation = \'true\'";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(cmdstr, con))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        Community community = new Community
                        {
                            EventTitle = myRow["event"] as string,
                            StartDateTime = (DateTime) myRow["startDate"],
                            EndDateTime = (DateTime) myRow["endDate"],
                        };
                        lCom.Add(community);
                    }
                }
            }
            return lCom;
        }
    }
}