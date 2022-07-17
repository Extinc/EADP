using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Web_Dev.Code.Community
{
    public class Community
    {
        public string EventTitle { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string EventInfo { get; set; }
        public List<string> EventInvitees { get; set; }
        public bool Confirmation { get; set; }
        public List<string> Members { get; set; }

    }
}