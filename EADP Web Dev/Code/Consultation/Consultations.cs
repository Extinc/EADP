using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Web_Dev.Code.Consultation
{
    public class Consultations
    {
        public bool Available { get; set; }

        public AccountEntity Doctors { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }
    }

}