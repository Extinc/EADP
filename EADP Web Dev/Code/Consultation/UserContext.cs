using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EADP_Web_Dev.Code.Consultation
{
    public class UserContext : DbContext
    {
        public UserContext() : base("ConnStr")
        {
        }

        public DbSet<Account> User { get; set; }
    }

    public class Account
    {
        [Key]
        public int id { get; set; }
        [Column("email")]
        public string Email { get; set; }
        public ICollection<Connection> Connections { get; set; }
        public virtual ICollection<ConversationRoom> Rooms { get; set; }
    }

    public class Connection
    {
        public string ConnectionID { get; set; }
        public string UserAgent { get; set; }
        public bool Connected { get; set; }
    }
    public class ConversationRoom
    {
        [Key]
        public int id { get; set; }
        public string RoomName { get; set; }
        public virtual ICollection<Account> Users { get; set; }
    }
}