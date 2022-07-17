namespace EADP_Web_Dev.Code
{
    public class Notifications
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public int ToUser { get; set; }

        public string ByUser { get; set; } 

        public string ByUserEmail { get; set; }

        public string Type { get; set; } 
    }
}