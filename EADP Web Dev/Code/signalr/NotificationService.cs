using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace EADP_Web_Dev.Code.signalr
{
    public class NotificationService
    {
        internal static SqlCommand command = null;
        internal static SqlDependency dependency = null;
/*        public static string GetNotification()
        {
            string connstr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            try
            {

                var messages = new List<Notifications>();
                using (var connection = new SqlConnection(connstr))
                {
                    string cmdstr = "SELECT notificationId, message, resID from Notifications";
                    connection.Open();
                    //// Sanjay : Alwasys use "dbo" prefix of database to trigger change event
                    using (command = new SqlCommand(cmdstr, connection))
                    {
                        command.Notification = null;

                        if (dependency == null)
                        {
                            dependency = new SqlDependency(command);
                            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        }

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            messages.Add(item: new Notifications()
                            {
                                NotificationId = (int)reader["notificaionId"],
                                Message = reader["message"] != DBNull.Value ? (string)reader["message"] : "",
                            });
                        }
                    }

                }
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(messages);
                return json;

            }
            catch (Exception ex)
            {

                return null;
            }


        }*/

/*        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (dependency != null)
            {
                dependency.OnChange -= dependency_OnChange;
                dependency = null;
            }
            if (e.Type == SqlNotificationType.Change)
            {
                NotificationHub.Send();
            }
        }*/
    }
}