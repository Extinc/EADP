using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using EADP_Web_Dev.Code;
using Microsoft.AspNet.SignalR;

namespace EADP_Web_Dev.App_Code.signalr.js
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        AccountDb _accountDb = new AccountDb();

        public void Send(string messages, string who, string name)
        {
            DateTime now = DateTime.Now;
            foreach (var connectionId in _connections.GetConnections(who))
            {
                Clients.Client(connectionId)
                    .addNotify(new {sender = name, target = who, message = messages, timestamp = now});
            }
        }

        public void SendPatientToChat(string patientemail)
        {
            foreach (var connectionId in _connections.GetConnections(patientemail))
            {
                Clients.Client(connectionId)
                    .goToChat(new {sender = Context.User.Identity.Name, patient = patientemail});
            }
        }

        public void SendMesage(string messages, string roomName, string name)
        {
            DateTime now = DateTime.Now;
            Clients.Group(roomName).addMessage(new {sender = name, message = messages, timestamp = now});
        }

        public void SendPrivate(string messages, string targetemail)
        {
            DateTime now = DateTime.Now;
            foreach (var connectionId in _connections.GetConnections(targetemail))
            {
                Clients.Client(connectionId)
                    .getPmessages(new {sender = Context.User.Identity.Name, target = targetemail, message = messages});
            }
        }

        public void JoinConversation(string roomName, string email)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            int accid = 0;
            int roomid = 0;
            bool exist = CheckIfRoomExist(roomName);
            bool userExist = CheckIfUserExist(email, roomName);
            string statement1 = "SELECT Id FROM dbo.Account WHERE email = @email";
            string statement2 = "SELECT Id FROM dbo.Chat WHERE room = @room";
            string addUserStatement =
                "INSERT INTO dbo.ChatMember( roomId, memberId)VALUES (@roomid, @memberid)";
            if (exist == false)
            {
                AccountEntity ae1 = _accountDb.GetAccountData(email);
                AccountEntity ae2 = _accountDb.GetAccountData(Context.User.Identity.Name);
                string statement =
                    "INSERT INTO dbo.Chat( room, timestamp)VALUES (@room, GETDATE())";

                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(statement, con))
                    {
                        cmd.Parameters.AddWithValue("@room", roomName);
                        cmd.ExecuteNonQuery();
                    }

                    if (userExist == false)
                    {
                        using (SqlCommand cmd = new SqlCommand(statement1, con))
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable myDataSet = new DataTable();
                            adapter.Fill(myDataSet);
                            foreach (DataRow myRow in myDataSet.Rows)
                            {
                                accid = (int) myRow["Id"];
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(statement2, con))
                        {
                            cmd.Parameters.AddWithValue("@room", roomName);
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable myDataSet = new DataTable();
                            adapter.Fill(myDataSet);
                            foreach (DataRow myRow in myDataSet.Rows)
                            {
                                roomid = (int) myRow["Id"];
                            }
                        }


                        using (SqlCommand cmd = new SqlCommand(addUserStatement, con))
                        {
                            cmd.Parameters.AddWithValue("@roomid", roomid);
                            cmd.Parameters.AddWithValue("@memberid", accid);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }


                foreach (var connectionId in _connections.GetConnections(email))
                {
                    Groups.Add(connectionId, roomName);
                }

                Groups.Add(Context.ConnectionId, roomName);
            }
            else
            {
                if (userExist == false)
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(statement1, con))
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable myDataSet = new DataTable();
                            adapter.Fill(myDataSet);
                            foreach (DataRow myRow in myDataSet.Rows)
                            {
                                accid = (int) myRow["Id"];
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(statement2, con))
                        {
                            cmd.Parameters.AddWithValue("@room", roomName);
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable myDataSet = new DataTable();
                            adapter.Fill(myDataSet);
                            foreach (DataRow myRow in myDataSet.Rows)
                            {
                                roomid = (int) myRow["Id"];
                            }
                        }


                        using (SqlCommand cmd = new SqlCommand(addUserStatement, con))
                        {
                            cmd.Parameters.AddWithValue("@roomid", roomid);
                            cmd.Parameters.AddWithValue("@memberid", accid);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                foreach (var connectionId in _connections.GetConnections(email))
                {
                    Groups.Add(connectionId, roomName);
                }

                Groups.Add(Context.ConnectionId, roomName);
            }
        }

        public void RemoveFromRoom(string roomName, string patientEmail)
        {
            bool exist = CheckIfRoomExist(roomName);
            // Retrieve room.

            if (exist)
            {
                Groups.Remove(Context.ConnectionId, roomName);
            }
        }

        public bool CheckIfUserExist(string email, string roomName)
        {
            bool exist = false;
            int accid = 0;
            int roomid = 0;
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string statement = "SELECT Id FROM dbo.Account WHERE email = @email";
            string statement1 = "SELECT Id FROM dbo.Chat WHERE room = @room";
            string statement2 = "SELECT * FROM dbo.ChatMember WHERE roomId = @room AND memberId = @member";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(statement, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        accid = (int) myRow["Id"];
                    }
                }

                using (SqlCommand cmd = new SqlCommand(statement1, con))
                {
                    cmd.Parameters.AddWithValue("@room", roomName);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    foreach (DataRow myRow in myDataSet.Rows)
                    {
                        roomid = (int) myRow["Id"];
                    }
                }

                using (SqlCommand cmd = new SqlCommand(statement2, con))
                {
                    cmd.Parameters.AddWithValue("@room", accid);
                    cmd.Parameters.AddWithValue("@member", roomid);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable myDataSet = new DataTable();
                    adapter.Fill(myDataSet);
                    if (myDataSet.Rows.Count > 0)
                    {
                        exist = true;
                    }
                    else
                    {
                        exist = false;
                    }
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return exist;
        }

        public bool CheckIfRoomExist(string roomName)
        {
            int numberofRec;
            string constr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            string statement = "SELECT count(room) FROM dbo.Chat WHERE room = @room";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(statement, con))
                {
                    cmd.Parameters.AddWithValue("@room", roomName);
                    numberofRec = (int) cmd.ExecuteScalar();
                }

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return numberofRec > 0;
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            _accountDb.SetUserOnline(name);
            _connections.Add(name, Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;

            _accountDb.SetUserOffline(name);

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;
            _accountDb.SetUserOnline(name);
            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }
}